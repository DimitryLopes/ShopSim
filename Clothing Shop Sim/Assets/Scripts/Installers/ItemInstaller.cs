using UnityEngine;
using Zenject;

public class ItemInstaller : MonoInstaller
{
    [Inject]
    private SignalBus signalBus;
    [SerializeField]
    private InventoryItemView inventoryItemView;

    public override void InstallBindings()
    {
        PlayerInventory playerInventory = new PlayerInventory(signalBus);
        ItemManager itemManager = new ItemManager(playerInventory, signalBus);

        Container.Bind<ItemManager>().FromInstance(itemManager).AsSingle();
        Container.BindFactory<VisualItem, InventoryItemView, InventoryItemView.Factory>().FromComponentInNewPrefab(inventoryItemView);
    }
}
