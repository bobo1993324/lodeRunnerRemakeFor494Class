using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {
	enum DigState {
		NORMAL,
		DUG
	}
	DigState digState = DigState.NORMAL;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void dig() {
		digState = DigState.DUG;
		gameObject.renderer.enabled = false;
	}
	public bool isDug() {
		return digState == DigState.DUG;
	}
}
