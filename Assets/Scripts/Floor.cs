using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	public float waitTime = 5f;
	public float healTime = 2f;
	public int digHPMax = 2;
	public int digHP;
	private bool dugByPlayerInLastSecond = false;
	private bool coroutineStarted = false;
	enum DigState {
		NORMAL,
		DIGGING,
		DUG,
		HEALING
	}
	DigState digState = DigState.NORMAL;
	public void dig() {
		dugByPlayerInLastSecond = true;
		if (!coroutineStarted) {
			coroutineStarted = true;
			digHP = digHPMax;
			digHP --;
			StartCoroutine("digging");
		}
	}
	IEnumerator digging() {
		while (digHP > 0) {
			dugByPlayerInLastSecond = false;
			yield return new WaitForSeconds (1);
			Debug.Log ("dig " + dugByPlayerInLastSecond + digHP); 
			if (dugByPlayerInLastSecond == true) {
				digHP --;
			} else {
				digHP ++;
			}
			if (digHP >= digHPMax) {
				digState = DigState.NORMAL;
				coroutineStarted = false;
				return false;
			}
		}
		digComplete ();
		coroutineStarted = false;
	}
	private void digComplete() {
		Debug.Log ("dig complete");
		StopCoroutine ("waitForHealing");
		digState = DigState.DUG;
		gameObject.renderer.enabled = false;
		StartCoroutine ("waitForHealing");
	}
	public bool isDug() {
		return digState == DigState.DUG;
	}
	IEnumerator waitForHealing() {
		yield return new WaitForSeconds(this.waitTime);
		digState = DigState.HEALING;
		yield return new WaitForSeconds(this.healTime);
		digState = DigState.NORMAL;
		gameObject.renderer.enabled = true;
		gameObject.GetComponentInChildren<FloorKillCollider> ().kill ();
	}
}
