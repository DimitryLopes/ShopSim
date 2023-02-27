using Zenject;

public class JobInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        JobManager jobManager = new JobManager();
        Container.Bind<JobManager>().FromInstance(jobManager).AsSingle();
        Container.BindFactory<Job, SignalBus, ItemManager, JobView, JobView.Factory>().AsSingle();
    }
}
