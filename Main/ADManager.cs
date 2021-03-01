using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADManager : MonoBehaviour
{
    public static ADManager Instance { get; set; }
    // private string APP_ID = "ca-app-pub-6472592451557290~7414895327";
    private BannerView bannerAD;
   // private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardBasedVideoAd;
    // Start is called before the first frame update
    void Start()
    {
        // MobileAds.Initialize(APP_IDTEST);
        RequestBanner();
        RequestInterstitial();
        RequestVideoAdd();
    }

    // Update is called once per frame
    void Update()
    {
       if(Instance == null)
        {
            Instance = this;
        } 

    }

    void RequestBanner()
    {
        string banner_id = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_id, AdSize.SmartBanner, AdPosition.Bottom);
        //FOR REAL
       // AdRequest AdRequest = new AdRequest.Builder().Build();
        //for testing
      AdRequest AdRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        bannerAD.LoadAd(AdRequest);

    }
    void RequestInterstitial()
    {
        string interstitial_id = "ca-app-pub-3940256099942544/1033173712";
        InterstitialAd InterstitialAd = new InterstitialAd(interstitial_id);
        //FOR REAL SAME
        // AdRequest AdRequest = new AdRequest.Builder().Build();
        //for testing
        AdRequest AdRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        InterstitialAd.LoadAd(AdRequest);

    }
    void RequestVideoAdd()
    {
        string VideoAdd_ID = "ca-app-pub-3940256099942544/5224354917";
        RewardBasedVideoAd videoad = RewardBasedVideoAd.Instance;
        //FOR REAL SAME
        // AdRequest AdRequest = new AdRequest.Builder().Build();
        //for testing
        AdRequest AdRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        videoad.LoadAd(AdRequest,VideoAdd_ID);

    }
    public void Display_Banner()
    {
        bannerAD.Show();
    }
  
    public void Display_RewardVideo()
    {
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
        }
    }

    //HANDELEVENTS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
      //  Display_Inter();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
        RequestInterstitial();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandelBannerAdEvent(bool subscribe)
    {
        if (subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }

    private void OnEnable()
    {
        HandelBannerAdEvent(true);
       // HandelInterstitialAd(true);
    }
    private void OnDisable()
    {
        HandelBannerAdEvent(false);
        //HandelInterstitialAd(false);
    }
   
}
