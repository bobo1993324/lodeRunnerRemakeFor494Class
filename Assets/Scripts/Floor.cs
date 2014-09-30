using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	Animator animator;
	void Start() {
		animator = GetComponent<Animator> ();
	}
	public int digState() {
		if (animator == null) {
			animator = GetComponent<Animator> ();
		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
			return 0;
		} else if (animator.GetCurrentAnimatorStateInfo(0).IsName("floorAnimation")) {
			return 1;
		} else if (animator.GetCurrentAnimatorStateInfo(0).IsName("floorDistroyd")) {
			return 2;
		} else if (animator.GetCurrentAnimatorStateInfo(0).IsName("floorHealing")) {
			return 3;
		} else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Kill")) {
			return 4;
		}
		return animator.GetInteger ("state");
	}
	public void dig() {
		//start dig animation
		StopCoroutine ("unsetState");
		animator.SetInteger ("state", 1);
		StartCoroutine ("unsetState");
	}
	IEnumerator unsetState() {
		while(digState() != 4) {
			yield return new WaitForSeconds (0.3f);
		}
		gameObject.GetComponentInChildren<FloorKillCollider> ().kill ();
		animator.SetInteger ("state", 0);

	}
	public bool fallTrough() {
		return (digState() == 2 || digState() == 3) && !containPeople();
	}

	public bool containPeople () {
		return GetComponentInChildren<FloorKillCollider> ().goInKillRange.Count > 0;
	}
	public bool containPeople(GameObject me) {
		return GetComponentInChildren<FloorKillCollider>().goInKillRange.Contains(me);
	}
}
