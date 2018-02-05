using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	public Text topBarList;
	private string itemList;

	public int gold, food, workers, wood, weapons, machines, stone, fireRunes, iceRunes, arcaneRunes;

	void Start(){
		updateItemList ();
		topBarList.text = itemList;
	}

	void FixedUpdate(){
		topBarList.text = itemList;
	}

	void updateItemList(){
		itemList = "Gold: " + gold + " Food: " + food + " Workers: " + workers + " Wood: " + wood + " Machines: " + machines + " \n" +
			"Weapons: " + weapons + " Stone: " + stone + " Fire Runes: " + fireRunes + " Ice Runes: " + iceRunes + " Arcane Runes:" + arcaneRunes;
	}

	public void updateGold(int x){
		gold += x;
		updateItemList ();
	}

	public void updateFood(int x){
		food += x;
		updateItemList ();
	}

	public void updateWorkers(int x){
		workers += x;
		updateItemList ();
	}

	public void updateWood(int x){
		wood += x;
		updateItemList ();
	}

	public void updateMachines(int x){
		machines += x;
		updateItemList ();
	}

	public void updateWeopans(int x){
		weapons += x;
		updateItemList ();
	}

	public void updateStone(int x){
		stone += x;
		updateItemList ();
	}

	public void updateFireRunes(int x){
		fireRunes += x;
		updateItemList ();
	}

	public void updateIceRunes(int x){
		iceRunes += x;
		updateItemList ();
	}

	public void updateArcaneRunes(int x){
		arcaneRunes += x;
		updateItemList ();
	}




}
