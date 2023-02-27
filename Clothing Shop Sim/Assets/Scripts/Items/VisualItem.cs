using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Cloth")]
public class VisualItem : Item
{
    [SerializeField]
    private Sprite[] spriteSheet;
    [SerializeField]
    private Sprite mannequinDisplayable;
    [SerializeField]
    private Sprite iconSprite;
    [SerializeField]
    private int price;

    public bool Equipped { get; set; }

    public int Price => price;
    public Sprite[] SpriteSheet => spriteSheet;
    public Sprite ItemIcon => iconSprite;
    public Sprite MannequinDisplayable => mannequinDisplayable;
}
