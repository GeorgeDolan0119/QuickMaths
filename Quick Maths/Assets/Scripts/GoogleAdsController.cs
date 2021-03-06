using GoogleMobileAds.Api;
using UnityEngine;

public class GoogleAdsController : MonoBehaviour
{
    private InterstitialAd interstitial;


    private void OnEnable()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();

        GameManager.OnNewGame += RequestInterstitial;
        GameManager.OnEndGame += ShowAd;
    }


    private void OnDisable()
    {
        GameManager.OnNewGame -= RequestInterstitial;
        GameManager.OnEndGame -= ShowAd;
    }


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

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void ShowAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            this.interstitial.OnAdClosed += delegate { this.interstitial.Destroy(); };
        }
    }
}
