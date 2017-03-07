using UnityEngine;
using System.Collections;
using Soomla.Store;

public class InitialValues : MonoBehaviour {

	int firstLaunch = 0;
	// Use this for initialization
	void Awake () {
//		PlayerPrefs.DeleteAll ();
		firstLaunch = PlayerPrefs.GetInt ("FirstLaunch");

		if (firstLaunch == 0) {
			//first launch set initial values
			PlayerPrefs.SetInt ("SpawnCount", 3);
			PlayerPrefs.SetInt ("Language", 0);
			PlayerPrefs.SetFloat ("Volume", 0.80f);
			PlayerPrefs.SetString ("clp", "");

			for (int i = 0; i < 7; i++)
				PlayerPrefs.SetInt ("H" + i, 1);

			for (int i = 0; i < 5; i++)
				PlayerPrefs.SetInt ("B" + i, 1);

			PlayerPrefs.SetInt ("FirstLaunch", 1);
		}//if first launch
		else {
			print ("Not your first launch");
		}//else
			
	}//awake

}//class
