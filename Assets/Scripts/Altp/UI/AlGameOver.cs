using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AlGameOver : MonoBehaviour {

	public tk2dUIItem btnContinute;

	public tk2dTextMesh txtLevel;
	public tk2dTextMesh txtMaxLevel;


	InterstitialAd interstitial;

	private void LoadAdsInterstitial()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(Config.adsInID);
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
		LoadAdsInterstitial();
	}


	void btnContinute_OnClick()
	{
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
		ShowAdsInterstitial();
	}



	// Use this for initialization
	void Start () {
		btnContinute.OnClick += btnContinute_OnClick;

	}

	// Update is called once per frame
	void Update () {

	}
}
