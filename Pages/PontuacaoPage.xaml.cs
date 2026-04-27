namespace AppReciclique;

public partial class PontuacaoPage : ContentPage
{
    public PontuacaoPage()
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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        int pontos = AppState.Pontos;

        AppState.VerificarNivel(); // 👈 CENTRALIZA

        lblPontos.Text = pontos.ToString();
        lblNivel.Text = AppState.NivelUsuario;
        lblIconeNivel.Text = AppState.IconeNivel;
    }

      
  

}