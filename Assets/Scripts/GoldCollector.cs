using UnityEngine;
using System.Collections;

public class GoldCollector : MonoBehaviour {
	public int collectedGold = 0;
	public int totalGold = 0;

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
	public void addGoldToCollect() {
		totalGold ++;
	}
}
