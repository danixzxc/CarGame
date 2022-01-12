using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleViewBase : MonoBehaviour
{
    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1xGslK2RytK7OS8fW59_J50O0cXk19-mb";
    
    private DailyRewardView _dailyRewardView;
    private Reward[] _dataSpriteBundles;

    private AssetBundle _spritesAssetBundle;


    public IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();

        if (_spritesAssetBundle == null )
        { 
            Debug.LogError($"AssetBundle {_spritesAssetBundle} failed to load");
            yield break;
        }

        SetDownloadAssets(_dailyRewardView);
        yield return null;
    }

    private IEnumerator GetSpritesAssetBundle()
    {


        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _spritesAssetBundle);
    }


    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete");
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    private void SetDownloadAssets(DailyRewardView dailyRewardView)
    {
        _dailyRewardView = dailyRewardView;
        _dataSpriteBundles = _dailyRewardView.Rewards.ToArray();
        foreach (var data in _dataSpriteBundles)
            data.SpriteImage.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.IdImage);

    }
}
