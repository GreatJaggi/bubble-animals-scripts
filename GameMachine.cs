using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMachine : MonoBehaviour {

	public int bubbleLimit;
	public int habitatNumber;
	public int animalNumber;

	public Animal selectedAnimal;

	public GameObject[] habitats;
	public GameObject[] habitats_set;
	public GameObject bubbleBase;
	public GameObject minSpawn;
	public GameObject maxSpawn;
	public GameObject habitatPane;

	public GameObject nextButton;

	public bool singleMode = false;

	public int spawnCount;
	public int spawnDelimiter;
	public float spawnSpeed;

	public Object LoadNextScene;

	[HideInInspector]
	public bool firstBubble = true;

	int hold = 0;
	public int limit = 10;

	public ArrayList selectedBubbles = new ArrayList ();
	public ArrayList bcDelim = new ArrayList ();

	int nan;
	private void Awake()	{


		for (int i = 0; i < 5; i++) {
			PlayerPrefs.SetInt("BCD" + i, 1);
			if (PlayerPrefs.GetInt ("B" + i) == 1)
				selectedBubbles.Add (i);
			bcDelim.Add ((int)PlayerPrefs.GetInt ("SpawnCount"));
		}//for

		nan = Random.Range (0, 3);
		spawnCount = PlayerPrefs.GetInt ("SpawnCount") * selectedBubbles.Count;
		int hold = PlayerPrefs.GetInt ("HabitatNumber");
		if (hold == 7) {
			habitatNumber = 0;
			singleMode = false;
		}//if
		else {
			habitatNumber = hold;
			singleMode = true;
		}


		spawnDelimiter = spawnCount;
		GenerateGame ();

		for (int i = 0; i < habitats_set.Length; i++) {
			if(i != habitatNumber)
				habitats_set[i].SetActiveRecursively(false);
		}//for

		habitatPane.GetComponent<Image> ().sprite = habitats [habitatNumber].GetComponent<Habitat> ().image;
//		SpawnBubbles ();
		StartCoroutine (BubbleSpawner ());
	}//awake


	IEnumerator BubbleSpawner()	{
		for (int i = 0; i < spawnCount; i++) {
			yield return new WaitForSeconds (spawnSpeed);
			if(i != limit)
				SpawnBubbles();
			else i--;

			firstBubble = false;
		}//for
		yield return new WaitForSeconds (0);
	}//BubbleSpawner();

	public float SoundDecr;
	bool trgd = false;
	void Update()	{
		if (spawnDelimiter == 0) {
			nextButton.SetActive (true);
			if(!trgd)	{
				StartCoroutine(BGMFadeOut());
				trgd = true;
			}//if
		}//if

//		for (int i = 0; i < bcDelim.Count; i++)
//			if ((int)bcDelim [i] == 0)
//				PlayerPrefs.SetInt ("BCD" + i, 0);
	}//update

	private IEnumerator BGMFadeOut()	{
		yield return new WaitForSeconds (.1f);
		if (GameObject.Find ("grasslands_desert_bgm").GetComponent<AudioSource> ().volume > 0) {
			GameObject.Find ("grasslands_desert_bgm").GetComponent<AudioSource> ().volume -= SoundDecr;
			GameObject.Find ("forest_farm_bgm").GetComponent<AudioSource> ().volume -= SoundDecr;
			GameObject.Find ("ocean_freshwater_bgm").GetComponent<AudioSource> ().volume -= SoundDecr;
			GameObject.Find ("arctic_bgm").GetComponent<AudioSource> ().volume -= SoundDecr;
			GameObject.Find ("mountains_bgm").GetComponent<AudioSource> ().volume -= SoundDecr;
			StartCoroutine(BGMFadeOut());
		}//if

		yield return new WaitForSeconds(0);
	}//BGMFadeOut

	int animalTotalNumber = 0;
//	public static int prevHabitat = 0;
	public void GenerateGame()	{

		ArrayList selectedZones = new ArrayList ();
		for (int i = 0; i < habitats.Length; i++)
			if (PlayerPrefs.GetInt ("H" + i) == 1) {
				selectedZones.Add (i);
			animalTotalNumber += habitats[i].GetComponent<Habitat>().animals.Length;
			}//if

		do {
			habitatNumber = (int)selectedZones [Random.Range (0, selectedZones.Count)];
		} while (Habitat.playedAnimals[habitatNumber].Count == habitats[habitatNumber].GetComponent<Habitat>().animalSize);
			
			

//		print (Habitat.playedAnimals[habitatNumber].Count);
		int selectedAnimalNumber;
		do {
			selectedAnimalNumber = Random.Range(0, habitats[habitatNumber].GetComponent<Habitat>().animalSize);
			selectedAnimal = habitats [habitatNumber].GetComponent<Habitat> ().animals[selectedAnimalNumber];
		} while (HistoryContains(selectedAnimal.name));

		Habitat.playedAnimals[habitatNumber].Add (selectedAnimal);


//		print ("TOTAL NUMBER OF ANIMALS: " + animalTotalNumber);
//		print ("TOTAL NUMBER OF ANIMALS PLAYED: " + Habitat.GetPlayedAnimalCount ());
		if (PlayedAllAnimals ()) {
			for (int i = 0; i < Habitat.playedAnimals.Length; i++)
				Habitat.playedAnimals [i].Clear ();
			print ("FLUSHED");
		}//if
//		if (Habitat.playedAnimals[habitatNumber].Count == habitats [habitatNumber].GetComponent<Habitat> ().animals.Length) {
////		if (animalTotalNumber == Habitat.GetPlayedAnimalCount ())	{
//			print ("FLUSHED DATA && ");
//			Habitat.playedAnimals[habitatNumber].Clear ();
////				print ("FLUSHED");
////				for(int i = 0; i < Habitat.playedAnimals.Length; i++)
////					Habitat.playedAnimals[i].Clear();
//		}

		SelectBGM (habitatNumber);

		string animalSet = selectedAnimal.name + habitats[habitatNumber].name;
		try {
			GameObject.Find (animalSet).GetComponent<Image>().enabled = true;
		} catch (System.Exception ex){
			print ("Could not find Animal Image: " + animalSet);
		}
	}//Generate game

	public bool PlayedAllAnimals()	{
		if (animalTotalNumber == Habitat.GetPlayedAnimalCount ())
			return true;
		return false;
	}//PlayedAllAnimals



	private bool HistoryContains (string name)	{
//		for(int i = 0; i < Habitat.playedAnimals.Length; i++)
			foreach (Animal animal in Habitat.playedAnimals[habitatNumber]) {
				if(animal.name == name)
					return true;
		}//foreach
		return false;
	}//CompareList

	public void SelectBGM(int number)	{
		switch (number) {
		case 0: GameObject.Find("ocean_freshwater_bgm").GetComponent<AudioSource>().Play();	break;
		case 1: GameObject.Find("grasslands_desert_bgm").GetComponent<AudioSource>().Play();	break;
		case 2: GameObject.Find("forest_farm_bgm").GetComponent<AudioSource>().Play();	break;
		case 3: GameObject.Find("ocean_freshwater_bgm").GetComponent<AudioSource>().Play();	break;
		case 4: GameObject.Find("arctic_bgm").GetComponent<AudioSource>().Play();	break;
		case 5: GameObject.Find("forest_farm_bgm").GetComponent<AudioSource>().Play();	break;
		case 6: GameObject.Find("mountains_bgm").GetComponent<AudioSource>().Play();	break;
		}//switch
	}//SelectBGM


	void SpawnBubbles()	{
		float x;
		float[] spawnLocations = {
			Random.Range (minSpawn.transform.position.x, maxSpawn.transform.position.x / 3),
			Random.Range (maxSpawn.transform.position.x / 3, maxSpawn.transform.position.x / 3 * 2),
			Random.Range (maxSpawn.transform.position.x / 3 * 2, maxSpawn.transform.position.x / 3 * 3)
		};//spawLocations

		int rand;// = Random.Range (0, 3);
		rand = Random.Range (0, 3);
		while (rand == nan) {
			rand = Random.Range (0, 3);
		}//while
		nan = rand;
		x = spawnLocations [rand];

		GameObject clone = GameObject.Instantiate (bubbleBase, new Vector2(x, minSpawn.transform.position.y), Quaternion.identity) as GameObject;

		clone.transform.SetParent (this.gameObject.transform);
		clone.transform.localScale = new Vector3 (1, 1, 1);
	}//spawning

	public void Next()	{
		Application.LoadLevel (2);
	}//next

}//class
