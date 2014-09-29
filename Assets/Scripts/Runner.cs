using UnityEngine;
using System.Collections;

public class Runner : People {
	public AudioSource dieSound;
	enum RunnerState {
		NORMAL,
		DIGGING
	};
	RunnerState state = RunnerState.NORMAL;
	GameObject digTarget;
	void Start() {
		base.Start ();
		dieSound = Camera.main.GetComponent<SoundStore> ().dieSound;
	}
	bool isDead = false;
	new void Update() {
		if (isDead) {
			return;
		}
		if (Input.GetKey (KeyCode.G)) {
			GameObject[] chaserObjects = GameObject.FindGameObjectsWithTag("Chaser");
			foreach (GameObject chaser in chaserObjects) {
				Destroy(chaser);
			}
		}
		if (!isFalling) {
			if (Input.GetKey (KeyCode.Z)) {
				Debug.Log("digHoleLeft");
				GameObject goLeftDown = map.getObjectAt(
					Mathf.RoundToInt(transform.position.x) - 1,
					Mathf.RoundToInt(transform.position.y) - 1
				);
				GameObject goLeft = map.getObjectAt(
					Mathf.RoundToInt(transform.position.x) - 1,
					Mathf.RoundToInt(transform.position.y)
				);
				if ((goLeftDown != null && goLeftDown.tag == "Floor")
				    && (goLeft == null || !goLeft.tag.Contains("Floor"))) {
					centerX();
					if (state == RunnerState.NORMAL) {
						digTarget = goLeftDown;
						StartCoroutine("startDig");
					}
				}
				return;
			} else if (Input.GetKey(KeyCode.X)) {
				GameObject goRightDown = map.getObjectAt(
					Mathf.RoundToInt(transform.position.x) + 1,
					Mathf.RoundToInt(transform.position.y) - 1
					);
				GameObject goRight = map.getObjectAt(
					Mathf.RoundToInt(transform.position.x) + 1,
					Mathf.RoundToInt(transform.position.y)
					);
				if ((goRightDown != null && goRightDown.tag == "Floor")
				    && (goRight == null || !goRight.tag.Contains("Floor"))) {

					centerX();
					if (state == RunnerState.NORMAL) {
						digTarget = goRightDown;
						StartCoroutine("startDig");
					}
				}
				return;
			}
		}
		if (state == RunnerState.NORMAL) 
			base.Update ();
	}
	public override Vector2 decideMovement() {
		if (Input.GetAxisRaw ("Horizontal") != 0)
			return new Vector2(Input.GetAxisRaw ("Horizontal"), 0);
		else
			return new Vector2(0, Input.GetAxisRaw("Vertical"));
	}
	public override void die ()
	{
		if (!isDead) {
			isDead = true;
			gameObject.renderer.enabled = false;
			dieSound.Play();
			StartCoroutine ("reloadLevelIn1Second");
		}
	}
	IEnumerator reloadLevelIn1Second() {
		yield return new WaitForSeconds (3);
		int life = PlayerPrefs.GetInt ("life");
		life --;
		PlayerPrefs.SetInt ("life", life);
		if (life > 0)
			Application.LoadLevel ("ShowLifeAtStart");
		else 
			Application.LoadLevel ("GameOver");
	}
	private void centerX() {
		Vector3 p = transform.position;
		p.x += (Mathf.Round(p.x) - p.x)/5;
		transform.position = p;
	}
	private IEnumerator startDig() {
		state = RunnerState.DIGGING;
		Floor floor = digTarget.GetComponent<Floor>();
		floor.dig();
		while (true) {
			yield return new WaitForSeconds(0.1f);
			if (floor.digState() != 1) {
				state = RunnerState.NORMAL;
				break;
			}
		}
	}
}
