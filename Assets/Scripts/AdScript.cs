using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdScript : MonoBehaviour {

	private BannerView bannerAd;

	// Use this for initialization
	void Start () {

		InitBannerAd();

	}

	private void InitBannerAd()
	{
		string adID = "ca-app-pub-6489584930108780/2281975897";

		AdRequest request = new AdRequest.Builder().Build();

		bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
		bannerAd.LoadAd(request);

		hide ();
	}

	public void show(){
		bannerAd.Show ();
	}

	public void hide(){
		bannerAd.Hide ();
	}
}