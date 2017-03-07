using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingTemp : MonoBehaviour {

	void Awake()	{
		StartCoroutine (Animate ());
	}//awake

	IEnumerator Animate()	{
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading.";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. .";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. . .";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. . . .";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. . . . .";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. . . . . .";
		yield return new WaitForSeconds (.3f);
		GetComponent<Text> ().text = "Loading. . . . . . .";
		StartCoroutine (Animate ());
	}//
}
