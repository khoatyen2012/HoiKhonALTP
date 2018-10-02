using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class MaxScore : MonoBehaviour {



	public tk2dUIItem btnHome;

	public tk2dTextMesh txtCau;

	BannerView bannerView;
	AdRequest request;


	private void LoadAdsBanner()
	{
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(
			Config.adsID, AdSize.Banner, AdPosition.Top);
		// Create an empty ad request.



		request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("54829CBF8D1115A66940C3B0C88A9B7E").Build();
		// Load the banner with the request.

		//id0ae30a9eb3539410624b3cd2b086379e

		// Debug.Log("device id" + SystemInfo.deviceUniqueIdentifier);
	}

	public void ShowAdsBanner()
	{
		bannerView.LoadAd(request);
		bannerView.Show();
	}

	public void HideAdsBanner()
	{
		bannerView.Hide();
	}


	public void setData()
	{
		ShowAdsBanner();
		string cau="Vượt qua câu: "+DataManager.GetHightScoreALTP();
		txtCau.text = cau;

	}




	public void btnHome_OnClick()
	{
		try
		{
			AlPopupController.instance.ShowMainGame();
			AlPopupController.instance.HidePopupMaxScore();
			HideAdsBanner();
		}
		catch (System.Exception)
		{

			throw;
		}
	}



	// Use this for initialization
	void Start () {

		btnHome.OnClick += btnHome_OnClick;

		LoadAdsBanner();
	}

	// Update is called once per frame
	void Update () {

	}
}
