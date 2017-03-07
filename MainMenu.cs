using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Sprite[] BGS;
	private void Awake()	{
		for(int i = 0; i < Habitat.playedAnimals.Length; i++)
			Habitat.playedAnimals[i].Clear ();
		int getRandom = Random.Range (0, BGS.Length);
		this.GetComponent<Image> ().sprite = BGS [getRandom];

		string[] ocean = {
			"SealionOcean",
			"OrcaOcean",
			"WhaleOcean",
			"DolphinOcean",
			"SeagullOcean"
		};//ocean

		string[] arctic = {
			"Polar BearArctic",
			"WolfArctic",
			"PenguinArctic",
			"OwlArctic",
		};//ocean

		string[] mountain = {
			"WolfMountain",
			"LeopardMountain",
			"BearMountain",
			"GorillaMountain",
			"JaguarMountain",
			"BirdMountain",
		};//mountain

		string[] forest = {
			"EagleForest",
			"ParrotForest",
			"MonkeyForest",
			"BatForest",
			"TigerForest",
			"WolfForest",
			"CricketForest",
			"FrogForest",
			"MouseForest",
			"ChimpanzeeForest",
			"CrowForest",
			"GorillaForest",
			"JaguarForest",
			"OwlForest",
			"Wood PeckerForest",
			"BirdForest",
		};//forest

		string[] freshWater = {
			"AlligatorFresh Water",
			"DuckFresh Water",
			"FlamingoFresh Water",
			"CrowFresh Water",
		};//fresh water

		string[] grasslands = {
			"BuffaloGrassland",
			"CowGrassland",
			"DonkeyGrassland",
			"GoatGrassland",
			"HyenaGrassland",
			"HorseGrassland",
			"PigGrassland",
			"TigerGrassland",
		//	"WolfGrassland",
			"CricketGrassland",
			"ElephantGrassland",
			"LionGrassland",
			"YakGrassland",
			"ChimpanzeeGrassland",
			"OwlGrassland",
			"SheepGrassland",
			"LeopardGrassland",
		};//grasslands

		string[] farm = {
			"CowFarm",
			"DonkeyFarm",
			"GoatFarm",
			"DogFarm",
			"HorseFarm",
			//"PigFarm",
			"MouseFarm",
			"CatFarm",
			"HenFarm",
			"RoosterFarm",
			"SheepFarm",
			"TurkeyFarm",
			"BirdFarm",

		};//farm

		string name = this.GetComponent<Image> ().sprite.name;
		switch (name) {
		case "Artic"	:
			GameObject.Find(arctic[Random.Range(0, arctic.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Ocean"	:
			GameObject.Find(ocean[Random.Range(0, ocean.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Mountain"	:
			GameObject.Find(mountain[Random.Range(0, mountain.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Jungle"	:
			GameObject.Find(forest[Random.Range(0, forest.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Fresh Water"	:
			GameObject.Find(freshWater[Random.Range(0, freshWater.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Desert"	:
			GameObject.Find(grasslands[Random.Range(0, grasslands.Length)]).GetComponent<Image>().enabled = true;
			break;
		case "Farm"	:
			GameObject.Find(farm[Random.Range(0, farm.Length)]).GetComponent<Image>().enabled = true;
			break;
		}//switch
	}//awake

}//class
