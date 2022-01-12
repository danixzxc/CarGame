using Game;
using Profile;
using Ui;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, 
        FightWindowView fightWindowView, StartFightView startFightView,
        DailyRewardView dailyRewardView, CurrencyView currencyView, AssetBundleViewBase assetBundleViewBase)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _fightWindowView = fightWindowView;
        _startFightView = startFightView;
        _dailyRewardView = dailyRewardView;
        _currencyView = currencyView;
        _assetBundleViewBase = assetBundleViewBase;

        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private DailyRewardController _dailyRewardController;
    private FightWindowController _fightWindowController;
    private StartFightController _startFightController;

    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly FightWindowView _fightWindowView;
    private readonly StartFightView _startFightView;
    private readonly DailyRewardView _dailyRewardView;
    private readonly CurrencyView _currencyView;
    private readonly AssetBundleViewBase _assetBundleViewBase;


    protected override void OnDispose()
    {
        ClearAll();

        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);

                _gameController?.Dispose();
                _dailyRewardController?.Dispose();
                break;

            case GameState.DailyReward:
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer, _dailyRewardView, _currencyView, _assetBundleViewBase);
                _dailyRewardController.RefreshView();

                _mainMenuController?.Dispose();
                break;

            case GameState.WeeklyReward:
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer, _dailyRewardView, _currencyView, _assetBundleViewBase);
                _dailyRewardController.RefreshView();

                _mainMenuController?.Dispose();
                break;

            case GameState.Fight:
                _fightWindowController = new FightWindowController(_placeForUi, _fightWindowView, _profilePlayer);
                _fightWindowController.RefreshView();

                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _startFightController?.Dispose();
                break;

            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
                _startFightController = new StartFightController(_placeForUi, _profilePlayer, _startFightView);
                _startFightController.RefreshView();

                _mainMenuController?.Dispose();
                _fightWindowController?.Dispose();
                break;

            default:
                ClearAll();
                break;
        }
    }

    private void ClearAll()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _dailyRewardController?.Dispose();
        _fightWindowController?.Dispose();
        _startFightController?.Dispose();
    }
}
