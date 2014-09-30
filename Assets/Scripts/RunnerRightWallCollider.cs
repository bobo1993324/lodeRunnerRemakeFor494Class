using UnityEngine;
using System.Collections;

public class RunnerRightWallCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if ((coll.gameObject.tag == "Floor" 
		     && coll.gameObject.GetComponent<Floor>().digState() == 0) 
		    || coll.gameObject.tag == "HardFloor") {
				people.wallOnRightCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if ((coll.gameObject.tag == "Floor" 
		     && coll.gameObject.GetComponent<Floor>().digState() == 0) 
		    || coll.gameObject.tag == "HardFloor") {
				people.wallOnRightCount --;
		}
	}
}
