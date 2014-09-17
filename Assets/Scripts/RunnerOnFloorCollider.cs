using UnityEngine;
using System.Collections;

public class RunnerOnFloorCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			run.onFloorCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			run.onFloorCount --;
		}
	}
}
