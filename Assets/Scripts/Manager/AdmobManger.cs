using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdmobManger : MonoBehaviour {


    #region Singleton
    private static AdmobManger _instance;

    public static AdmobManger Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<AdmobManger>();
            return _instance;
        }
    }
    #endregion


    private BannerView bannerView;
    InterstitialAd interstitial;

    public void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInID);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }



    public void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }



    public void RequestBanner()
    {
        bannerView = new BannerView(Config.adsID, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HidewBanner()
    {
        bannerView.Hide();
    }

	// Use this for initialization
	void Start () {
        MobileAds.Initialize(Config.appId);
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
