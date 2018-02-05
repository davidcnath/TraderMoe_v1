using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketPriceManager : MonoBehaviour {

	public GameObject resourceManagerGO;
	private ResourceManager resourceManager;

	public Button foodBuybtn, foodSellbtn, woodBuybtn, woodSellbtn, machineBuybtn, machineSellbtn, weaponBuybtn, weaponSellbtn, stoneBuybtn, stoneSellbtn,
		fireRuneBuybtn, fireRuneSellbtn, iceRuneBuybtn, iceRuneSellbtn, arcaneRuneBuybtn, arcaneRuneSellbtn;

	public int foodPrice = 10;
	public int woodPrice = 10;
	public int machinePrice = 20;
	public int weaponPrice = 30;
	public int stonePrice = 15;
	public int fireRunePrice = 100;
	public int iceRunePrice = 100;
	public int arcaneRunePrice = 150;

	private int foodBuy, foodSell;
	private int woodBuy, woodSell;
	private int machineBuy, machineSell;
	private int weaponBuy, weaponSell;
	private int stoneBuy, stoneSell;
	private int fireRuneBuy, fireRuneSell;
	private int iceRuneBuy, iceRuneSell;
	private int arcaneRuneBuy, arcaneRuneSell;

	void Start(){
		resourceManager = resourceManagerGO.GetComponent<ResourceManager> ();

		updatePrices (foodBuybtn, foodSellbtn, foodPrice, foodBuy, foodSell);
		updatePrices (woodBuybtn, woodSellbtn, woodPrice, woodBuy, woodSell);
		updatePrices (machineBuybtn, machineSellbtn, machinePrice, machineBuy, machineSell);
		updatePrices (weaponBuybtn, weaponSellbtn, weaponPrice, weaponBuy, weaponSell);
		updatePrices (stoneBuybtn, stoneSellbtn, stonePrice, stoneBuy, stoneSell);
		updatePrices (fireRuneBuybtn, fireRuneSellbtn, fireRunePrice, fireRuneBuy, fireRuneSell);
		updatePrices (iceRuneBuybtn, iceRuneSellbtn, iceRunePrice, iceRuneBuy, iceRuneSell);
		updatePrices (arcaneRuneBuybtn, arcaneRuneSellbtn, arcaneRunePrice, arcaneRuneBuy, arcaneRuneSell);

		foodBuybtn.GetComponent<Button> ().onClick.AddListener (buyFood);
		foodSellbtn.GetComponent<Button> ().onClick.AddListener (sellFood);
		woodBuybtn.GetComponent<Button> ().onClick.AddListener (buyWood);
		woodSellbtn.GetComponent<Button> ().onClick.AddListener (sellWood);
		machineBuybtn.GetComponent<Button> ().onClick.AddListener (buyMachine);
		machineSellbtn.GetComponent<Button> ().onClick.AddListener (sellMachine);
		stoneBuybtn.GetComponent<Button> ().onClick.AddListener (buyStone);
		stoneSellbtn.GetComponent<Button> ().onClick.AddListener (sellStone);
		fireRuneBuybtn.GetComponent<Button> ().onClick.AddListener (buyFireRune);
		fireRuneSellbtn.GetComponent<Button> ().onClick.AddListener (sellFireRune);
		iceRuneBuybtn.GetComponent<Button> ().onClick.AddListener (buyIceRune);
		iceRuneSellbtn.GetComponent<Button> ().onClick.AddListener (sellIceRune);
		arcaneRuneBuybtn.GetComponent<Button> ().onClick.AddListener (buyArcaneRune);
		arcaneRuneSellbtn.GetComponent<Button> ().onClick.AddListener (sellArcaneRune);
		weaponBuybtn.GetComponent<Button> ().onClick.AddListener (buyWeapon);
		weaponSellbtn.GetComponent<Button> ().onClick.AddListener (sellWeapon);
	}

	void Update(){
		Text foodBuyPrice = foodBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (foodBuyPrice.text, out foodBuy);
		Text foodSellPrice = foodSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (foodSellPrice.text, out foodSell);

		Text woodBuyPrice = woodBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (woodBuyPrice.text, out woodBuy);
		Text woodSellPrice = woodSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (woodSellPrice.text, out woodSell);

		Text machineBuyPrice = machineBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (machineBuyPrice.text, out machineBuy);
		Text machineSellPrice = machineSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (machineSellPrice.text, out machineSell);

		Text weaponBuyPrice = weaponBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (weaponBuyPrice.text, out weaponBuy);
		Text weaponSellPrice = weaponSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (weaponSellPrice.text, out weaponSell);

		Text stoneBuyPrice = stoneBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (stoneBuyPrice.text, out stoneBuy);
		Text stoneSellPrice = stoneSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (stoneSellPrice.text, out stoneSell);

		Text fireRuneBuyPrice = fireRuneBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (fireRuneBuyPrice.text, out fireRuneBuy);
		Text fireRuneSellPrice = fireRuneSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (fireRuneSellPrice.text, out fireRuneSell);

		Text iceRuneBuyPrice = iceRuneBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (iceRuneBuyPrice.text, out iceRuneBuy);
		Text iceRuneSellPrice = iceRuneSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (iceRuneSellPrice.text, out iceRuneSell);

		Text arcaneRuneBuyPrice = arcaneRuneBuybtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (arcaneRuneBuyPrice.text, out arcaneRuneBuy);
		Text arcaneRuneSellPrice = arcaneRuneSellbtn.transform.GetChild (0).GetComponent<Text> ();
		int.TryParse (arcaneRuneSellPrice.text, out arcaneRuneSell);
	}

	void updatePrices(Button buybtn, Button sellbtn, int itemPrice, int itemBuy, int itemSell){
		Transform buyPrice = buybtn.transform.GetChild (0);
		Text buyPriceText = buyPrice.GetComponent<Text> ();
		itemBuy = itemPrice + 1;
		buyPriceText.text = itemBuy.ToString();

		Transform sellPrice = sellbtn.transform.GetChild (0);
		Text sellPriceText = sellPrice.GetComponent<Text> ();
		itemSell = itemPrice - 1;
		sellPriceText.text = itemSell.ToString ();
	}

	void buyFood(){
		resourceManager.updateGold (-foodBuy);
		resourceManager.updateFood (1);
		foodPrice++;
		updatePrices (foodBuybtn, foodSellbtn, foodPrice, foodBuy, foodSell);
	}

	void sellFood(){
		resourceManager.updateGold (foodSell);
		resourceManager.updateFood (-1);
		foodPrice--;
		updatePrices (foodBuybtn, foodSellbtn, foodPrice, foodBuy, foodSell);
	}

	void buyWood(){
		resourceManager.updateGold (-woodBuy);
		resourceManager.updateWood (1);
		woodPrice++;
		updatePrices (woodBuybtn, woodSellbtn, woodPrice, woodBuy, woodSell);
	}

	void sellWood(){
		resourceManager.updateGold (woodSell);
		resourceManager.updateWood (-1);
		updatePrices (woodBuybtn, woodSellbtn, woodPrice, woodBuy, woodSell);
	}

	void buyMachine(){
		resourceManager.updateGold (-machineBuy);
		resourceManager.updateMachines (1);
		updatePrices (machineBuybtn, machineSellbtn, machinePrice, machineBuy, machineSell);
	}

	void sellMachine(){
		resourceManager.updateGold (machineSell);
		resourceManager.updateMachines (-1);
		updatePrices (machineBuybtn, machineSellbtn, machinePrice, machineBuy, machineSell);
	}

	void buyWeapon(){
		resourceManager.updateGold (-weaponBuy);
		resourceManager.updateWeopans (1);
		updatePrices (weaponBuybtn, weaponSellbtn, weaponPrice, weaponBuy, weaponSell);
	}

	void sellWeapon(){
		resourceManager.updateGold (weaponSell);
		resourceManager.updateWeopans (-1);
		updatePrices (weaponBuybtn, weaponSellbtn, weaponPrice, weaponBuy, weaponSell);
	}

	void buyStone(){
		resourceManager.updateGold (-stoneBuy);
		resourceManager.updateStone (1);
		updatePrices (stoneBuybtn, stoneSellbtn, stonePrice, stoneBuy, stoneSell);
	}

	void sellStone(){
		resourceManager.updateGold (stoneSell);
		resourceManager.updateStone (-1);
		updatePrices (stoneBuybtn, stoneSellbtn, stonePrice, stoneBuy, stoneSell);
	}

	void buyFireRune(){
		resourceManager.updateGold (-fireRuneBuy);
		resourceManager.updateFireRunes (1);
		updatePrices (fireRuneBuybtn, fireRuneSellbtn, fireRunePrice, fireRuneBuy, fireRuneSell);
	}

	void sellFireRune(){
		resourceManager.updateGold (fireRuneSell);
		resourceManager.updateFireRunes (-1);
		updatePrices (fireRuneBuybtn, fireRuneSellbtn, fireRunePrice, fireRuneBuy, fireRuneSell);
	}

	void buyIceRune(){
		resourceManager.updateGold (-iceRuneBuy);
		resourceManager.updateIceRunes (1);
		updatePrices (iceRuneBuybtn, iceRuneSellbtn, iceRunePrice, iceRuneBuy, iceRuneSell);
	}

	void sellIceRune(){
		resourceManager.updateGold (iceRuneSell);
		resourceManager.updateIceRunes (-1);
		updatePrices (iceRuneBuybtn, iceRuneSellbtn, iceRunePrice, iceRuneBuy, iceRuneSell);
	}

	void buyArcaneRune(){
		resourceManager.updateGold (-arcaneRuneBuy);
		resourceManager.updateArcaneRunes (1);
		updatePrices (arcaneRuneBuybtn, arcaneRuneSellbtn, arcaneRunePrice, arcaneRuneBuy, arcaneRuneSell);
	}

	void sellArcaneRune(){
		resourceManager.updateGold (arcaneRuneSell);
		resourceManager.updateArcaneRunes (-1);
		updatePrices (arcaneRuneBuybtn, arcaneRuneSellbtn, arcaneRunePrice, arcaneRuneBuy, arcaneRuneSell);
	}






}
