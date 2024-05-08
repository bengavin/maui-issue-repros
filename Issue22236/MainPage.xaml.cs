using Microsoft.Maui.Graphics.Skia;

namespace Issue22236;

public partial class MainPage : ContentPage
{
    int count = 0;
    public static BindableProperty ResizedImageProperty = BindableProperty.Create(
        nameof(ResizedImage),
        typeof(ImageSource),
        typeof(MainPage));
    public ImageSource ResizedImage
    {
        get => (ImageSource)GetValue(ResizedImageProperty);
        set => SetValue(ResizedImageProperty, value);
    }

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        DoImageResize();

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private Microsoft.Maui.Graphics.IImage _resizedImage;
    private async Task DoImageResize()
    {
        var service = new SkiaImageLoadingService();
        using var image = service.FromStream(await FileSystem.OpenAppPackageFileAsync("dotnet_bot.scale-400.png"));
        if (_resizedImage != null) { _resizedImage.Dispose(); _resizedImage = null; }

        // Make sure our variable doesn't somehow get disposed
        _resizedImage = image.Resize(120, 120, ResizeMode.Fit, false);
        ResizedImage = ImageSource.FromStream(() => _resizedImage.AsStream(ImageFormat.Jpeg, 0.75f));
    }
}

