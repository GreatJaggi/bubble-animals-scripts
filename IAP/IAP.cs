using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;

namespace Soomla {
	
	public class IAP : IStoreAssets {
		
		public int GetVersion() {
			return 0;
		}
		
		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{};
		}
		
		public VirtualGood[] GetGoods() {
			return new VirtualGood[] { FULL_VERSION };
		}
		
		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {};
		}
		
		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};
		}


		public static string FULL_VERSION_PRODUCT_ID = "android.test.purchased";
		/** LifeTimeVGs **/
		public static VirtualGood FULL_VERSION = new LifetimeVG(
			"Full Version", 														// name
			"Purchased Full Version of the Game!",				 									// description
			"full_version_iid",														// item id
			new PurchaseWithMarket(new MarketItem(FULL_VERSION_PRODUCT_ID, 9.99))
		);// the way this virtual good is purchased
	}//class
}//namespace