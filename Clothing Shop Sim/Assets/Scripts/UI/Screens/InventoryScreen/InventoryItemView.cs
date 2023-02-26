using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryItemView : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;

    [SerializeField]
    private Button selectButton;
    [SerializeField]
    private Image selectedFrame;
    [SerializeField]
    private UIItemView itemView;
    [SerializeField]
    private Color mouseHoverColor;
    [SerializeField]
    private Color selectedColor;
    [SerializeField]
    private Color deselectedColor;

    public bool IsActive => gameObject.activeSelf;

    private bool isSelected;

    [Inject]
    public void Construct(VisualItem item)
    {
        DisplayItem(item);
        selectButton.onClick.AddListener(OnButtonClicked);
    }

    public void DisplayItem(VisualItem item)
    {
        itemView.DisplayItem(item);
    }

    private void OnButtonClicked()
    {
        signalBus.Fire(new OnInventoryItemSelectedSignal(this));
    }

    public void Select()
    {
        selectedFrame.color = selectedColor;
        isSelected = true;
    }

    public void Diselect()
    {
        selectedFrame.color = deselectedColor;
        isSelected = false;
    }

    private void OnMouseOver()
    {
        if (!isSelected)
        {
            selectedFrame.color = mouseHoverColor;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public class Factory : PlaceholderFactory<VisualItem, InventoryItemView> { }
}
