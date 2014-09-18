using UnityEngine;
using System.Collections;

public class Runner : People {

	public override Vector2 decideMovement() {
		return new Vector2(Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
