using UnityEngine;
using System.Collections;

public class RunnerLadderDownCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Ladder") {
			run.onLadderDownCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag == "Ladder") {
			run.onLadderDownCount --;
		}
	}
}
