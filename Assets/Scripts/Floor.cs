using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	public float waitTime = 5f;
	public float healTime = 2f;
	public int digHPMax = 2;
	public int digHP;
	private bool dugByPlayerInLastSecond = false;
	private bool coroutineStarted = false;
	public enum DigState {
		NORMAL,
		DIGGING,
		DUG,
		HEALING
	}
	public DigState digState = DigState.NORMAL;
	public void dig() {
		dugByPlayerInLastSecond = true;
		digHP --;
		if (digHP == 0) {
			digComplete();
			StopCoroutine("digging");
			coroutineStarted = false;
		}
		if (!coroutineStarted) {
			coroutineStarted = true;
			StartCoroutine("digging");
		}
	}
	IEnumerator digging() {
		while (digHP > 0) {
			dugByPlayerInLastSecond = false;
			yield return new WaitForSeconds (0.7f);
			Debug.Log ("dig " + dugByPlayerInLastSecond + digHP); 
			if (!dugByPlayerInLastSecond) {
				digHP ++;
			}
			if (digHP >= digHPMax) {
				digState = DigState.NORMAL;
				coroutineStarted = false;
				return false;
			}
		}
	}
	private void digComplete() {
		Debug.Log ("dig complete");
		StopCoroutine ("waitForHealing");
		digState = DigState.DUG;
		gameObject.renderer.enabled = false;
		StartCoroutine ("waitForHealing");
	}
	public bool fallTrough() {
		return (digState == DigState.DUG || digState == DigState.HEALING) && !containPeople();
	}
	IEnumerator waitForHealing() {
		yield return new WaitForSeconds(this.waitTime);
		digState = DigState.HEALING;
		yield return new WaitForSeconds(this.healTime);
		digState = DigState.NORMAL;
		gameObject.renderer.enabled = true;
		digHP = digHPMax;
		gameObject.GetComponentInChildren<FloorKillCollider> ().kill ();
	}
	public bool containPeople () {
		return GetComponentInChildren<FloorKillCollider> ().goInKillRange.Count > 0;
	}
	public bool containPeople(GameObject me) {
		return GetComponentInChildren<FloorKillCollider>().goInKillRange.Contains(me);
	}
}
