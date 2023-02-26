using Zenject;

public class ItemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ItemManager itemManager = new ItemManager();
        Container.Bind<ItemManager>().FromInstance(itemManager).AsSingle();
    }
}
