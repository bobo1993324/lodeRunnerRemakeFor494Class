using UnityEngine;
using System.Collections;

public class completeGameCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Application.LoadLevel("Complete");
		}
	}
}
