using Zenject;
using UnityEngine;

public class JobInstaller : MonoInstaller
{
    [SerializeField]
    private JobView jobView;

    public override void InstallBindings()
    {
        JobManager jobManager = new JobManager();
        Container.Bind<JobManager>().FromInstance(jobManager).AsSingle();
        Container.BindFactory<Job, SignalBus, ItemManager, JobView, JobView.Factory>().FromComponentInNewPrefab(jobView);
    }
}
