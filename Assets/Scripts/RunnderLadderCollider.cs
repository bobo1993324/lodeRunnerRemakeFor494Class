using UnityEngine;
using System.Collections;

public class RunnderLadderCollider : MonoBehaviour {
	People people;
	void OnTriggerEnter2D(Collider2D coll) {
		if (people == null) {
			people = gameObject.GetComponentInParent<People> ();
		}
		if (coll.gameObject.name == "LadderWhole") {
			people.onLadderCount ++;
		} if (coll.gameObject.name == "LadderWholeHidden" && coll.gameObject.GetComponentInParent<HiddenLadder> ().shown) {
			people.onLadderCount ++;	
		} else if (coll.gameObject.tag == "Chaser" && people.tag == "Player"
		           && !coll.gameObject.GetComponent<Chaser>().inPit) {
			people.die();
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.name == "LadderWhole") {
			people.onLadderCount --;
		} if (coll.gameObject.name == "LadderWholeHidden" && coll.gameObject.GetComponentInParent<HiddenLadder> ().shown) {
			people.onLadderCount --;	
		}
	}
}
