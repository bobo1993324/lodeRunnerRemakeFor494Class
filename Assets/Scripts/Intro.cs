using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	void Start() {
		PlayerPrefs.SetInt ("life", 5);
		PlayerPrefs.SetString ("currentLevel", "1");
	}
	void Update() {
		if (Input.GetKey (KeyCode.S)) {
			Application.LoadLevel("ShowLifeAtStart");
		}
	}
}
