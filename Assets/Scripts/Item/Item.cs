using UnityEngine;

public class Item :  MonoBehaviour, IItem
{
    public int Id { get; set; }
    public ItemInfo Info { get; set; }
    
    
    //спрайт, визуал предмета 
    public Sprite Sprite { get; set; }
}
