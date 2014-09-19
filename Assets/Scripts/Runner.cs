using UnityEngine;
using System.Collections;

public class Runner : People {
	void Update() {
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
				goLeftDown.GetComponent<Floor>().dig();
			}
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
				goRightDown.GetComponent<Floor>().dig();
			}
		}
		base.Update ();
	}
	public override Vector2 decideMovement() {
		return new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
	public override void die ()
	{
		Destroy (gameObject);
		//TODO start again
	}
}
