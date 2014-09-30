using UnityEngine;
using System.Collections;

public class RunnerLadderDownCollider : MonoBehaviour {
	People people;
	void Start() {
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ladder") {
			people.onLadderDownCount ++;
		} else if (coll.gameObject.tag == "HiddenLadder" && coll.gameObject.GetComponent<HiddenLadder>().shown) {
			people.onLadderDownCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ladder") {
			people.onLadderDownCount --;
		} else if (coll.gameObject.tag == "HiddenLadder" && coll.gameObject.GetComponent<HiddenLadder>().shown) {
			people.onLadderDownCount --;
		}
	}
}
