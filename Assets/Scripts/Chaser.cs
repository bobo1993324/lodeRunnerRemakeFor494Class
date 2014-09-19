using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chaser : People {
	private GameObject player;
	public override void addFloor (GameObject go)
	{
		Debug.Log("add floor" + go.tag);
		if (go.tag == "Floor" && !go.GetComponent<Floor>().isDug()) {
			Debug.Log("add floor2\t");
			floors.Add(go);
		}
		if (go.tag == "HardFloor") {
			floors.Add(go);
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
				GameObject goDown = this.map.getObjectAt(i, myYRounded);
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
	private Vector2 goLeft() {
		Debug.Log("go left");
		return new Vector2 (-1, 0);
	}
	private Vector2 goRight() {
		Debug.Log("go right");
		return new Vector2 (1, 0);
	}
	private Vector2 goUp() {
		Debug.Log("go up");
		return new Vector2(0, 1);
	}
	private Vector2 goDown() {
		return new Vector2 (0, -1);
	}
	private Vector2 goToNearest(List<float> candidatesPosition, float myx, float playerx) {
		int minIdx = 0;
		float minDistance = Mathf.Abs(candidatesPosition[0] - myx)
			+ Mathf.Abs(candidatesPosition[0] - playerx);
		for(int i = 1; i < candidatesPosition.Count; i++) {
			if (Mathf.Abs(candidatesPosition[i] - myx) 
			    + Mathf.Abs(candidatesPosition[i] - playerx)
			    > minDistance) {
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
