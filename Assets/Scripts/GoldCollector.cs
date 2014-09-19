using UnityEngine;
using System.Collections;

public class GoldCollector : MonoBehaviour {
	private int collectedGold = 0;
	private int totalGold = 0;

	public void collectGold() {
		if (collectedGold == totalGold) {
			GameObject[] hiddenLadders = GameObject.FindGameObjectsWithTag("HiddenLadder");
			foreach (GameObject hiddenLadder in hiddenLadders) {
				hiddenLadder.GetComponent<HiddenLadder>().show();
			}
			Debug.Log("Hide");
		}
	}
	public void addGoldToCollect() {
		totalGold ++;
	}
}
