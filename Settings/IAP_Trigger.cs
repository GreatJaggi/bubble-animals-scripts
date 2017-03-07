using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

namespace Soomla	{

	public class IAP_Trigger : MonoBehaviour {

		public static List<VirtualGood> VirtualGoods = null;
		void Start () {
			StoreEvents.OnSoomlaStoreInitialized = OSSI;
			SoomlaStore.Initialize (new IAP ());
			//StoreInventory.TakeItem ("full_version_iid", 1); // uncomment if you want to revoke purchase once then uncomment after another test "BI-TESTING"
		}//Start

		public void OSSI()	{
			VirtualGoods = StoreInfo.Goods;
		}//OSSI

		public void ReturnToMenu()	{
			this.GetComponent<Animator> ().SetBool ("Active", false);
		}//ReturnToMenu

		public void DrawIAP_UI()	{
			this.GetComponent<Animator> ().SetBool ("Active", true);
		}//DrawIAP_UI



		public void PurchaseFullVersion()	{

			//SoomlaIntegration
			VirtualGood full_version = VirtualGoods [0];
			try {
				StoreInventory.BuyItem(full_version.ItemId);
			} catch (System.Exception ex) {
				Debug.Log ("ERROR");
			}

			if (StoreInventory.GetItemBalance("full_version_iid") > 0) {
				print("AREADY BOUGHT!");
				this.GetComponent<Animator> ().SetBool ("Active", false);
			}//if
		}//PurchaseFullVersion()
	}//class
}//soomla