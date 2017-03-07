using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla.Store;

//namespace Soomla	{
	public class IAP_GameType : MonoBehaviour {

		public Button settingsButton;
		public Button IAP_Button;
		public bool FullTest;

		void Start()	{
		}//awake

		void FixedUpdate()	{
		if (!FullTest) {
			Debug.Log ("checking for full ver");
			if (StoreInventory.GetItemBalance ("full_version_iid") > 0) {
				settingsButton.interactable = true;
				IAP_Button.gameObject.SetActive (false);
			}//if
			else {
				settingsButton.interactable = false;
				IAP_Button.gameObject.SetActive (true);
			}//else
		}//awake
		else {

		}
	}

	}//class
//}//namespace