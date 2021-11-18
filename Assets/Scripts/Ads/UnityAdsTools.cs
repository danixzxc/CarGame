using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string _gameId = "4459196";
    private const string _bannerPlacementId = "Banner_Android";
    private const string _rewardPlacementId = "Rewarded_Android";
    private void Start()
    {
        Advertisement.Initialize(_gameId, true);
    }

    public void ShowBaner()
    {
        Advertisement.Show(_bannerPlacementId);
    }

    public void ShowRewardVideo()
    {
        Advertisement.Show(_rewardPlacementId);

    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("реклама началась");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        
    }

}
