using UnityEngine;
using System.Collections;

public class RunnerLadderCenterCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag.Contains("Ladder")) {
			people.onLadderCenterCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag.Contains("Ladder")) {
			people.onLadderCenterCount --;
		}
	}

}
