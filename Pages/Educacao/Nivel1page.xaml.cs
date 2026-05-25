namespace AppReciclique.Pages.Educacao;

public partial class Nivel1Page : ContentPage
{
    public Nivel1Page()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async void OnVidroClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://youtube.com/shorts/Rfrxh6H-vjM?si=KppfNZAsW44_CV8h");
    }

    async void OnPlasticoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://youtube.com/shorts/jOSS3vEcfgU?si=QSx_FKmbRYEoTqEZ");
    }

    async void OnPapelClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://youtube.com/shorts/d1cHOWyAGxw?si=f6lTRgMu5aoyRtDM");
    }

    async void OnMetalClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://youtube.com/shorts/jFBqMoWaDwc?si=zt7xvQ3bDVziXkSt");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}