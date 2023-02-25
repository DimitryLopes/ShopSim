using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualItem 
{
    private int price;
    private Sprite sprite;

    public int Price => price;

    public Sprite GetSprite()
    {
        return sprite;
    }
}
