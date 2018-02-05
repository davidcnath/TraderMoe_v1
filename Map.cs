using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public GameObject defaultTile;
	public GameObject buildMenuUI;
	public GameObject buildingManager;

	public GameObject townHall;

	public bool smallSize;
	public bool medSize;
	public bool largeSize;

	private int mapSize;
	private int mapHeight = 9;

	private GameObject nextBuilding;
	private bool makeNewBuilding;
	private GameObject selectedTile;

	// Use this for initialization
	void Start () {
		if (!smallSize && !medSize && !largeSize) {
			medSize = true;		} 
		if (smallSize) {		mapSize = 20;		} 
		else if (medSize) {		mapSize = 40;		} 
		else if (largeSize) {	mapSize = 60;		}
		generateMap ();
		addTownHall ();
	}
	
	void generateMap(){
		for (int i = 0; i < mapSize; i++) {
			for (int j = 0; j < mapHeight; j++) 
				addTile ( i, j);
		}
	}

	void addTile(int x, int y){
		Vector3 newTilePos = new Vector3 (x, 0f, y);
		GameObject newTile = Instantiate (defaultTile, newTilePos, Quaternion.Euler(90f,0f,0f)) as GameObject;
		newTile.transform.parent = gameObject.transform;
		//each tile recieves it's coords and named appropriately
		newTile.GetComponent<DefaultTile> ().updateCoords (x, y);
		newTile.name = "Tile_" + x + "_" + y;
	}

	// buildingMenu tells Map which GO to build
	public void getNextBuildingGO(GameObject next_building){
		nextBuilding = next_building;
	}

	// buildingMenu tells Map to tell tiles to enter build mode
	public void toggleNewBuilding(){
		if(!makeNewBuilding){			
			foreach(Transform child in transform){				
				child.GetComponent<DefaultTile>().toggleBuildMode();
			}
			makeNewBuilding = true;
		} else {			
			foreach(Transform child in transform){
				child.GetComponent<DefaultTile>().toggleBuildMode();
			}
			makeNewBuilding = false;
		}
	}

	// tile tells map it has been selected/clicked on
	public void getTileGO(GameObject thisTile){
		selectedTile = thisTile;
		buildAndReplaceTile ();
	}

	void buildAndReplaceTile(){
		Vector3 position = selectedTile.transform.position;
		GameObject newBuilding = Instantiate (nextBuilding, position, Quaternion.Euler(0f,0f,0f)) as GameObject;
		newBuilding.transform.parent = buildingManager.transform;
		buildMenuUI.GetComponent<BuildingMenu> ().resetBuildingMenu ();
		buildMenuUI.GetComponent<BuildingMenu> ().deductCosts ();
		Destroy (selectedTile.gameObject);
	}

	void addTownHall(){
		foreach (Transform child in transform) {
			if (child.name == "Tile_1_4") {
				Vector3 position = child.position;
				GameObject newBuilding = Instantiate (townHall, position, Quaternion.Euler(0f,0f,0f)) as GameObject;
				newBuilding.transform.parent = buildingManager.transform;
				Destroy (child.gameObject);
			}
		}
	}

}
