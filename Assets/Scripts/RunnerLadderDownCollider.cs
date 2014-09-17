using UnityEngine;
using System.Collections;

public class RunnerLadderDownCollider : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag.Contains("Ladder")) {
			run.onLadderDownCount ++;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		if (coll.gameObject.tag.Contains("Ladder")) {
			run.onLadderDownCount --;
		}
	}
}
