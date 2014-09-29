using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("startOver");
	}
	IEnumerator startOver() {
		yield return new WaitForSeconds (2);
		Application.LoadLevel ("Intro");
	}
}
