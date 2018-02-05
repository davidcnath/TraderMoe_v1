using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour {

	public GameObject mapGO;
	private Map map;

	public GameObject buildingInfoGO;
	private BuildingInfo buildingInfoWindow;

	public Text selectedBuildingText, notEnoughResourcesText;

	public Button farmbtn, housebtn, workshopbtn, storagebtn, barracksbtn, wizardtowerbtn, woodwallbtn, stonewallbtn;

	private string buildingName, buildingInfo, buildingCost;
	private int foodCost, woodCost, stoneCost, workerCost, goldCost;

	public GameObject farmGO, houseGO, workshopGO, storageGO, barracksGO, wiztowerGO, woodwallGO, stonewallGO;

	public GameObject resourceManager;
	private bool enoughResources;
	private float time = 0f;

	// Use this for initialization
	void Start () {
		buildingInfoWindow = buildingInfoGO.GetComponent<BuildingInfo> ();
		map = mapGO.GetComponent<Map> ();
		selectedBuildingText.gameObject.SetActive (false);

		farmbtn.GetComponent<Button> ().onClick.AddListener (farmDes);
		housebtn.GetComponent<Button> ().onClick.AddListener (houseDes);
		workshopbtn.GetComponent<Button> ().onClick.AddListener (workshopDes);
		storagebtn.GetComponent<Button> ().onClick.AddListener (storageDes);
		barracksbtn.GetComponent<Button> ().onClick.AddListener (barracksDes);
		wizardtowerbtn.GetComponent<Button> ().onClick.AddListener (wizardTowerDes);
		woodwallbtn.GetComponent<Button> ().onClick.AddListener (woodWallDes);
		stonewallbtn.GetComponent<Button> ().onClick.AddListener (stoneWallDes);

		notEnoughResourcesText.gameObject.SetActive (false);
	}

	void FixedUpdate(){
		selectedBuildingText.transform.position = Input.mousePosition;
	}
	void Update(){
		time += Time.deltaTime;
		if (time > 3) {
			notEnoughResourcesText.gameObject.SetActive (false);
		}
	}

	public void resetBuildingMenu(){
		selectedBuildingText.gameObject.SetActive (false);
		buildingInfoGO.GetComponent<BuildingInfo> ().closeWindow ();
		map.toggleNewBuilding ();
	}

	void curserUI(){
		selectedBuildingText.text = buildingName;
		selectedBuildingText.gameObject.SetActive (true);
	}

	void displayWarning(){
		time = 0;
		notEnoughResourcesText.gameObject.SetActive (true);
	}

	void checkIfEnoughResources(){
		ResourceManager myResources = resourceManager.GetComponent<ResourceManager> ();
		if(myResources.food >= foodCost){
			if(myResources.wood >= woodCost){
				if(myResources.workers >= workerCost){
					if(myResources.stone >= stoneCost){
						if (myResources.gold >= goldCost) {
							enoughResources = true;
						} else { enoughResources = false; }
					} else { enoughResources = false; }
				} else { enoughResources = false; }
			} else { enoughResources = false; }
		} else { enoughResources = false; }
	}

	public void deductCosts(){
		ResourceManager myResources = resourceManager.GetComponent<ResourceManager> ();
		myResources.updateFood (-foodCost);
		myResources.updateWood (-woodCost);
		myResources.updateGold (-goldCost);
		myResources.updateWorkers (-workerCost);
		myResources.updateStone (-stoneCost);
	}

	void farmDes(){
		goldCost = 20;
		foodCost = 0;
		woodCost = 5;
		workerCost = 2;
		stoneCost = 0;

		buildingName = "Farm";
		buildingInfo = "Food grows here, it tastes quite bland, but it will do.";
		buildingCost = "Gold: 20 Wood: 5 Workers: 2";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (farmGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void houseDes(){
		goldCost = 20;
		foodCost = 10;
		woodCost = 5;
		workerCost = 0;
		stoneCost = 0;

		buildingName = "House";
		buildingInfo = "People need to live somewhere! This building requires food but produces workers.";
		buildingCost = "Gold: 20 Wood: 5 Food: 10";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (houseGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void workshopDes(){
		goldCost = 50;
		foodCost = 0;
		woodCost = 10;
		workerCost = 5;
		stoneCost = 0;

		buildingName = "Workshop";
		buildingInfo = "Who knows what they do in here?!";
		buildingCost = "Gold: 50 Wood: 10 Workers: 5";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (workshopGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void storageDes(){
		goldCost = 200;
		foodCost = 0;
		woodCost = 50;
		workerCost = 10;
		stoneCost = 10;

		buildingName = "Storage";
		buildingInfo = "Place to put things!";
		buildingCost = "Gold: 200 Wood: 50 Workers: 10 Stone: 10";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (storageGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void barracksDes(){
		goldCost = 50;
		foodCost = 30;
		woodCost = 25;
		workerCost = 2;
		stoneCost = 0;

		buildingName = "Barracks";
		buildingInfo = "Where workers become soldiers!";
		buildingCost = "Gold: 50 Wood: 25 Food: 30 Workers: 2";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (barracksGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void wizardTowerDes(){
		goldCost = 300;
		foodCost = 0;
		woodCost = 25;
		workerCost = 5;
		stoneCost = 100;

		buildingName = "Wizard Tower";
		buildingInfo = "Where workers are taught the dangerous art of wizardary!";
		buildingCost = "Gold: 300 Wood: 25 Stone: 100 Workers 5";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (wiztowerGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void woodWallDes(){
		goldCost = 20;
		foodCost = 0;
		woodCost = 10;
		workerCost = 0;
		stoneCost = 0;

		buildingName = "A Wooden Wall";
		buildingInfo = "A plain old wooden wall";
		buildingCost = "Gold: 20 Wood: 10";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (woodwallGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}

	void stoneWallDes(){
		goldCost = 40;
		foodCost = 0;
		woodCost = 0;
		workerCost = 0;
		stoneCost = 20;

		buildingName = "A Stone Wall";
		buildingInfo = "Like a wooden wall, but in stone";
		buildingCost = "Gold: 40 Stone: 20";

		checkIfEnoughResources ();
		if (enoughResources) {
			curserUI ();
			map.getNextBuildingGO (stonewallGO);
			map.toggleNewBuilding ();
		} else {
			displayWarning ();
		}

		buildingInfoWindow.openInfoWindow (buildingName, buildingInfo, buildingCost);
	}



}
