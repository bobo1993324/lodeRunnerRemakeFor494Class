using UnityEngine;
using System.Collections;

public class HiddenLadder : MonoBehaviour {
	public bool shown = false;
	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		gameObject.renderer.GetComponent<BoxCollider2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void show() {
		shown = true;
		gameObject.renderer.enabled = true;
		gameObject.renderer.GetComponent<BoxCollider2D> ().enabled = true;
	}
}
