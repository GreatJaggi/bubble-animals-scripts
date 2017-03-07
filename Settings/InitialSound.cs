using UnityEngine;
using System.Collections;

public class InitialSound : MonoBehaviour {

	void Awake()	{
		StartCoroutine (ActivateSFXDelay ());
	}//awake

	IEnumerator ActivateSFXDelay()	{
		yield return new WaitForSeconds (.5f);
		GetComponent<AudioSource> ().enabled = true;
	}//ActivateSFXDelay

}//class
