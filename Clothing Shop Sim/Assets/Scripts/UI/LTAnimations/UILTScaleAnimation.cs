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
    private bool loop;

    private Vector3 defaultScale;

    void OnEnable()
    {
        defaultScale = transform.localScale;
        DoScaleUpAnimation();
    }

    private void DoScaleUpAnimation()
    {
        if(loop)
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
        transform.localScale = defaultScale;
    }
}
