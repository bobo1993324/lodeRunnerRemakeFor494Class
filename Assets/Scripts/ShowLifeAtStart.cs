using UnityEngine;
using System.Collections;

public class ShowLifeAtStart : MonoBehaviour {
	public GUIText textt;
	public string testCurrentLevel;
	public int testLife;
	// Use this for initialization
	void Start () {
		StartCoroutine ("startGameAfter3Seconds");
	}
	IEnumerator startGameAfter3Seconds() {
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Level1");
	}
	// Update is called once per frame
	void Update () {
		string currentLevel = PlayerPrefs.GetString ("currentLevel");
		if (currentLevel == "") {
			currentLevel = testCurrentLevel;
		}
		int life = PlayerPrefs.GetInt ("life");
		if (life == 0) {
			life = testLife;
		}
		textt.text = "Level " + currentLevel + "        Life " + life;
	}

}
