using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class MoveCapability {
	public bool goUp = false;
	public bool goDown = false;
	public bool goLeft = false;
	public bool goRight = false;
}

public enum MoveDirection {
	GO_NONE, GO_LEFT, GO_RIGHT, GO_UP, GO_DOWN
};
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
	public GameObject arrowPrefab;
	public int width;
	public int height;

	private Dictionary<string, GameObject> tilePrefabDictionary;
	public GameObject[,] gameObjectMatrix;
	public MoveCapability[,] moveCapabilityMatrix;
	public Hashtable chaseDirection = new Hashtable();
	private System.Random rand = new System.Random ();
	private GameObject runnerGameObject;

	public GameObject getObjectAt(int x, int y) {
		return gameObjectMatrix [x, y];
	}
	public GameObject getPlayer() {
		return runnerGameObject;
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
		generateChaserPlan ();
	}

	private void loadMap() {
		XmlDocument xmlDoc = new XmlDocument ();
		string currentMap = PlayerPrefs.GetString ("currentLevel");
		if (currentMap != null && currentMap != "") {
			mapName = currentMap;
			Debug.Log("read map from pref " + currentMap);
		}
		if(mapName == "1")
			xmlDoc.LoadXml (new MapLevel1().xml);
		if(mapName == "custom") {
			xmlDoc.LoadXml (new MapCustom().xml);
		}
//		xmlDoc.Load ("./Assets/Maps/Level1.tmx");
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
				int y = height - 1 - i / width;
				string gid = tilesList[i].Attributes["gid"].Value;
				if (gid != "0") {
					string tileName = tileMap[tilesList[i].Attributes["gid"].Value];
					GameObject go =	Instantiate(tilePrefabDictionary[tileName],
					            new Vector2(x, y),
					            Quaternion.identity) as GameObject;
					if (go.tag == "Player") {
						runnerGameObject = go;
					}
					if (go.tag == "Gold") {
						Camera.main.GetComponent<GoldCollector>().addGoldToCollect();
					}
					if (go.tag != "Chaser" && go.tag != "Player" && go.tag != "Gold") {
						gameObjectMatrix[x, y] = go;
					}
				}
			}
		}
	}
	private void generateChaserPlan() {
		moveCapabilityMatrix = new MoveCapability[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				MoveCapability cap = new MoveCapability();
				GameObject currentGo = this.gameObjectMatrix[i, j];
				if (currentGo == null
				    || currentGo.tag == "Gold"
				    || currentGo.tag == "HiddenLadder"
				    || currentGo.tag == "Ladder"
				    || currentGo.tag == "Stick") {
					if (j < height - 1) {
						GameObject upperGo = gameObjectMatrix[i, j + 1];
						if (currentGo != null && currentGo.tag == "Ladder" && 
						    (upperGo == null || !upperGo.tag.Contains("Floor"))) {
							cap.goUp = true;
						}
					}
					if ( j > 0) {
						GameObject lowerGo = gameObjectMatrix[i, j - 1];
						if (lowerGo == null || !lowerGo.tag.Contains("Floor")) {
							cap.goDown = true;
						}
					}
					if (i > 0 && j > 0 ) {
						GameObject leftGo = gameObjectMatrix[i - 1, j];
						GameObject lowerGo = gameObjectMatrix[i, j - 1];
						if (lowerGo != null 
						    && (lowerGo.tag == "Ladder" || lowerGo.tag.Contains("Floor"))
						    && (leftGo == null || !leftGo.tag.Contains("Floor"))) {
							cap.goLeft = true;
						}
						if (currentGo != null && currentGo.tag == "Stick") {
							cap.goLeft = true;
						}
					}
					if (i < width - 1) {
						GameObject rightGo = gameObjectMatrix[i + 1, j];
						GameObject lowerGo = gameObjectMatrix[i, j - 1];
						if (lowerGo != null
							&& (lowerGo.tag == "Ladder" || lowerGo.tag.Contains("Floor"))
						    && (rightGo == null || !rightGo.tag.Contains("Floor"))) {
							cap.goRight = true;
						}
						if (currentGo != null && currentGo.tag == "Stick") {
							cap.goRight = true;
						}
					}
				}
				moveCapabilityMatrix[i, j] = cap;
			}
		}
		//visualize
		/*
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				MoveCapability m = moveCapabilityMatrix[i, j];
				if (m.goUp) {
					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
						.transform.Rotate(0, 0, 90f);
				}
				if (m.goDown) {
					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
						.transform.Rotate(0, 0, -90f);
				}
				if (m.goRight) {
					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
						.transform.Rotate(0, 0, 0);
				}
				
				if (m.goLeft) {
					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
						.transform.Rotate(0, 0, 180);
				}
			}
		}*/
		for (int playerx = 0; playerx < width; playerx++) {
			for (int playery = 0; playery < height; playery++) {
				Queue<int> toVisitQueue = new Queue<int>();
				HashSet<int> visited = new HashSet<int>();
				toVisitQueue.Enqueue(xyKey(playerx, playery));
				while(toVisitQueue.Count > 0) {
					int tmp = toVisitQueue.Dequeue();
					int currentx = tmp >> 8;
					int currenty = tmp & 255;
					visited.Add(xyKey(currentx, currenty));
					if (currentx > 0 && !visited.Contains(xyKey(currentx - 1, currenty))) {
						MoveCapability mc = moveCapabilityMatrix[currentx - 1, currenty];
						int key = chaseDirectionKey(playerx, playery, currentx - 1, currenty);
						if (mc != null && mc.goRight && !chaseDirection.ContainsKey(key)) {
							chaseDirection.Add (key, MoveDirection.GO_RIGHT);
							toVisitQueue.Enqueue(xyKey(currentx - 1, currenty));
						}
					}
					if (currentx < width - 1 && !visited.Contains(xyKey(currentx + 1, currenty))) {
						MoveCapability mc = moveCapabilityMatrix[currentx + 1, currenty];
						int key = chaseDirectionKey(playerx, playery, currentx + 1, currenty);
						if (mc != null && mc.goLeft && !chaseDirection.ContainsKey(key)) {
							chaseDirection.Add(key, MoveDirection.GO_LEFT);
							toVisitQueue.Enqueue(xyKey(currentx + 1, currenty));
						}
					}
					if (currenty > 0 && !visited.Contains(xyKey(currentx, currenty - 1))) {
						MoveCapability mc = moveCapabilityMatrix[currentx, currenty - 1];
						int key = chaseDirectionKey(playerx, playery, currentx, currenty - 1);
						if (mc != null && mc.goUp && !chaseDirection.ContainsKey(key)) {
							chaseDirection.Add(key, MoveDirection.GO_UP);
							toVisitQueue.Enqueue(xyKey(currentx, currenty - 1));
						}
					}
					if (currenty < height - 1 && !visited.Contains(xyKey(currentx, currenty + 1))) {
						MoveCapability mc = moveCapabilityMatrix[currentx, currenty + 1];
						int key = chaseDirectionKey(playerx, playery, currentx, currenty + 1);
						if (mc != null && mc.goDown && !chaseDirection.ContainsKey(key)) {
							chaseDirection.Add(key, MoveDirection.GO_DOWN);
							toVisitQueue.Enqueue(xyKey(currentx, currenty + 1));
						}
					}
				}
			}
		}
		// visualize

//		int playerX = 6;
//		int playerY = 10;
//		for (int i = 0; i < width; i++) {
//			for (int j = 0; j < height; j++) {
//				int key = chaseDirectionKey(playerX, playerY, i, j);
//				if (!chaseDirection.ContainsKey(key)) {
//					continue;
//				}
//				MoveDirection m = (MoveDirection)chaseDirection[key];
//				if (m == MoveDirection.GO_UP) {
//					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
//						.transform.Rotate(0, 0, 90f);
//				}
//				if (m == MoveDirection.GO_DOWN) {
//					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
//						.transform.Rotate(0, 0, -90f);
//				}
//				if (m == MoveDirection.GO_RIGHT) {
//					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
//						.transform.Rotate(0, 0, 0);
//				}
//				
//				if (m == MoveDirection.GO_LEFT) {
//					(Instantiate(arrowPrefab, new Vector3(i, j), Quaternion.identity) as GameObject)
//						.transform.Rotate(0, 0, 180);
//				}
//			}
//		}

	}
	
	private int xyKey(int playerx, int playery) {
		return playerx << 8 | playery;
	}
	private int chaseDirectionKey(int playerx, int playery, int chaserx, int chasery) {
		return playerx << 24 | playery << 16 | chaserx << 8 | chasery;
	}
	public MoveDirection getChaseDirection(int playerx, int playery, int chaserx, int chasery) {
		int key = chaseDirectionKey (playerx, playery, chaserx, chasery);
		if (!chaseDirection.Contains (key)) {
			return MoveDirection.GO_NONE;
		} else {
			return (MoveDirection)this.chaseDirection[key];
		}
	}
}
