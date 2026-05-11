namespace AppReciclique.Pages.Educacao;

public partial class Nivel6Page : ContentPage
{
	public Nivel6Page()
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

    async void OnPaperClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/shorts/1TKTffuNpjg");
    }

    async void OnColheresClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@gift.ideas6769/video/7532360512433097997?lang=pt-BR&q=reutiliza%C3%A7%C3%A3o%20criativa&t=1777744658461");
    }

    async void OnOvelhaClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/shorts/5sIzX5hdVhM");
    }

    async void OnArteClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@bruk.wear/video/7413549320550534406?lang=pt-BR&q=sobre%20entulho&t=1777667557467");
    }

    async void OnIdeiaClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@diydasamanta/photo/7576107234355203346?lang=pt-BR&q=reutiliza%C3%A7%C3%A3o%20criativa&t=1777744658461");
    }

}