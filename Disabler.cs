using UnityEngine;
using System.Collections;

public class Disabler : MonoBehaviour {

	public GameObject[] animals;
	public GameObject gameCanvasGM;
	void Awake()	{
		string selectedAnimalName = gameCanvasGM.GetComponent<GameMachine> ().selectedAnimal.name;
		for (int i = 0; i < animals.Length; i++)
			if (animals [i].name != selectedAnimalName)
				animals [i].SetActive (false);

	}//awake

}//class
