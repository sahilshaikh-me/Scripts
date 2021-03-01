using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class BannerAds : MonoBehaviour
{
    public static BannerAds Instance { get; set; } 
    private BannerView adbanner;
    private string idApp, idBanner;
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
        //testbannerid ca-app-pub-3940256099942544/6300978111
        idApp = "ca-app-pub-3487858250679116~8478620359";
       
        // real banner id ca-app-pub-3487858250679116/9491393083

        MobileAds.Initialize(idApp);
    ReqBanner();
    }
    public void ShowInterstitial()
    {
        RequestInterstial();
    }
    public void RequestInterstial()
    {
        // myreal ca-app-pub-3487858250679116/8642271885
        string insterstitialid = "ca-app-pub-3487858250679116/8642271885";
        // test ca-app-pub-3940256099942544/1033173712

        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        interstitial = new InterstitialAd(insterstitialid);
        interstitial.OnAdLoaded += HandleOnAdLoaded;

        interstitial.LoadAd(CreateNewRequest());

       

    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
    }

    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }
    public void ReqBanner()
    {
        idBanner = "ca-app-pub-3487858250679116/9491393083";
        adbanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Top);
        AdRequest request = AdRequest();
        adbanner.LoadAd(request);
        Debug.Log("Banner ad is working");

    }
    public void DestroyBanner()
    {
        if(adbanner != null)
        {
            adbanner.Destroy();
        }
    }
    AdRequest AdRequest()
    {
        return new AdRequest.Builder().Build();
       
    }
    // Update is called once per frame
    void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
