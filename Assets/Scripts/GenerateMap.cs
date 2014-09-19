using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour {
	public string mapName;
	public GameObject floorPrefab;
	public GameObject goldPrefab;
	public GameObject hardFloorPrefab;
	public GameObject ladderPrefab;
	public GameObject stickPrefab;
	public GameObject runnerPrefab;
	public GameObject chaserPrefab;
	public GameObject hiddenLadderPrefab;
	public int width;
	public int height;

	private Dictionary<string, GameObject> tilePrefabDictionary;
	private GameObject[,] gameObjectMatrix;
	private System.Random rand = new System.Random ();

	public GameObject getObjectAt(int x, int y) {
		return gameObjectMatrix [x, y];
	}
	public GameObject getPlayer() {
		for (int i = 0; i < gameObjectMatrix.GetLength(0); i++) {
			for (int j = 0; j < gameObjectMatrix.GetLength(1); j++) {
				if (gameObjectMatrix[i, j] != null && gameObjectMatrix[i, j].tag == "Player") {
					return gameObjectMatrix[i, j];
				}
			}
		}
		return null;
	}
	public List<GameObject> getLaddersAtHeight(int y) {
		List<GameObject> result = new List<GameObject>();
		for(int i = 0; i < gameObjectMatrix.GetLength(0); i++) {
			if (gameObjectMatrix[i, y] != null && gameObjectMatrix[i, y].tag == "Ladder") {
				result.Add(gameObjectMatrix[i, y]);
			}
		}
		return result;
	}
	public void respawnEnermy() {
		while (true) {
			int targetY = height - 1;
			int targetX = rand.Next (1, width - 1);
			if (gameObjectMatrix[targetX, targetY] == null) {
				Instantiate(chaserPrefab,
				            new Vector2(targetX, targetY),
				            Quaternion.identity);
				return;
			}
		}
	}
	// Use this for initialization
	void Start () {
		tilePrefabDictionary = new Dictionary<string, GameObject> ();
		tilePrefabDictionary ["floor"] = floorPrefab;
		tilePrefabDictionary ["gold"] = goldPrefab;
		tilePrefabDictionary ["hard floor"] = hardFloorPrefab;
		tilePrefabDictionary ["ladder"] = ladderPrefab;
		tilePrefabDictionary ["stick"] = stickPrefab;
		tilePrefabDictionary ["runner"] = runnerPrefab;
		tilePrefabDictionary ["chaser"] = chaserPrefab;
		tilePrefabDictionary ["hiddenLadder"] = hiddenLadderPrefab;
		loadMap ();
	}

	private void loadMap() {
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.Load ("Assets/Maps/" + mapName + ".tmx");
		XmlNodeList tilesetList = xmlDoc.GetElementsByTagName ("tileset");
		Dictionary<string, string> tileMap = new Dictionary<string, string>();
		foreach (XmlNode tileset in tilesetList) {
			tileMap[tileset.Attributes["firstgid"].Value]
			        = tileset.Attributes["name"].Value;
		}
		XmlNodeList layerList = xmlDoc.GetElementsByTagName("layer");
		foreach (XmlNode layer in layerList) {
			width = int.Parse(layer.Attributes["width"].Value);
			height = int.Parse(layer.Attributes["height"].Value);
			gameObjectMatrix = new GameObject[width, height];
			XmlNodeList tilesList = layer.ChildNodes[0].ChildNodes;
			for (int i = 0; i < tilesList.Count; i++) {
				int x = i % width;
				int y = 14 - i / width;
				string gid = tilesList[i].Attributes["gid"].Value;
				if (gid != "0") {
					string tileName = tileMap[tilesList[i].Attributes["gid"].Value];
					GameObject go =	Instantiate(tilePrefabDictionary[tileName],
					            new Vector2(x, y),
					            Quaternion.identity) as GameObject;
					if (go.tag != "Chaser") {
						gameObjectMatrix[x, y] = go;
					}
				}
			}
		}
	}
}
