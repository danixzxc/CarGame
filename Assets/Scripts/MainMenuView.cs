using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] 
    private Button _buttonStart;
    
    [SerializeField]
    private Button _buttonInventory;

    public void Init(UnityAction startGame, UnityAction loadInventory)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonInventory.onClick.AddListener(loadInventory);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonInventory.onClick.RemoveAllListeners();
    }
}

