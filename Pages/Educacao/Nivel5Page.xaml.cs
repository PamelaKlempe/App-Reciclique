namespace AppReciclique.Pages.Educacao;

public partial class Nivel5Page : ContentPage
{
    public Nivel5Page()
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
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=Ekbd_hSQOhc");
    }

    async void OnCuidarClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=h7uOFU4QvSw");
    }

    async void OnCurtaClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=tjJvL8FP1IU");
    }

    async void OnCadeiraClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@ecoup_br/video/7603880727968550162?lang=pt-BR&q=a%C3%A7%C3%B5es%20e%20atitudes%20para%20o%20meio%20ambiente&t=1777674176750");
    }

    async void OnTempoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 25;

        await DisplayAlert("Parabéns!", "Você ganhou 25 pontos!", "OK");

        await Launcher.OpenAsync("https://www.tiktok.com/@marianadisse/video/7512516510192160056?lang=pt-BR&q=a%C3%A7%C3%B5es%20e%20atitudes%20para%20o%20meio%20ambiente&t=1777674176750");
    }

}