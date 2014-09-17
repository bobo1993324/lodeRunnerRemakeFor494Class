using UnityEngine;
using System.Collections;

public class RunnderLadderCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.name == "LadderWhole") {
			run.onLadderCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.name == "LadderWhole") {
			run.onLadderCount --;
		}
	}
}
