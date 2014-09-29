using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public AudioSource inGameSound;
	GameObject runner;
	public int pixelWidth;
	public int pixelHeight;
	public float previewSpeed = 1f;
	public float boundingWidth = 9f;
	GenerateMap map;
	// Update is called once per frame
	public int state = 0; //0 for get ready, 1 : game play
	int animateState = 0;//0: center, 1: go left, 2: go right
	void Start() {
	}
	void Update() {
		if (state == 0) { // Get ready
			if (map == null) {
				map = GetComponent<GenerateMap>();
			}
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
					if (position.x > map.width - 8.5f) {
						animateState = 2;
					}
					break;
				case 2:
					position = transform.position;
					position.x -= previewSpeed * Time.deltaTime;
					transform.position = position;
					if (position.x < 7.5f) {
						state = 1;
						inGameSound.Play();
					}
					break;
				}
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
				if (pos.x < 7.5f) {
					pos.x = 7.5f;
				}
				if (pos.x > map.width - 8.5f) {
					pos.x = map.width - 8.5f;
				}
			}
				transform.position = pos;
			}
		}
	}
}
