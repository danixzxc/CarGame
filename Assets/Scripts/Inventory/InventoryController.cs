using System;
using System.Collections.Generic;

public class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly InventoryView _inventoryView;
    private readonly IItemsRepository _itemsRepository;

    public Action HideAction { get; } //когда закрываем окно инвентаря дёргаем делегат и вызываем onChangeState
    //пока на нём нету методов, они должны навешиваться извне, например когда нажимаем кнопку закрыть окно то вызываем метод онЧейнджСтате

    public InventoryController(List<ItemConfig> itemConfigs)
    {
        _inventoryModel = new InventoryModel();
        _inventoryView = new InventoryView();
        _itemsRepository = new ItemsRepository(itemConfigs);

        SubscribeView();
    }

    public void ShowInventory()
    {
        foreach (var item in _itemsRepository.Items.Values)
            _inventoryModel.EquipItem(item);

        var equippedItems = _inventoryModel.GetEquippedItems();
        _inventoryView.Display(equippedItems);
    }

    public void HideInventory() //можно и сразу сюда перенести модельку профайл плеера и менять стейт
    {
        _inventoryView.Hide();
        HideAction?.Invoke();
    }

    private void SubscribeView()
    {
        _inventoryView.Selected += OnItemSelected;
        _inventoryView.Deselected += OnItemDeselected;
    }

    protected override void OnDispose()
    {
        _inventoryView.Selected -= OnItemSelected;
        _inventoryView.Deselected -= OnItemDeselected;

        base.OnDispose();
    }

    private void OnItemSelected(IItem item)
    {
        _inventoryModel.EquipItem(item);
    }

    private void OnItemDeselected(IItem item)
    {
        _inventoryModel.UnEquipItem(item);
    }
}
