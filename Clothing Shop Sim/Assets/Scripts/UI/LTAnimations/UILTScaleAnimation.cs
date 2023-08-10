using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILTScaleAnimation : MonoBehaviour
{
    [SerializeField]
    private LeanTweenType ease;
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private float duaration;
    [SerializeField]
    private bool animateOnEnable;
    [SerializeField]
    private bool loopAnimation;

    private Vector3 defaultScale;

    private void Awake()
    {
        defaultScale = transform.localScale;
    }

    private void Start()
    {
        if (!animateOnEnable)
        {
            DoScaleUpAnimation();
        }
    }

    void OnEnable()
    {
        if (animateOnEnable)
        {
            transform.localScale = defaultScale;
            DoScaleUpAnimation();
        }
    }

    private void DoScaleUpAnimation()
    {
        if(loopAnimation)
        {
            transform.LeanScale(target, duaration).setOnComplete(DoScaleDownAnimation).setEase(ease);
        }
        else
        {
            transform.LeanScale(target, duaration).setEase(ease);
        }
    }

    private void DoScaleDownAnimation()
    {
        transform.LeanScale(defaultScale, duaration).setOnComplete(DoScaleUpAnimation).setEase(ease);
    }

    private void OnDisable()
    {
        if (animateOnEnable)
        {
            transform.localScale = defaultScale;
        }
    }
}
