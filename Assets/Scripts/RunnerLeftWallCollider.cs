using UnityEngine;
using System.Collections;

public class RunnerLeftWallCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
		Debug.Log ("OnTriggerEnter2D" + run.wallOnLeftCount);
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			run.wallOnLeftCount ++;
		}
		Debug.Log ("OnTriggerEnter2D2" + run.wallOnLeftCount);
	}
    
	void OnTriggerExit2D(Collider2D coll) {
		Runner run = gameObject.GetComponentInParent<Runner>();
        Debug.Log ("OnTriggerExit2D" + run.wallOnLeftCount);
		if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "HardFloor") {
			run.wallOnLeftCount --;
		}
		Debug.Log ("OnTriggerExit2D2" + run.wallOnLeftCount);
	}
}
