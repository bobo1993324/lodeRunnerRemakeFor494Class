using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public AudioSource inGameSound;
	GameObject runner;
	public float previewSpeed = 1f;
	public float boundingWidth = 9f;
	public float YboundingWidth = 9f;
	GenerateMap map;
	public int state = 0; //0 for get ready, 1 : game play
	int animateState = 0;//0: center, 1: go right, 2: go left
	float lowerBound = 8f;
	float RightPreviewBoarder = 11.5f;
	float LeftPreviewBoarder = 10.5f;
	void Start() {
		if (map == null) {
			map = GetComponent<GenerateMap>();
			if (map.mapName == "custom") {
				lowerBound = 8f;
				Vector3 pos = transform.position;
				pos.y = 12.5f;
				pos.x = 16.5f;
				transform.position = pos;
				Camera.main.orthographicSize = 12.5f;
				RightPreviewBoarder = 17.5f;
				LeftPreviewBoarder = 16.5f;
				//previewSpeed = 0.3f;
			}
			if (map.mapName == "1") {
				lowerBound = transform.position.y;
			}
		}

	}
	void Update() {
		if (state == 0) { // Get ready
			if (map != null) {
				Vector3 position;
				switch (animateState) {
				case 0: 
					animateState = 1;
					break;
				case 1:
					position = transform.position;
					position.x += previewSpeed * Time.deltaTime;
					transform.position = position;
					if (position.x > map.width - RightPreviewBoarder) {
						animateState = 2;
					}
					break;
				case 2:
					position = transform.position;
					position.x -= previewSpeed * Time.deltaTime;
					transform.position = position;
					if (position.x < LeftPreviewBoarder) {
						state = 1;
						inGameSound.Play();
						animateState = 0;
					}
					break;
				}
			}
			if (animateState == 0) {
				Vector3 pos = transform.position;
				pos.y = 8f;
				transform.position = pos;
				Camera.main.orthographicSize = 8f;
			}
		}
		if (state == 1) {
			if (runner == null) {
				runner = GetComponent<GenerateMap>().getPlayer();
			}
			if (runner != null) {
				Vector3 pos = transform.position;
				if (pos.x < runner.transform.position.x - boundingWidth / 2 ) {
					pos.x = runner.transform.position.x - boundingWidth / 2;
				}
				if (pos.x > runner.transform.position.x + boundingWidth / 2) {
					pos.x = runner.transform.position.x + boundingWidth / 2;
				}
				if (pos.x < 10.5f) {
					pos.x = 10.5f;
				}
				if (pos.x > map.width - 11.5f) {
					pos.x = map.width - 11.5f;
				}

				if (pos.y < runner.transform.position.y - boundingWidth / 2 ) {
					pos.y = runner.transform.position.y - boundingWidth / 2;
				}
				if (pos.y > runner.transform.position.y + boundingWidth / 2) {
					pos.y = runner.transform.position.y + boundingWidth / 2;
				}
					if (pos.y < lowerBound) {
						pos.y = lowerBound;
					}
					if (pos.y > map.height - lowerBound) {
						pos.y = map.height - lowerBound;
					}

				//if (pos.y < runner.transform.position.y - boundingWidth / 2)
				//pos.y = runner.transform.position.y;
				transform.position = pos;
			}
		}
	}
}
