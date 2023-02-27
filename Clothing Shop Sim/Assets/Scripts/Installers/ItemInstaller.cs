using Zenject;

public class ItemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        PlayerInventory playerInventory = new PlayerInventory();
        ItemManager itemManager = new ItemManager(playerInventory);

        Container.Bind<ItemManager>().FromInstance(itemManager).AsSingle();
        Container.BindFactory<VisualItem, InventoryItemView, InventoryItemView.Factory>().AsSingle();
    }
}
