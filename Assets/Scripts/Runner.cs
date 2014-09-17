using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public float runSpeed = 4;
	public float climbSpeed = 4;
	public float fallspeed = 4;

	public int wallOnRightCount = 0;
	public int wallOnLeftCount = 0;
	public int onFloorCount = 0;
	public int onLadderCenterCount = 0;
	public int onLadderDownCount = 0;
	public int onLadderCount = 0;
	public int onStickCount = 0;

	bool hasWallOnRight() {
		return wallOnRightCount > 0;
	}
	bool hasWallOnLeft() {
		return wallOnLeftCount > 0;
	}
	bool onFloor() {
		return onFloorCount > 0; 
	}
	bool onStick() {
		return onStickCount > 0;
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (onStick()) {
			Vector3 previousPosition = transform.position;
			previousPosition.y = Mathf.Round(previousPosition.y);
			transform.position = previousPosition;
		}

		if (onFloorCount + onLadderCount + onLadderDownCount == 0 
		    	&& !onStick()) {
			//falling
			Vector3 previousPosition = transform.position;
			previousPosition.y -= fallspeed * Time.deltaTime;
			transform.position = previousPosition;
			return;
		}
		float horizontalMoveDistance = Input.GetAxisRaw ("Horizontal") * runSpeed * Time.deltaTime;
		bool stopByWall = (hasWallOnLeft() && horizontalMoveDistance < 0) 
						|| (hasWallOnRight() && horizontalMoveDistance > 0); 
		if (!stopByWall) { 
			Vector3 previousPosition = transform.position;
			previousPosition.x += horizontalMoveDistance;
			transform.position = previousPosition;
		}

		float verticalMoveDistance = Input.GetAxisRaw ("Vertical") * climbSpeed * Time.deltaTime;
		if ((verticalMoveDistance < 0 && onLadderDownCount > 0 && !onFloor())
		    	|| (verticalMoveDistance > 0 && onLadderCenterCount > 0)) {
			Vector3 previousPosition = transform.position;
			previousPosition.x = Mathf.Round(previousPosition.x);
			previousPosition.y += verticalMoveDistance;
			transform.position = previousPosition;
		} else if (verticalMoveDistance < 0 && onStick() && !onFloor()) {
			Vector3 previousPosition = transform.position;
			previousPosition.y -= 0.3f;
			transform.position = previousPosition;
		}
	}
}
