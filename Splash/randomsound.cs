using UnityEngine;
using System.Collections;

public class randomsound : MonoBehaviour {
	public AudioClip[] sfx;
	int rng;// Use this for initialization
	AudioSource audio;
	void Start () {
		audio = GetComponent<AudioSource>();
		rng = Random.Range (0, 3);
		audio.PlayOneShot(sfx[rng], 1.0F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
