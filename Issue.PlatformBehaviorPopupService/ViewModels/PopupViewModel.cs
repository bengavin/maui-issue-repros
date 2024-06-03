using CommunityToolkit.Mvvm.ComponentModel;

namespace Issue.PlatformBehaviorPopupService.ViewModels;
public partial class PopupViewModel : ObservableObject
{

    [ObservableProperty]
    private string? _popupText;
}
