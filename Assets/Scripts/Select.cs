﻿using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
	public GUIText selectText;
	string[] level = {"1", "custom"};
	int selectedIndex = 0;
	// Use this for initialization
	void Start () {
		selectText.text = "Select Level " + level [selectedIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			selectedIndex ++;
			if (selectedIndex >= level.GetLength(0)) {
				selectedIndex = 0;
			}
			selectText.text = "Select Level " + level [selectedIndex];
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			PlayerPrefs.SetString("currentLevel", level [selectedIndex]);
			Application.LoadLevel ("Level1");
		}
	}
}
