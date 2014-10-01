using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class People : MonoBehaviour {
	public float runSpeed = 4;
	public float climbSpeed = 4;
	public float fallspeed = 4;

	public int onLadderCenterCount = 0;
	public int onLadderDownCount = 0;
	public int onLadderCount = 0;
	public int onStickCount = 0;

	public List<GameObject> floors = new List<GameObject> ();
	public List<GameObject> wallOnLeft = new List<GameObject> ();
	public List<GameObject> wallOnRight = new List<GameObject> ();
	public List<GameObject> topWalls = new List<GameObject>();
	public List<People> distoyableRegistedList = new List<People>();

	protected GenerateMap map;
	protected bool updateDisabled = false;
	protected bool isFalling = false;
	public void registerDependantTrigger(People go) {
		distoyableRegistedList.Add (go);
	}
	public void unregisterDependantTrigger(People go) {
		distoyableRegistedList.Remove (go);
	}
	protected void Start() {
		map = Camera.main.GetComponent<GenerateMap> ();
	}
	protected bool onFloor() {
		return floors.Count > 0;
	}
	bool hasWallOnRight() {
		return wallOnRight.Count > 0;
	}
	bool hasWallOnLeft() {
		return wallOnLeft.Count > 0;
	}
	bool onStick() {
		return onStickCount > 0;
	}
	protected bool onLadderCenter() {
		return onLadderCenterCount > 0;
	}
	protected bool canGoDown() {
		return (onLadderDownCount + onLadderCenterCount> 0 || onStick()) && !onFloor () ;
	}
	
	// Update is called once per frame
	protected void Update () {
		if (Camera.main.GetComponent<CameraMovement>().state == 0) {
			return;
		};
		if (updateDisabled) {
			return;
		}
		if (onStick() || onFloor()) {
			adjustVerticalPosition();
		}
		if (hasWallOnLeft () && transform.position.x < Mathf.Round(transform.position.x)) {
			adjustHorizontalPosition();
		}
		if (hasWallOnRight () && transform.position.x > Mathf.Round(transform.position.x)) {
			adjustHorizontalPosition();
		}

		//TODO disable  falling at start when the maps is still in construction
		if (!onFloor() && onLadderCount + onLadderDownCount == 0 
		    && !onStick() ) {
			//falling
			Vector3 previousPosition = transform.position;
			previousPosition.y -= fallspeed * Time.deltaTime;
			transform.position = previousPosition;
			isFalling = true;
			return;
		} else {
			isFalling = false;
		}
		Vector2 movement = decideMovement ();
		Debug.Log("movement" + movement.y + " " + movement.x);
		float horizontalMoveDistance = movement.x * runSpeed * Time.deltaTime;
		bool stopByWall = (hasWallOnLeft() && horizontalMoveDistance < 0) 
			|| (hasWallOnRight() && horizontalMoveDistance > 0); 
		if (!stopByWall) { 
			Vector3 previousPosition = transform.position;
			previousPosition.x += horizontalMoveDistance;
			transform.position = previousPosition;
		}
		
		float verticalMoveDistance = movement.y * climbSpeed * Time.deltaTime;
		if (verticalMoveDistance < 0 && canGoDown()) {
			Vector3 previousPosition = transform.position;
			if (onStick()) {
				previousPosition.y -= 0.3f;
			} else {
				previousPosition.x += (Mathf.Round(previousPosition.x) -previousPosition.x ) / 3;
				previousPosition.y += verticalMoveDistance;
			}
			transform.position = previousPosition;
		} else if (verticalMoveDistance > 0 && onLadderCenterCount > 0 && topWalls.Count == 0) {
			Vector3 previousPosition = transform.position;
			previousPosition.x += (Mathf.Round(previousPosition.x) -previousPosition.x ) / 3;
			previousPosition.y += verticalMoveDistance;
			transform.position = previousPosition;
		} 
	}
	
	void adjustHorizontalPosition() {
		Vector3 previousPosition = transform.position;
		previousPosition.x += (Mathf.Round(previousPosition.x) - previousPosition.x) / 3;
		transform.position = previousPosition;
	}
	
	void adjustVerticalPosition() {
		Vector3 previousPosition = transform.position;
		previousPosition.y += (Mathf.Round(previousPosition.y) - previousPosition.y) / 3;
		transform.position = previousPosition;
	}
	public void addFloor(GameObject go) {
		floors.Add (go);
	}
	public void removeFloor(GameObject go) {
		floors.Remove (go);
	}
	protected void notifyDistroyed() {
		for (int i = 0; i < this.distoyableRegistedList.Count; i++) { 
			distoyableRegistedList[i].GetComponentInParent <People>().floorChaserDistroyed(this.GetComponentInChildren<ChaserTopCollider>().gameObject);
		}
	}
	public void floorChaserDistroyed(GameObject go) {
		Debug.Log ("chaser at bottom distroyed, remove " + go.GetInstanceID ());
		floors.Remove (go);
	}
	public abstract Vector2 decideMovement();
	public abstract void die();
}
