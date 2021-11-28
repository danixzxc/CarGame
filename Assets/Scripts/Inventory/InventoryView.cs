using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour //должна наследоваться от монобеха , MonoBehaviour
                                           //интерфейс ничего не делает просто в консоль выводит, его вообще удалить можно и только от монобеха наследоваться
{
    public event Action<IItem> Selected;
    public event Action<IItem> Deselected;

    [SerializeField]
    RectTransform itemsGrid;
   // public InventoryModel InventoryModel;

    //private IReadOnlyList<Item> _items;
    public void Display(IReadOnlyList<IItem> items)
    {
        // _items = (List<Item>)InventoryModel.GetEquippedItems();
        // for (int i = 0; i < _items.Count; i++)
        // {
        //     _items.EquipItem()
        //}
        foreach (var item in items) //не понятно как получать предметы по игре, отрисовываться они должны правильно но не ясно как проверить
        {
            var icon = new GameObject("Icon");
            icon.AddComponent<Image>().sprite = item.Sprite;
        }
        
    }

    public void Hide() //можно перенести в инвенториКонтроллер чтобы там была только логика
        // прикрепить на кнопку exit в менюшке инвентаря
    {
        Debug.Log($"Close Inventory");
        //запуск игры или вернуться на прошлую менюшку
    }

    protected virtual void OnSelected(IItem item) //при нажатию на ячейку инвенторя, на слот
    {
        Selected?.Invoke(item); //нажимая на слот вызываем ивент Selected
    }

    protected virtual void OnDeselected(IItem item)
    {
        Deselected?.Invoke(item);
    }
}
