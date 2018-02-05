using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour {

	public Button backBtn;

	public Text buildingName;
	public Text buildingDes;
	public Text buildingCost;

	public GameObject buildMenuGO;
	private BuildingMenu buildMenu;

	public GameObject resourceMenu;

	void Start () {
		gameObject.SetActive (false);

		backBtn.GetComponent<Button> ().onClick.AddListener (goBack);

		buildMenu = buildMenuGO.GetComponent<BuildingMenu> ();
	}

	public void closeWindow(){
		gameObject.SetActive (false);
		resourceMenu.SetActive (true);
	}

	void goBack(){
		gameObject.SetActive (false);
		resourceMenu.SetActive (true);
		buildMenu.resetBuildingMenu ();
	}

	public void openInfoWindow(string selectedBuildingName, string selectedBuildingInfo, string selectedBuildingCost){
		resourceMenu.SetActive (false);
		gameObject.SetActive (true);
		buildingName.text = selectedBuildingName;
		buildingDes.text = selectedBuildingInfo;
		buildingCost.text = selectedBuildingCost;
	}


}
