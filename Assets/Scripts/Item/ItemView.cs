using UnityEngine;
using UnityEngine.UI;

public class ItemView 
{

    [SerializeField]
    private Image _backGround;

    [SerializeField]
    private Image _spriteImage;

    [SerializeField]
    private TMPro.TMP_Text _itemText;


    public Image BackGround => _backGround;
    public Image SpriteImage => _spriteImage;
    public TMPro.TMP_Text ItemText => _itemText;
}
