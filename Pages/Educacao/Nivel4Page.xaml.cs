namespace AppReciclique.Pages.Educacao;

public partial class Nivel4Page : ContentPage
{
    public Nivel4Page()
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

    async void OnComoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@pdufabc2026/photo/7632371164370767125?lang=pt-BR&q=sobre%20entulho&t=1777667557467");
    }

    async void OnAspiradorClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@luizcesarpro/video/7194818619660946694?lang=pt-BR&q=sobre%20entulho&t=1777667557467");
    }

    async void OnOndeClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@solucoesengenharia/video/7095705357611224325?lang=pt-BR&q=sobre%20entulho&t=1777667557467");
    }

    async void OnEcoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=4ZCRgUhYVMQ");
    }

    async void OnProjetoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=yxsdd4dig_M");
    }

    async void OnTrataClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 20;

        await DisplayAlert("Parabéns!", "Você ganhou 20 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=_F5PccMHuGU");
    }
}