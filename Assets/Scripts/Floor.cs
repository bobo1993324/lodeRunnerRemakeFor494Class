using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	public float waitTime = 5f;
	public float healTime = 2f;
	enum DigState {
		NORMAL,
		DIGGING,
		DUG,
		HEALING
	}
	DigState digState = DigState.NORMAL;
	public void dig() {
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
