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

	private Dictionary<string, GameObject> tilePrefabDictionary;
	// Use this for initialization
	void Start () {
		tilePrefabDictionary = new Dictionary<string, GameObject> ();
		tilePrefabDictionary ["floor"] = floorPrefab;
		tilePrefabDictionary ["gold"] = goldPrefab;
		tilePrefabDictionary ["hard floor"] = hardFloorPrefab;
		tilePrefabDictionary ["ladder"] = ladderPrefab;
		tilePrefabDictionary ["stick"] = stickPrefab;
		loadMap ();
	}
	
	// Update is called once per frame
	void Update () {

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
			int width = int.Parse(layer.Attributes["width"].Value);
			int height = int.Parse(layer.Attributes["height"].Value);
			XmlNodeList tilesList = layer.ChildNodes[0].ChildNodes;
			for (int i = 0; i < tilesList.Count; i++) {
				int x = i % width;
				int y = 14 - i / width;
				string gid = tilesList[i].Attributes["gid"].Value;
				if (gid != "0") {
					string tileName = tileMap[tilesList[i].Attributes["gid"].Value];
					Instantiate(tilePrefabDictionary[tileName],
					            new Vector3(x * 0.32f, y * 0.32f, 0f),
					            Quaternion.identity);
					Debug.Log ("tile " + tileName + " at " + x + " " + y );
				}
			}
		}
	}
}
