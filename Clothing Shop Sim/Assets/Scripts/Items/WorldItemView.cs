using UnityEngine;

public class WorldItemView : MonoBehaviour, IItemView
{
    [SerializeField]
    private SpriteRenderer renderer;

    public void DisplayItem(VisualItem item)
    {
        renderer.sprite = item != null ? item.DisplayableItem : null;
    }
}
