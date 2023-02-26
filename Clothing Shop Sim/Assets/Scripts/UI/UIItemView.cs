using UnityEngine;
using UnityEngine.UI;

public class UIItemView : MonoBehaviour, IItemView
{
    [SerializeField]
    private Image renderer;

    public void DisplayItem(VisualItem item)
    {
        renderer.sprite = item != null ? item.DisplayableItem : null;
    }

    public void DisplayItem(Sprite sprite)
    {
        renderer.sprite = sprite != null ? sprite : null;
    }
}
