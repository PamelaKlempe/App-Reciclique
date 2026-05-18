namespace AppReciclique.Pages.Educacao;

public partial class BonusPage : ContentPage
{
    public BonusPage()
    {
        InitializeComponent();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    async void OnComoClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 30;

        await DisplayAlert("Parabéns!", "Você ganhou 30 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=rK07ap1ukD8");
    }

    async void OnIdeiasClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 30;

        await DisplayAlert("Parabéns!", "Você ganhou 30 pontos!", "OK");

        await Launcher.OpenAsync("https://www.youtube.com/watch?v=NySYhwn8a5E");
    }

    async void OnQuizClicked(object sender, EventArgs e)
    {
        AppState.Pontos += 30;

        await DisplayAlert("Parabéns!", "Você ganhou 30 pontos!", "OK");

        await Launcher.OpenAsync("https://pt.quizur.com/trivia/quiz-de-reciclagem-IfI2");
    }

}
