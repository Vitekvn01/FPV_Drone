using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

public class AdController : SingletonBase<AdController>
{
    private void Start()
    {
        int adTypes = AppodealAdType.Interstitial | AppodealAdType.RewardedVideo;
        string appKey = "YOUR_APPODEAL_APP_KEY";
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, adTypes);
        Appodeal.SetAutoCache(adTypes, false);
        Appodeal.Cache(adTypes);
        AppodealCallbacks.RewardedVideo.OnFinished += OnRewardedVideoFinished;
    }
    public void OnInitializationFinished(object sender, SdkInitializedEventArgs e)
    {
        Debug.Log("Appodeal иницилизирован");
    }

    public void ShowInterstitial()
    {
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }

        Appodeal.Cache(AppodealAdType.Interstitial);
    }

    public void ShowRewarded()
    {
        if (Appodeal.IsLoaded(AppodealAdType.RewardedVideo))
        {
            Appodeal.Show(AppodealShowStyle.RewardedVideo);
        }

        Appodeal.Cache(AppodealAdType.RewardedVideo);
    }


    private void OnRewardedVideoFinished(object sender, RewardedVideoFinishedEventArgs e)
    {
        PlayerController.Instance.AddPlayerDrone(3);
    }

}
