using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour {
	void OnGUI() {
		GUI.Label (new Rect (100, 100, 300, 30), "Congrat, you have passed Level 1");
		if (GUI.Button(new Rect(100, 200, 100, 50), "Play again")) {
			Application.LoadLevel("Level1");
		}
	}
}
