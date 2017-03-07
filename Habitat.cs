using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

public class Habitat : MonoBehaviour {
	public Animal[] animals;
	private Animal firstAnimal;
	[HideInInspector]
//	public static ArrayList playedAnimals = new ArrayList();
	public static int init = 0;
	public static ArrayList[] playedAnimals = {
		new ArrayList(),
		new ArrayList(),
		new ArrayList(),
		new ArrayList(),
		new ArrayList(),
		new ArrayList(),
		new ArrayList()
	};
	public int animalSize;
	public Sprite image;

	private void Awake()	{

		if (StoreInventory.GetItemBalance("full_version_iid") == 0) {
			firstAnimal = animals [0];
			animals = new Animal[1];
			animals [0] = firstAnimal;
	}//if


		animalSize = animals.Length;
	}//awake

	public static int GetPlayedAnimalCount()	{
		int count = 0;

		foreach (ArrayList list in playedAnimals)
			count += list.Count;

		return count;
	}//GetPlayedAnimalCount
}//class
