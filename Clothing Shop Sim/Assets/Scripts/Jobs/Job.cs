using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Job", menuName = "ScriptableObjects/Job")]
public class Job : ScriptableObject
{
    [SerializeField]
    private List<VisualItem> itemRequirements;
    [SerializeField]
    private int rewardAmount;
    [SerializeField]
    private string jobName;
    [SerializeField]
    private string jobWorkButtonName;

    public List<VisualItem> ItemRequirement => itemRequirements;
    public int RewardAmount => rewardAmount;
    public string JobName => jobName;
    public string JobWorkButtonName => jobWorkButtonName;
}
