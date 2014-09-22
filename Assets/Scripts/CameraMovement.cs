using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	GameObject runner;
	// Update is called once per frame
	void FixedUpdate() {
		if (runner == null) {
			runner = GetComponent<GenerateMap>().getPlayer();
		}
		if (runner != null) {
			Vector3 pos = transform.position;
			pos.x = runner.transform.position.x;
			pos.y = runner.transform.position.y;
			transform.position = pos;
		}
	}
}
