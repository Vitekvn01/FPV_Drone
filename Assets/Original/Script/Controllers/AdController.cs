using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

public class AdController : MonoBehaviour
{
    private void Start()
    {
        int adTypes = AppodealAdType.Interstitial | AppodealAdType.Banner | AppodealAdType.RewardedVideo | AppodealAdType.Mrec;
        string appKey = "YOUR_APPODEAL_APP_KEY";
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, adTypes);
    }

    public void OnInitializationFinished(object sender, SdkInitializedEventArgs e) { }
}
