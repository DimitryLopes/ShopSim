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
    [SerializeField]
    private GameObject container;

    public bool IsActive => gameObject.activeSelf;
    public VisualItem Item { get; private set; }

    private bool isSelected;

    [Inject]
    public void Construct(VisualItem item)
    {
        DisplayItem(item);
        selectButton.onClick.AddListener(OnButtonClicked);
    }

    public void DisplayItem(VisualItem item)
    {
        Item = item;
        Deselect();
        itemView.DisplayItem(item.ItemIcon);
        gameObject.SetActive(true);
    }

    private void OnButtonClicked()
    {
        if (!isSelected)
        {
            signalBus.Fire(new OnInventoryItemSelectedSignal(this));
        }
        else
        {
            signalBus.Fire(new OnInventoryItemSelectedSignal(null));
        }
    }

    public void Select()
    {
        selectedFrame.color = selectedColor;
        isSelected = true;
    }

    public void Deselect()
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

    public void ShowContainer(bool value = true)
    {
        container.SetActive(value);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ShowContainer(false);
    }

    public class Factory : PlaceholderFactory<VisualItem, InventoryItemView> { }
}
