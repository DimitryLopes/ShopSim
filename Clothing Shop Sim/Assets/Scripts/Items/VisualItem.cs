using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Cloth")]
public class VisualItem : Item
{
    [SerializeField]
    private Sprite spriteSheet;
    [SerializeField]
    private Sprite mannequinDisplayable;
    [SerializeField]
    private Sprite iconSprite;
    [SerializeField]
    private int price;

    public int Price => price;
    public Sprite ItemIcon => iconSprite;
    public Sprite MannequinDisplayable => mannequinDisplayable;
}
