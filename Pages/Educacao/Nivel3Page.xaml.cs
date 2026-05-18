namespace AppReciclique.Pages.Educacao;

public partial class Nivel3Page : ContentPage
{
    public Nivel3Page()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    async void OnOqueClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/shorts/TRzyDskzmkI");
    }

    async void OnToxicoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/shorts/0ccFOlDMBq8");
    }

    async void OnTratarClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=Vdfqhyu2vns&t=58s");
    }

    async void OnIdentifcarClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=VSmXSEHRL3E");
    }
    async void OnCuriosidadeClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=sfa-jnXtA84");
    }
}