using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displayable : MonoBehaviour
{
    private SpriteRenderer renderer;
    private VisualItem item;

    void Display(Direction direction)
    {
        Sprite sprite = item.GetSprite();
        renderer.sprite = sprite;
    }
}
