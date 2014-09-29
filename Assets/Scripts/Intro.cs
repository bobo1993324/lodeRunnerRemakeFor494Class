using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public Texture t;
	void Start() {
		gameObject.camera.pixelRect = new Rect (0, 0, 640, 480);
	}
	void Update() {
		if (Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Z)) {
			Application.LoadLevel("Level1");
		}
	}
}
