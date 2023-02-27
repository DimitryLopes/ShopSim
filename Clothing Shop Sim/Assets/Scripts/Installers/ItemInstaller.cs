using Zenject;

public class ItemInstaller : MonoInstaller
{
    [Inject]
    private SignalBus signalBus;
    public override void InstallBindings()
    {
        PlayerInventory playerInventory = new PlayerInventory();
        ItemManager itemManager = new ItemManager(playerInventory, signalBus);

        Container.Bind<ItemManager>().FromInstance(itemManager).AsSingle();
        Container.BindFactory<VisualItem, InventoryItemView, InventoryItemView.Factory>().AsSingle();
    }
}
