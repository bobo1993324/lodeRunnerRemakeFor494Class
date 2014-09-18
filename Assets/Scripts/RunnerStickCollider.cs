using UnityEngine;
using System.Collections;

public class RunnerStickCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Stick") {
			people.onStickCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Stick") {
			people.onStickCount --;
		}
	}
}
