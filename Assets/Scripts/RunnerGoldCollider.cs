using UnityEngine;
using System.Collections;

public class RunnerGoldCollider : MonoBehaviour {
	GoldCollector goldCollector;
	People people;
	void Start() {
		goldCollector = Camera.main.GetComponent<GoldCollector> ();
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (people == null) {
			people = gameObject.GetComponentInParent<People> ();
		}
		if (people.tag == "Player" && coll.gameObject.tag == "Gold") {
			goldCollector.collectGold();
			Destroy(coll.gameObject);
		} else if (people.tag == "Chaser" && coll.gameObject.tag == "Gold") {
			(people as Chaser).collectGold();
			Destroy(coll.gameObject);
		}
	}
}
