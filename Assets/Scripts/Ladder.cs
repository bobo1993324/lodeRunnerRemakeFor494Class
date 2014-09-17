using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	public bool isTopLadder;
	public bool isBottomLadder;
	// Use this for initialization
	void Start () {
		StartCoroutine (CheckPosition());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CheckPosition() {
		yield return new WaitForSeconds(1f);
		isTopLadder = true;
		isBottomLadder = true;
		GameObject[] ladders = GameObject.FindGameObjectsWithTag ("Ladder");
		Vector3 position = transform.position;
		foreach (GameObject ladder in ladders) {
			if (Mathf.Approximately(ladder.transform.position.x, position.x)) {
				if (Mathf.Approximately(ladder.transform.position.y, position.y + 0.32f)) {
					isTopLadder = false;
				}
				if (Mathf.Approximately(ladder.transform.position.y, position.y - 0.32f)) {
					isBottomLadder = false;
				}
			}
		}
	}
}
