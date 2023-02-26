using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualItemView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer renderer;

    public void DisplayItem(VisualItem item)
    {
        gameObject.SetActive(true);
        renderer.sprite = item != null ? item.DisplayableItem : null;
    }

    public void HideItem()
    {
        gameObject.SetActive(false);
    }
}
