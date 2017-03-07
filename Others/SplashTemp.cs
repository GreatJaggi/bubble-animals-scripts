using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashTemp : MonoBehaviour {
	public Object LoadSceneNext;
	public AudioSource[] yellIntro;
	private void Awake()	{
		StartCoroutine (AlphaBG ());
//		PlayerPrefs.SetInt ("FirstLaunch", 1);
	}//awake


	IEnumerator AlphaBG()	{
		int number = Random.Range(0, yellIntro.Length);
		yellIntro [number].Play ();
//		yield return new WaitForSeconds(.3f);
		yield return new WaitForSeconds(yellIntro[number].clip.length);
		print ("Loading..");
		Application.LoadLevel (1);
		yield return null;
	}//AlphaBG

}//class