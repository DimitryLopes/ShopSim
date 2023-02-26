using UnityEditor;
using UnityEngine;

public class Item : ScriptableObject
{
    protected const string ITEM_ICON_PATH = "Assets/Sprites/Clothes/Icons/";
    private const string ICON_PREFIX = "Icon";

    [SerializeField]
    private ItemType type;
    [SerializeField]
    private string name;

    public ItemType Type => type;
    public string Name => name;
    public int Quantity { get; set; }

    public Sprite GetSpriteIcon()
    {
        Sprite sprite = (Sprite)AssetDatabase.LoadAssetAtPath(ITEM_ICON_PATH + Type + ICON_PREFIX, typeof(Sprite));
        return sprite;
    }
}
