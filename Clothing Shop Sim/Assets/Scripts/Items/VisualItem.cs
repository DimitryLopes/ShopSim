using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Cloth")]
public class VisualItem : Item
{
    [SerializeField]
    private Sprite[] spriteSheet;
    [SerializeField]
    private Sprite iconSprite;
    [SerializeField]
    private int price;
    [SerializeField]
    private bool equipped;

    public bool Equipped { get => equipped; set => equipped = value; }

    public int Price => price;
    public Sprite[] SpriteSheet => spriteSheet;
    public Sprite ItemIcon => iconSprite;
    public Sprite MannequinDisplayable => spriteSheet[7];
}
