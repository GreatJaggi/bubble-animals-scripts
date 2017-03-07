using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bubble : MonoBehaviour {

	public Image image;
	public Image imageHab;

	public Sprite[] bubble_habitat;

	public Text text;
	public Button button;
	public AudioSource sound;
	public Sprite soundSprite;
	public GameObject bottomCollider;

	int category;

	public float bubbleVelocity;


	Animal selectedAnimal;
	int habitatNumber;
	int lanMode;
	bool english, spanish;
	int lang = 3;

	public GameMachine gameMachine;

	private void Awake()	{
		selectedAnimal = gameMachine.selectedAnimal;
		habitatNumber = gameMachine.habitatNumber;
		lanMode = PlayerPrefs.GetInt ("Language"); // varies from 0-3;
		english = false; spanish = false;
		switch (lanMode) {
		case 0: english = true; break;
		case 1: spanish = true; break;
		case 2:
			do {

				lang = Random.Range(0, 2);
				if(gameMachine.firstBubble) break; // break loop
			} while (PlayerPrefs.GetInt("prevLang") == lang);

			switch(lang)	{
			case 0:	english = true;
				PlayerPrefs.SetInt("prevLang", 0);
				break;
			case 1:	spanish = true;
				PlayerPrefs.SetInt("prevLang", 1);
				break;
			}//switch

			break; // case 2 main switch
		}//switch

		if (this.gameObject.name != "Bubble") {
			ArrayList selectedBubbles = new ArrayList ();
			for(int i = 0; i < 5; i++)	{
				if(PlayerPrefs.GetInt("B" + i) == 1 && PlayerPrefs.GetInt("BCD" + i) == 1)
					selectedBubbles.Add(i);
			}//for
			int categoryIndex = Random.Range(0,selectedBubbles.Count);
			category = (int)selectedBubbles[categoryIndex];
			switch (category) {
			case 0:
				Destroy (imageHab.gameObject);
				image.sprite = selectedAnimal.animalImage;

				gameMachine.bcDelim[0] = (int)gameMachine.bcDelim[0] - 1;
				if ((int)gameMachine.bcDelim [0] == 0)
					PlayerPrefs.SetInt ("BCD" + 0, 0);
				break; //AnimalImage
			case 1:
				Destroy (imageHab.gameObject);
				image.sprite = soundSprite;

				gameMachine.bcDelim[1] = (int)gameMachine.bcDelim[1] - 1;
				if ((int)gameMachine.bcDelim [1] == 0)
					PlayerPrefs.SetInt ("BCD" + 1, 0);
				break; //AnimalSound
			case 2:
				Destroy (image.gameObject);
				Destroy (imageHab.gameObject);
				if (english) text.text = selectedAnimal.name;
				if (spanish) text.text = selectedAnimal.name_esp;

				gameMachine.bcDelim[2] = (int)gameMachine.bcDelim[2] - 1;
				if ((int)gameMachine.bcDelim [2] == 0)
					PlayerPrefs.SetInt ("BCD" + 2, 0);
				break; //AnimalName
			case 3:
				//AKL;DSJHPAWEJF
				Destroy (image.gameObject);
//				text.text = gameMachine.habitats[habitatNumber].name;
				imageHab.sprite = bubble_habitat[habitatNumber];

				gameMachine.bcDelim[3] = (int)gameMachine.bcDelim[3] - 1;
				if ((int)gameMachine.bcDelim [3] == 0)
					PlayerPrefs.SetInt ("BCD" + 3, 0);
				break; //AnimalHabitat
			case 4:
				Destroy (image.gameObject);
				Destroy (imageHab.gameObject);
				if(english) text.text = selectedAnimal.grouping;
				if(spanish) text.text = selectedAnimal.grouping_esp;

				gameMachine.bcDelim[4] = (int)gameMachine.bcDelim[4] - 1;
				if ((int)gameMachine.bcDelim [4] == 0)
					PlayerPrefs.SetInt ("BCD" + 4, 0);
				break; //AnimalGrouping
			default:
				print ("Unknown error occured.");
				break;
			}//switch
		}//if



//		StartCoroutine (Nudge ());
//		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10));
//		Nudge ();
	}//awake

	bool nudgeOnce = false;
	void FixedUpdate()	{
		if (this.gameObject.transform.position.y > bottomCollider.transform.position.y + 150 && !nudgeOnce) {
			this.gameObject.tag = "Bubble";
			Physics2D.IgnoreCollision(bottomCollider.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
			GetComponent<Rigidbody2D>().gravityScale = -1;
			StartCoroutine (Nudge ());
			nudgeOnce = true;
		}//if

	}//update

	IEnumerator Nudge()	{
		while (true) {
			GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * bubbleVelocity);
			yield return new WaitForSeconds(Random.Range(2f, 4f));
//			yield return new WaitForSeconds(0);
		}//while
		yield return new WaitForSeconds (0f);
	}//nudge

	public void Pop()	{
		switch (category) {
		case 0: 
			if(english)	selectedAnimal.animalNameSound.Play (); 
			if(spanish) selectedAnimal.animalNameSound_esp.Play();
			Destroy(this.gameObject); break; //AnimalImage;
		case 1: selectedAnimal.animalSound.Play(); Destroy(this.gameObject); break; //AnimaSound;
		case 2: 
			if(english)	selectedAnimal.animalNameSound.Play (); 
			if(spanish) selectedAnimal.animalNameSound_esp.Play();
			Destroy (this.gameObject); break; //AnimalName;
		case 3: 
			string name = GameObject.Find("GameCanvas").GetComponent<GameMachine>().habitats[habitatNumber].name;
			GameObject.Find(name + "SFX").GetComponent<AudioSource>().Play();
			Destroy(this.gameObject); break; //AnimalHabitat
		case 4: 
			if(english)	GameObject.Find(selectedAnimal.grouping + "_sfx").GetComponent<AudioSource>().Play();
			if(spanish)	GameObject.Find(selectedAnimal.grouping_esp + "_sfx").GetComponent<AudioSource>().Play();
			Destroy(this.gameObject); break; //AnimalGrouping
		}//switch
		gameMachine.spawnDelimiter -= 1;
//		gameMachine.limit -= 1;
		gameMachine.limit += 1;
	}//pop_machine!


	IEnumerator PauseToDestroy() {
		yield return new WaitForSeconds(1);
		Destroy (this.gameObject);
	}


}//class
