using UIKit;

namespace Issue.PlatformBehaviorPopupService.Behaviors;
public partial class MyPlatformBehavior : PlatformBehavior<VisualElement>
{
    protected override void OnAttachedTo(VisualElement bindable, UIView platformView)
    {
        base.OnAttachedTo(bindable, platformView);
        System.Diagnostics.Debug.WriteLine($"Attached to: {bindable.Id}");
    }

    protected override void OnDetachedFrom(VisualElement bindable, UIView platformView)
    {
        base.OnDetachedFrom(bindable, platformView);
        System.Diagnostics.Debug.WriteLine($"Detached from: {bindable.Id}");
    }
}
