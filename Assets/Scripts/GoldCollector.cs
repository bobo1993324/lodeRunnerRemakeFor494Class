using UnityEngine;
using System.Collections;

public class GoldCollector : MonoBehaviour {
	public int collectedGold = 0;
	public int totalGold = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void collectGold() {
		collectedGold ++;
		if (collectedGold == totalGold) {
			GameObject[] hiddenLadders = GameObject.FindGameObjectsWithTag("HiddenLadder");
			foreach (GameObject hiddenLadder in hiddenLadders) {
				hiddenLadder.GetComponent<HiddenLadder>().show();
			}
			Debug.Log("Hide");
		}
	}
}
