using UnityEngine;
using System.Collections;

public class CompleteAnimation : MonoBehaviour {
	public float speed;
	// Use this for initialization

	bool animationDone = false;
	bool startFlip = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.localPosition;
		if (position.y < 2) {
			position.y += speed * Time.deltaTime;
		} else {
			if (!animationDone) {
				StartCoroutine("switchScene");
				animationDone = true;
			} 
			if (!startFlip){
				StartCoroutine("flipRunner");
				startFlip = true;
			}
		}
		transform.localPosition = position;

	}

	IEnumerator switchScene() {
		yield return new WaitForSeconds (4);
		LevelStore.loadNextLevel ();
	}

	IEnumerator flipRunner() {
		while (animationDone) {
			yield return new WaitForSeconds (0.4f);
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}
}
