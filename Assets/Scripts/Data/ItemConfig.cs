using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemConfig : ScriptableObject
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private string _title;
    
    [SerializeField]
    private string _description;

    [SerializeField]
    private string _rarity;

    public int Id => _id;

    public string Title => _title;

    public string Description => _description;

    public string Rarity => _rarity;
}
