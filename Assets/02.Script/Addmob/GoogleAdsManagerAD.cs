using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleAdsManagerAD : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
    }

    // Update is called once per frame


    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
        SceneManager.LoadScene("LOBBY");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
   public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while(!interstitial.IsLoaded())
        {
            yield return null;
        }
        interstitial.Show();
    }
}