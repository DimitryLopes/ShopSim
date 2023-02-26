using UnityEditor;
using UnityEngine;

public class Item
{
    protected const string ITEM_ICON_PATH = "Assets/Sprites/Clothes/Icons/";
    private const string ICON_PREFIX = "Icon";

    public ItemType Type { get; }
    public string Name { get; }
    public int Quantity { get; set; }

    public Sprite GetSpriteIcon()
    {
        Sprite sprite = (Sprite)AssetDatabase.LoadAssetAtPath(ITEM_ICON_PATH + Type + ICON_PREFIX, typeof(Sprite));
        return sprite;
    }
}
