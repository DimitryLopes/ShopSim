public class OnItemUnequippedSignal
{
    public ItemType Type { get; private set; }

    public OnItemUnequippedSignal(ItemType type)
    {
        Type = type;
    }
}

