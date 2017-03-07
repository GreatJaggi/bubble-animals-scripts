using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Volume : MonoBehaviour {
	void Awake()	{
		this.GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("Volume");
	}//FixedUpdate
}//class
