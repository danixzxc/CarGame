using UnityEngine;

public interface IItem
{
    int Id { get; set; }
    ItemInfo Info { get; set; }

    Sprite Sprite { get; set; }
}
