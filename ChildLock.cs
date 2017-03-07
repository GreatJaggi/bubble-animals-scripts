using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChildLock : MonoBehaviour {

	public GameObject loadingScreen;

	public Object LoadNextScene;

	public void CheckLockIntro()	{
		if (PlayerPrefs.GetString ("clp") == "") {
			loadingScreen.SetActive(true);
			Application.LoadLevelAsync(1);
		}//if
	}//checklockintro

	public void CheckLock()	{
		if (this.GetComponent<InputField> ().text == PlayerPrefs.GetString ("clp")) {
			loadingScreen.SetActive(true);
			Application.LoadLevelAsync(1);
//			Application.LoadLevel (0);
		}//if
	}//CheckLock
}
