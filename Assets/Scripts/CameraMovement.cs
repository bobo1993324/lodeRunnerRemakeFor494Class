using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	GameObject runner;
	// Update is called once per frame
	public float XRightRange;
	public float XLeftRange;
	public float YTopRange;
	public float YBottonRange;
	public float StartX;
	public float StartY;
	public float CameraFollowDistance;
	void Start() {
		Vector3 pos = new Vector3 (StartX, StartY, transform.position.z);
		transform.position = pos;
	}

	void Update() {
		if (runner == null) {
			runner = GetComponent<GenerateMap>().getPlayer();
		}
		if (runner != null) {
			Vector3 pos = transform.position;
			Vector3 runnerPos = runner.transform.position;
			if ( runnerPos.x <= XRightRange && runnerPos.x >= XLeftRange ){
				if (Mathf.Abs(pos.x - runnerPos.x) >= CameraFollowDistance) {
					if (runnerPos.x > pos.x) {
						pos.x = runnerPos.x - CameraFollowDistance;
					}else if (runnerPos.x < pos.x){
						pos.x = runnerPos.x + CameraFollowDistance;
					}
				}
			}
			if ( runnerPos.y <= YTopRange && runnerPos.y >= YBottonRange ){
				pos.y = runnerPos.y;
			}
			transform.position = pos;
		}
	}
}
