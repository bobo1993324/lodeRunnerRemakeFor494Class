using UnityEngine;
using System.Collections;

public class RunnerLadderDownCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag.Contains("Ladder")) {
			people.onLadderDownCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag.Contains("Ladder")) {
			people.onLadderDownCount --;
		}
	}
}
