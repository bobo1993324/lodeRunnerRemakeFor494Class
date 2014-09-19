using UnityEngine;
using System.Collections;

public class RunnerOnFloorCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			people.addFloor(coll.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			people.removeFloor(coll.gameObject);
		}
	}
}
