using UnityEngine;

public class UIScalingScreen : UIScreen
{
    protected override void OnBeforeHide()
    {
        screenTransform.LeanScale(Vector3.zero, animationDuration).setEase(ease).setOnComplete(Close);
    }

    protected override void OnBeforeShow()
    {
        screenTransform.LeanScale(Vector3.one, animationDuration).setEase(ease).setOnComplete(OnAfterShow);
    }
}
