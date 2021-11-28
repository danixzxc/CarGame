using System;
using System.Collections.Generic;

public interface IInventoryView // можно и удалить в принципе
{
    event Action<IItem> Selected;
    event Action<IItem> Deselected;
    void Display(IReadOnlyList<IItem> items);
    void Hide();
}
