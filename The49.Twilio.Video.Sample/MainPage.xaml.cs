namespace The49.Twilio.Video.Sample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void OnConnectClicked(object sender, EventArgs e)
    {
        var name = editor.Text?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            return;
        }

        await Shell.Current.Navigation.PushAsync(new VideoChatPage { RoomName = name });

    }
}