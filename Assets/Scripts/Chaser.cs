using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chaser : People {
	public GameObject goldPrefab;
	public float dropGoldRate = 0.05f;
	public float pitDownTime = 3f;

	private GameObject player;
	public int goldCount = 0;
	private System.Random rand = new System.Random();
	public bool inPit = false;
	void Start() {
		base.Start ();
		StartCoroutine ("dropGoldRandomly");
	}
	void Update() {
		if(!inPit) {
			base.Update();
		}
	}
	IEnumerator dropGoldRandomly() {
		while (true) {
			yield return new WaitForSeconds(1);
			if (rand.NextDouble() < dropGoldRate) {
				Vector3 myPostion = transform.position;
				int myXRounded = Mathf.RoundToInt (myPostion.x);
				int myYRounded = Mathf.RoundToInt (myPostion.y);
				if (map.gameObjectMatrix[myXRounded, myYRounded] == null) {
					dropGold();
				}
			}
		}
	}
	public void dropAllGold() {
		while(goldCount > 0) {
			goldCount --;
			dropGold();
		}
	}
	public void collectGold() {
		goldCount ++;
	}
	public void dropGold() {
		Debug.Log ("Drop gold");
		if (goldCount > 0) {
			goldCount --;
			GameObject go = Instantiate(goldPrefab, new Vector2(Mathf.Round(gameObject.transform.position.x),
			                                    Mathf.Round(gameObject.transform.position.y)),
			            Quaternion.identity) as GameObject;
			go.GetComponent<Gold>().disableCollectForSeconds(1);
		}
	}
	public override Vector2 decideMovement() {
		//get player position
		player = map.getPlayer ();
		Vector3 playerPosition = player.transform.position;
		int playerXRounded = Mathf.RoundToInt (playerPosition.x);
		int playerYRounded = Mathf.RoundToInt (playerPosition.y);
		Vector3 myPostion = transform.position;
		int myXRounded = Mathf.RoundToInt (myPostion.x);
		int myYRounded = Mathf.RoundToInt (myPostion.y);

		MoveDirection md = map.getChaseDirection (playerXRounded, playerYRounded, myXRounded, myYRounded);
		//Debug.Log ("decideMovement " + myXRounded + " " + myYRounded + " " + md); 
		if (md == MoveDirection.GO_LEFT || md == MoveDirection.GO_RIGHT) {
			if (myPostion.y - myYRounded > 0.05f && onLadderCount > 0) {
				return goDown();
			} else if (myPostion.y - myYRounded < -0.05f && onLadderCount > 0) {
				return goUp();
			} else {
				if (md == MoveDirection.GO_LEFT)
					return goLeft();
				else 
					return goRight();
			}
		} else if (md == MoveDirection.GO_DOWN || md == MoveDirection.GO_UP) {
			//first move to center
			if (myPostion.x - myXRounded > 0.05f) {
				return goLeft();
			} else if (myPostion.x - myXRounded < -0.05f) {
				return goRight();
			} else {
				if (md == MoveDirection.GO_DOWN)
					return goDown();
				else 
					return goUp();
			}
		}

		//use lame algorithm if cannot precompute path
		if (Mathf.Abs (playerPosition.y - myPostion.y) < 0.04) {
			//on same level
			if (myXRounded > playerXRounded) {
				return goLeft();
			} else {
				return goRight();
			}
		} else if (playerPosition.y - myPostion.y > 0.04) {
			//find a ladder to climb up
			if (onLadderCenter()) {
				return goUp();
			}

			List<GameObject> ladders = map.getLaddersAtHeight(myYRounded);
			List<float> laddersPosition = new List<float>();
			foreach(GameObject ladder in ladders) {
				laddersPosition.Add(ladder.transform.position.x);
			}
			if (ladders.Count > 0) {
				return goToNearest(laddersPosition, myPostion.x, playerPosition.x);
			}
		} else {
			//go down
			if (this.canGoDown()) {
				return goDown ();
			}
			List<float> candidatesPosition = new List<float>();
			for (int i = 0; i < this.map.width; i++) {
				GameObject goDown = this.map.getObjectAt(i, myYRounded - 1);
				GameObject goCurrentLevel = this.map.getObjectAt(i, myYRounded);
				if ((goDown == null || !goDown.tag.Contains("Floor")) 
				    && (goCurrentLevel == null || !goCurrentLevel.tag.Contains("Floor"))) {
					candidatesPosition.Add (i);
				}
			}
			if (candidatesPosition.Count > 0) {
				return goToNearest(candidatesPosition, myPostion.x, playerPosition.x);
			}
		}

		return new Vector2(0, 0);
	}
	public override void die ()
	{
		Destroy (gameObject);
		Camera.main.GetComponent<GenerateMap> ().respawnEnermy ();
		//Respawn
	}
	private Vector2 goLeft() {
		//Debug.Log ("<-");
		return new Vector2 (-1, 0);
	}
	private Vector2 goRight() {
		//Debug.Log ("->");
		return new Vector2 (1, 0);
	}
	private Vector2 goUp() {
		//Debug.Log ("^");
		return new Vector2(0, 1);
	}
	private Vector2 goDown() {
		//Debug.Log ("v");
		return new Vector2 (0, -1);
	}
	public void dropToPit() {
		Debug.Log ("dropToPit");
		inPit = true;
		StartCoroutine ("reviveFromPit");
	}
	IEnumerator reviveFromPit() {
		updateDisabled = true; // disable update sothat it is not pushed to the center on leftorrightwall
		yield return new WaitForSeconds(pitDownTime);
		Vector3 myPosition = transform.position;
		myPosition.y += 1;
		transform.position = myPosition;
		Vector2 move = decideMovement ();
		myPosition.x += 0.4f * move.x;
		Debug.Log ("revive " + move.x);
		transform.position = myPosition;
		inPit = false;
		yield return new WaitForSeconds(0.1f);
		updateDisabled = false;
	}
	private Vector2 goToNearest(List<float> candidatesPosition, float myx, float playerx) {
		int minIdx = 0;
		float minDistance = Mathf.Abs(candidatesPosition[0] - playerx) +  Mathf.Abs(candidatesPosition[0] - myx);
		for(int i = 1; i < candidatesPosition.Count; i++) {
			if (Mathf.Abs(candidatesPosition[i] - myx) 
			    + Mathf.Abs(candidatesPosition[i] - playerx)
			    < minDistance) {
				minIdx = i;
			}
		}
		if (candidatesPosition[minIdx] > myx) {
			return goRight();
		} else {
			return goLeft();
		}
	}
}
