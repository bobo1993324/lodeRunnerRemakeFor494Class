using UnityEngine;
using System.Collections;

public class RunnerLeftWallCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (people != null) {
			if ((coll.gameObject.tag == "Floor" 
			     && coll.gameObject.GetComponent<Floor>().digState() == 0) 
			    || coll.gameObject.tag == "HardFloor") {
				people.wallOnLeft.Add(coll.gameObject);
			}
			if (people.tag == "Chaser" && coll.gameObject.tag == "Chaser" 
			    && coll.gameObject.GetComponentInChildren<RunnerLeftWallCollider>() != this) {
				people.wallOnLeft.Add(coll.gameObject);
			}
		}
	}
    
	void OnTriggerExit2D(Collider2D coll) {
		people.wallOnLeft.Remove (coll.gameObject);
	}
}
