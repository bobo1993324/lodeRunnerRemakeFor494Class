using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public float runSpeed;
	public float climbSpeed;

	public int wallOnRightCount = 0;
	public int wallOnLeftCount = 0;

	bool hasWallOnRight() {
		return wallOnRightCount == 0;
	}
	bool hasWallOnLeft() {
		return wallOnLeftCount == 0;
	}
	public bool onLadder = false;
	public bool onLadderTop = false;
	public bool onFloor = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float horizontalMoveDistance = Input.GetAxisRaw ("Horizontal") * runSpeed * Time.deltaTime;
		bool stopByWall = (hasWallOnLeft && horizontalMoveDistance < 0) 
						|| (hasWallOnRight && horizontalMoveDistance > 0); 
		if (!stopByWall) { 
			Vector3 previousPosition = transform.position;
			previousPosition.x += horizontalMoveDistance;
			transform.position = previousPosition;
		}
		float verticalMoveDistance = Input.GetAxisRaw ("Vertical") * climbSpeed * Time.deltaTime;
		bool noMoreLadderUp = onLadderTop && verticalMoveDistance > 0;
		bool onFloorDown = onFloor && verticalMoveDistance < 0;
		if (onLadder && !noMoreLadderUp && !onFloorDown) {
			Vector3 previousPosition = transform.position;
			previousPosition.y += verticalMoveDistance;
			transform.position = previousPosition;
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		GameObject gameObject = coll.gameObject;
		if (gameObject.tag == "HardFloor" || gameObject.tag == "Floor") {
			if (Mathf.Abs(transform.position.y - gameObject.transform.position.y) < 0.31) {
				if (transform.position.x < gameObject.transform.position.x) {
					Vector3 pos = transform.position;
					pos.x = gameObject.transform.position.x - 0.32f;
					transform.position = pos;
					hasWallOnRight = true;
				} else {
					Vector3 pos = transform.position;
					pos.x = gameObject.transform.position.x + 0.32f;
					transform.position = pos;
					hasWallOnLeft = true;
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		GameObject gameObject = coll.gameObject;
		if (gameObject.tag == "Ladder") {
			onLadder = true;
			Ladder ladder = gameObject.GetComponent<Ladder>();
			if (ladder.isTopLadder) {
				if (transform.position.y - 0.32f < gameObject.transform.position.y)
					onLadderTop = false;
				else
					onLadderTop = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		GameObject gameObject = coll.gameObject;
		if (gameObject.tag == "HardFloor" || gameObject.tag == "Floor") {
			hasWallOnRight = false;
			hasWallOnLeft = false;
			onFloor = false;
		} else if (gameObject.tag == "Ladder") {
			onLadder = false;
			Ladder ladder = gameObject.GetComponent<Ladder>();
			if (ladder.isTopLadder 
			    && transform.position.y > gameObject.transform.position.y
			    && Mathf.Abs(transform.position.x - gameObject.transform.position.x) < 0.32f) {
				onLadderTop = true;
				Vector3 pos = transform.position;
				pos.y = gameObject.transform.position.y + 0.32f;
				transform.position = pos;
			}
		}
	}
}
