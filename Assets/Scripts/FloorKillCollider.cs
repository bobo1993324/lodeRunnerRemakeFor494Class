using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorKillCollider : MonoBehaviour {
	public List<GameObject> goInKillRange = new List<GameObject>();
	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("add kill" + coll.gameObject.tag + " " + coll.gameObject.name);
		if (coll.gameObject.tag == "Player"
		    || coll.gameObject.tag == "Chaser") {
			Debug.Log ("add complete");
			goInKillRange.Add(coll.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D coll) {
		goInKillRange.Remove (coll.gameObject);
	}
	public void kill() {
		Debug.Log ("kill " + goInKillRange.Count);
		if (goInKillRange.Count > 0) {
			goInKillRange[0].GetComponent<People>().die();
		}
	}
}
