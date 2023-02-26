using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInventoryItemSelectedSignal
{
    public InventoryItemView ItemView { get; private set; }
    public OnInventoryItemSelectedSignal(InventoryItemView view)
    {
        ItemView = view;
    }
}
