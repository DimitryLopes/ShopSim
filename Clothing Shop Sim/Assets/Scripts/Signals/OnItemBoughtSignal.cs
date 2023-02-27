public class OnItemBoughtSignal
{
    public Item Item { get; private set; }

    public OnItemBoughtSignal(VisualItem item)
    {
        Item = item;
    }
}
