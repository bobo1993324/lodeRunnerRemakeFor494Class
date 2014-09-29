using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
	public GUIText selectText;
	string[] level = {"1", "custom"};
	int selectedIndex = 0;
	// Use this for initialization
	void Start () {
		selectText.text = "Select " + level [selectedIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			selectedIndex ++;
			if (selectedIndex >= level.GetLength(0)) {
				selectedIndex = 0;
			}
			selectText.text = "Select " + level [selectedIndex];
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			Application.LoadLevel ("Level" + level [selectedIndex]);
		}
	}
}
