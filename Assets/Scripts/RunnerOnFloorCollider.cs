using UnityEngine;
using System.Collections;

public class RunnerOnFloorCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			people.onFloorCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			people.onFloorCount --;
		}
	}
}
