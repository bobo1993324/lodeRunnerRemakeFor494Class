using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
	private float waitLength;
	public void disableCollectForSeconds(float seconds) {
		GetComponent<BoxCollider2D> ().enabled = false;
		waitLength = seconds;
		StartCoroutine ("waitAndEnable");
	}
	IEnumerator waitAndEnable() {
		yield return new WaitForSeconds(waitLength);
		GetComponent<BoxCollider2D> ().enabled = true;
	}
}
