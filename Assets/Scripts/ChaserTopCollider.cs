using UnityEngine;
using System.Collections;

public class ChaserTopCollider : MonoBehaviour {
	Chaser chaser;
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D coll) {
		if (chaser == null) {
			chaser = GetComponentInParent<Chaser>();
		}
		if (chaser != null) {
			if (coll.gameObject.tag == "Chaser" && coll.gameObject.GetComponentInChildren<ChaserTopCollider>() != this) {
				chaser.topWalls.Add(coll.gameObject);
			}
		}
	}
	void OnTriggerExit2D(Collider2D coll) {
		chaser.topWalls.Remove (coll.gameObject);
	}
}
