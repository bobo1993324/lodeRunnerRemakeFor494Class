using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	void OnGUI() {
		GUI.Label(new Rect(100, 100, 300, 40), "Load Runner");
		GUI.Label(new Rect(100, 140, 300, 40), 
		          @"Controls: arrows for moving up and down.\n
key z and key x digs holes. R for restart level
");
		if (GUI.Button(new Rect(200, 200, 100, 50), "Level 1")) {
			Application.LoadLevel("Level1");
		}
	}
}
