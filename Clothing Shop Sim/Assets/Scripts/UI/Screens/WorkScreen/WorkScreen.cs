using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorkScreen : UISlidingScreen
{
    [Inject]
    private SignalBus signalBus;
    [Inject]
    private JobManager jobManager;
    [Inject]
    private ItemManager itemManager;
    [Inject]
    private JobView.Factory jobViewFactory;

    [SerializeField]
    private Transform jobsContainer;

    protected override void OnBeforeShow()
    {
        if (isFirstShow)
        {
            foreach (Job job in jobManager.AllJobs)
            {
                JobView view = jobViewFactory.Create(job, signalBus, itemManager);
                view.transform.SetParent(jobsContainer, false);
            }
        }
        base.OnBeforeShow();
    }
}
