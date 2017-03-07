using UnityEngine;
using System.Collections;

public class BubbleCategoryLimit : MonoBehaviour {

	void Awake()	{
		ArrayList selectedBubbles = new ArrayList ();
		ArrayList categoryDelim = new ArrayList ();
		for (int i = 0; i < 5; i++)
			if (PlayerPrefs.GetInt ("B" + i) == 1) {
				selectedBubbles.Add (i);
				categoryDelim.Add(PlayerPrefs.GetInt("SpawnCount"));
			}//if
		}//awake
}//class
