using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AlGameOver : MonoBehaviour {

	public tk2dUIItem btnContinute;
	public tk2dUIItem btnALTP;

	public tk2dTextMesh txtLevel;
	public tk2dTextMesh txtMaxLevel;


	InterstitialAd interstitial;

	private void LoadAdsInterstitial()
	{
		// Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInIdAL);
		// Create an empty ad request.
		AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(requestIN);
	}

	private void ShowAdsInterstitial()
	{
		if (interstitial.IsLoaded())
		{
			interstitial.Show();
		}
	}

	void callResetDapAn()
	{
		DapAnController.instance.resetDapAN();

	}

	public void setlevel(int level, int maxlevel)
	{
		txtLevel.text = "Vượt qua: Câu " + level;
		txtMaxLevel.text = "Thời gian: " + maxlevel+" giây.";
		if (AlGameController.instance.level % 2 == 0) {
			LoadAdsInterstitial ();
		}
	}


	void btnContinute_OnClick()
	{

		if (AlGameController.instance.level % 2 == 0) {
			ShowAdsInterstitial();
		}

		try
		{
			AlSoundController.Instance.PlayTamBiet();
			callResetDapAn();
			AlPopupController.instance.HidePopupGameOver();
			AlPopupController.instance.HidePopupKhanGia();
			AlPopupController.instance.HidePopupNguoiThan();
			AlPopupController.instance.HidePopUpWin();
			AlPopupController.instance.ShowMainGame();
			TroGiupControlller.instance.resetHelp();
			AlGameController.instance.level = 1;

		
		}
		catch (System.Exception)
		{

			throw;
		}

	}

	void btnALTP_OnClick()
	{
		try
		{
	
			ShareRate.RateALTP();

		}
		catch (System.Exception)
		{

			throw;
		}

	}



	// Use this for initialization
	void Start () {
		btnContinute.OnClick += btnContinute_OnClick;
		btnALTP.OnClick += btnALTP_OnClick;

	}

	// Update is called once per frame
	void Update () {

	}
}
