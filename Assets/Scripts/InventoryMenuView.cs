using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryMenuView : MonoBehaviour
{
    [SerializeField]
    private Button _buttonExit;

    public void Init(UnityAction startGame)
    {
        _buttonExit.onClick.AddListener(startGame);
    }

    protected void OnDestroy()
    {
        _buttonExit.onClick.RemoveAllListeners();
    }
}
