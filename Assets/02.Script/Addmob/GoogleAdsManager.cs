using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdsManager : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3940256099942544~3347511713";
    private readonly string test_UniID = "ca-app-pub-3940256099942544~337511712";
    private readonly string test_deviceID = "48195897-e099-4f7a-9358-761268d18f84";
    private InterstitialAd screenAd;

    private void Start()
    {
        InitAd();
        MobileAds.Initialize(initStatus => { });
        Invoke("Show", 5f);
    }


    private void InitAd()
    {

        string id = Debug.isDebugBuild ? test_UniID : unitID;
        screenAd = new InterstitialAd(id);
        AdRequest request = new AdRequest.Builder().Build();
        screenAd.LoadAd(request);
        screenAd.OnAdClosed += (sender, e) => Debug.Log("±¤°í°¡ ´ÝÈû");
        screenAd.OnAdLoaded += (sender, e) => Debug.Log("±¤°í°¡ ·ÎµåµÊ");
    }

    public void Show()
    {
        StartCoroutine("ShowScreenAd");
    }

    private IEnumerator ShowScreenAd()
    {
        while(!screenAd.IsLoaded())
        {
            yield return null;
        }
        screenAd.Show();
    }

}
