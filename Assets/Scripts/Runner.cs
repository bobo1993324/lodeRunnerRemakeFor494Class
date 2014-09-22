using UnityEngine;
using System.Collections;

public class Runner : People {
	bool isDead = false;
	float nextDigTime = 0;
	new void Update() {
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
			    && (goLeft == null || !goLeft.tag.Contains("Floor"))
			    && Time.time > nextDigTime) {
				centerX();
				goLeftDown.GetComponent<Floor>().dig();
				nextDigTime = Time.time + 0.5f;
				Debug.Log ("nextDigTime " + nextDigTime); 
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
			    && (goRight == null || !goRight.tag.Contains("Floor"))
			    && Time.time > nextDigTime) {
				centerX();
				goRightDown.GetComponent<Floor>().dig();
				nextDigTime = Time.time + 0.5f;
			}
		}
		base.Update ();
	}
	public override Vector2 decideMovement() {
		return new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
	public override void die ()
	{
		if (!isDead) {
			isDead = true;
			gameObject.renderer.enabled = false;
			StartCoroutine ("reloadLevelIn1Second");
		}
	}
	IEnumerator reloadLevelIn1Second() {
		yield return new WaitForSeconds (1);
		Application.LoadLevel (Application.loadedLevel);
		Destroy (gameObject);
	}
	private void centerX() {
		Vector3 p = transform.position;
		p.x = Mathf.Round(p.x);
		transform.position = p;
	}
	
}
