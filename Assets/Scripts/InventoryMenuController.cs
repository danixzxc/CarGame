using Profile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/inventoryMenu" };
    private readonly ProfilePlayer _profilePlayer;
    private readonly InventoryMenuView _view;

    public InventoryMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _view = LoadView(placeForUi);
        _view.Init(StartGame);
    }

    private InventoryMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);

        return objectView.GetComponent<InventoryMenuView>();
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}


