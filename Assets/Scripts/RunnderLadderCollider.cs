using UnityEngine;
using System.Collections;

public class RunnderLadderCollider : MonoBehaviour {
	GoldCollector goldCollector;
	void Start() {
		goldCollector = Camera.main.GetComponent<GoldCollector> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.name == "LadderWhole") {
			run.onLadderCount ++;
		} else if (coll.gameObject.tag == "Gold") {
			goldCollector.collectGold();
			Destroy(coll.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.name == "LadderWhole") {
			run.onLadderCount --;
		}
	}
}
