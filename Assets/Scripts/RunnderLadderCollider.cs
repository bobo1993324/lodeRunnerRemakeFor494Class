using UnityEngine;
using System.Collections;

public class RunnderLadderCollider : MonoBehaviour {
	GoldCollector goldCollector;
	People people;
	void Start() {
		goldCollector = Camera.main.GetComponent<GoldCollector> ();
		people = gameObject.GetComponentInParent<People> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "LadderWhole") {
			people.onLadderCount ++;
		} else if (people.tag == "Player" && coll.gameObject.tag == "Gold") {
			goldCollector.collectGold();
			Destroy(coll.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.name == "LadderWhole") {
			people.onLadderCount --;
		}
	}
}
