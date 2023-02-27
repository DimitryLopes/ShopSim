using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager
{
    const string JOBS_PATH = "ScriptableObjects/Jobs";

    public List<Job> AllJobs = new List<Job>();

    public JobManager()
    {
        GetAllJobs();
    }

    private void GetAllJobs()
    {
        Object[] jobs = Resources.LoadAll(JOBS_PATH, typeof(ScriptableObject));
        foreach (Job job in jobs)
        {
            AllJobs.Add(job);
        }
    }


}
