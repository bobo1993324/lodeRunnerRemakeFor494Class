using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {
	private float waitLength;
	public bool disableForChaser = false;
	public void disableCollectForSeconds(float seconds) {
		disableForChaser = true;
		waitLength = seconds;
		StartCoroutine ("waitAndEnable");
	}
	IEnumerator waitAndEnable() {
		yield return new WaitForSeconds(waitLength);
		disableForChaser = false;
	}
}
