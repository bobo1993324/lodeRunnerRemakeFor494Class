using UnityEngine;
using System.Collections;

public class RunnerOnFloorCollider : MonoBehaviour {
	People people;
	void Start() {
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (people == null) {
			people = gameObject.GetComponentInParent<People> ();
		}
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			people.addFloor(coll.gameObject);
		} else if ((coll.gameObject.tag == "ChaserDugFloor" && gameObject.GetComponentInParent<Chaser>() != null)) {
			Chaser chaser = gameObject.GetComponentInParent<Chaser>();
			chaser.dropToPit();
		} else if (coll.gameObject.name == "DropAllGoldFloorCollider" && people.tag == "Chaser") {
			(people as Chaser).dropAllGold();
		}
//		else if (coll.gameObject.tag == "Chaser" 
//		           && coll.gameObject.GetComponentInChildren<RunnerOnFloorCollider>() != this
//		           && !coll.gameObject.GetComponent<Chaser>().inPit) {
//			people.addFloor(coll.gameObject);
//		}

	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Floor" 
		    || coll.gameObject.tag == "HardFloor") {
			people.removeFloor(coll.gameObject);
		}
	}
}
