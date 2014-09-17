using UnityEngine;
using System.Collections;

public class RunnerLadderCenterCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag.Contains("Ladder")) {
			run.onLadderCenterCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag.Contains("Ladder")) {
			run.onLadderCenterCount --;
		}
	}

}
