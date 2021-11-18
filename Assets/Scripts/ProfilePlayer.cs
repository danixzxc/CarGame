using Profile;
using Tools;
using UnityEngine.Advertisements;

public class ProfilePlayer //текущее свойство игры
{
    public ProfilePlayer(float speedCar, UnityAdsTools unityAdsTools)
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speedCar);
        AnalyticTools = new UnityAnalyticTools();
        AdsShower = unityAdsTools;
        AdsListener = unityAdsTools;
    }

    public SubscriptionProperty<GameState> CurrentState { get; }

    public Car CurrentCar { get; }

    public IAnalyticTools AnalyticTools { get; }
    public IAdsShower  AdsShower { get; }
    public IUnityAdsListener AdsListener { get; }
}

