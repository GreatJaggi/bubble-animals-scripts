using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class State : MonoBehaviour {

	public int bubbleState;
	public Image image;
	public AudioClip sfx;
	public GameObject gameCanvas;
	public Animal animal;

	void Awake()	{
		animal = gameCanvas.GetComponent<GameMachine> ().selectedAnimal;
		image.sprite = animal.animalImage;
		print (animal.name);
	}//awake


	public void Pop()	{
		Destroy (gameObject);
	}//pop

}//class
