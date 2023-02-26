using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlidingScreen : UIScreen
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    private Transform screenTransform;


    protected override void DoShowAnimation()
    {
        screenTransform.LeanMoveLocalY(endPosition.localPosition.y, animationDuration).setEase(ease).setOnComplete(EnableButtons);
    }

    protected override void DoHideAnimation()
    {
        screenTransform.LeanMoveLocalY(startPosition.localPosition.y, animationDuration).setEase(ease).setOnComplete(Close);
    }
}
