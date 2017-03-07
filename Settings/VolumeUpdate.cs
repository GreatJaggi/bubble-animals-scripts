using UnityEngine;
using System.Collections;

public class VolumeUpdate : MonoBehaviour {

	void FixedUpdate()	{
		this.GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("Volume");
	}//FixedUpdate
}//class
