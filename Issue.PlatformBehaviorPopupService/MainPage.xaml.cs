using CommunityToolkit.Maui.Core;
using Issue.PlatformBehaviorPopupService.Behaviors;
using Issue.PlatformBehaviorPopupService.ViewModels;

namespace Issue.PlatformBehaviorPopupService;

public partial class MainPage : ContentPage
{
    private readonly IPopupService _popupService;
    private MyPlatformBehavior _behavior = new();

    int count = 0;

    public MainPage(IPopupService popupService)
    {
        InitializeComponent();
        _popupService = popupService;
        Behaviors.Add(_behavior);
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        _popupService.ShowPopup<PopupViewModel>(onPresenting: (vm) => vm.PopupText = CounterBtn.Text);
    }
}

