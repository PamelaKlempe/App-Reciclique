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

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=O50WI7aE2fI");
    }

    async void OnPlasticoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=lgk52ealccs");
    }

    async void OnPapelClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=1Con8Yx6wO4");
    }

    async void OnMetalClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 10;

        await DisplayAlert("Parabéns!", "Você ganhou 10 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=2dGdG3s7u9A");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}