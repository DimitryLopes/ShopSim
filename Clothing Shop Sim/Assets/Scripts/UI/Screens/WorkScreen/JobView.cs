using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Zenject;

public class JobView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI jobNameText;
    [SerializeField]
    private TextMeshProUGUI jobButtonNameText;
    [SerializeField]
    private TextMeshProUGUI rewardAmountText;
    //turn this into a factory if possible
    [SerializeField]
    private List<UIItemView> itemRequirementViews;
    [SerializeField]
    private Button workButton;

    //Injection
    private SignalBus signalBus;
    private ItemManager itemManager;
    private Job job;

    [Inject]
    public void Create(Job job, SignalBus signalBus, ItemManager itemManager)
    {
        this.job = job;
        jobNameText.text = job.JobName;
        jobButtonNameText.text = job.JobWorkButtonName;
        rewardAmountText.text = job.RewardAmount.ToString();
        this.signalBus = signalBus;
        SetRequirementViews();
        workButton.onClick.AddListener(OnWorkButtonClicked);
    }

    private void OnWorkButtonClicked()
    {
        signalBus.Fire(new OnJobExcecutedSignal(job));
    }

    private void SetRequirementViews()
    {
        for (int i = 0; i < job.ItemRequirement.Count; i++)
        {
            itemRequirementViews[i].DisplayItem(job.ItemRequirement[i]);
        }
    }

    private void OnEnable()
    {
        foreach(VisualItem item in job.ItemRequirement)
        {
            if(itemManager.Inventory.EquipedItems.ContainsValue(item) == false)
            {
                workButton.interactable = false;
                return;
            }
        }
        workButton.interactable = true;
    }

    public class Factory : PlaceholderFactory<Job, SignalBus, ItemManager, JobView> { }
}
