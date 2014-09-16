using UnityEngine;
using System.Collections;

public class runner : MonoBehaviour {
	public float runSpeed;

	bool hasWallOnRight = false;
	bool hasWallOnLeft = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float moveDistance = Input.GetAxisRaw ("Horizontal") * runSpeed * Time.deltaTime;
		bool stopByWall = (hasWallOnLeft && moveDistance < 0) 
						|| (hasWallOnRight && moveDistance > 0); 
		if (!stopByWall) { 
			Vector3 previousPosition = transform.position;
			previousPosition.x += moveDistance;
			transform.position = previousPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameObject gameObject = coll.gameObject;
		if (gameObject.tag == "HardFloor") {
			if (transform.position.x < gameObject.transform.position.x) {
				hasWallOnRight = true;
			} else {
				hasWallOnLeft = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		GameObject gameObject = coll.gameObject;
		if (gameObject.tag == "HardFloor") {
			if (transform.position.x < gameObject.transform.position.x) {
				hasWallOnRight = false;
			} else {
				hasWallOnLeft = false;
			}
		}
	}
}
