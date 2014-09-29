using UnityEngine;
using System.Collections;

public class LevelStore {
	static string[] availableLevels = {"1", "custom"};
	static public void loadNextLevel() {
		string currentLevel = PlayerPrefs.GetString ("currentLevel");
		int currentIndex = 0;
		for (int i = 0; i < availableLevels.Length; i++) {
			if (currentLevel == availableLevels[currentIndex]) {
			    currentIndex = i;
				break;
			}
		}
		currentIndex ++;
		if (currentIndex == availableLevels.Length) {
			currentIndex = 0;
		}
		PlayerPrefs.SetString ("currentLevel", availableLevels [currentIndex]);
		Application.LoadLevel ("ShowLifeAtStart");
	}

}
