using CommunityToolkit.Maui.Views;
using Issue.PlatformBehaviorPopupService.ViewModels;

namespace Issue.PlatformBehaviorPopupService.Views;

public partial class PopupView : Popup
{
	public PopupView(PopupViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}