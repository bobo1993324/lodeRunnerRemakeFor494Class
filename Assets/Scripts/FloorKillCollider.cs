using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorKillCollider : MonoBehaviour {
	public List<GameObject> goInKillRange = new List<GameObject>();
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player"
		    || coll.gameObject.tag == "Chaser") {
			if (GetComponentInParent<Floor>().digState() != 0) {
				Debug.Log (gameObject.GetInstanceID() + "add complete" + coll.gameObject.GetInstanceID());
				goInKillRange.Add(coll.gameObject);
			}
		}
	}
	void OnTriggerExit2D(Collider2D coll) {
		goInKillRange.Remove (coll.gameObject);
	}
	public void kill() {
		Debug.Log ("kill " + goInKillRange.Count);
		for (int i = 0; i < goInKillRange.Count; i++) {
			Debug.Log(i + " " + goInKillRange[i].GetInstanceID());
		}
		if (goInKillRange.Count > 0) {
			goInKillRange[0].GetComponent<People>().die();
		}
		goInKillRange.Clear ();
	}
}
