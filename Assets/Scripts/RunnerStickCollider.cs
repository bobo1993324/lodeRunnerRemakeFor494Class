using UnityEngine;
using System.Collections;

public class RunnerStickCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Stick") {
			run.onStickCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Stick") {
			run.onStickCount --;
		}
	}
}
