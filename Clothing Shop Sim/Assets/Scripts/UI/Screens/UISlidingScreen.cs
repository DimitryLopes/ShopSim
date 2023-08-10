using UnityEngine;

public class UISlidingScreen : UIScreen
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform endPosition;

    protected override void OnBeforeShow()
    {
        screenTransform.LeanMoveLocal(endPosition.localPosition, animationDuration).setEase(ease).setOnComplete(OnAfterShow);
    }

    protected override void OnBeforeHide()
    {
        screenTransform.LeanMoveLocal(startPosition.localPosition, animationDuration).setEase(ease).setOnComplete(Close);
    }
}
