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

        AppState.VerificarNivel();

        int pontos = AppState.Pontos;



        lblPontos.Text = pontos.ToString();
        lblNivel.Text = AppState.NivelUsuario;
        imgNivel.Source = AppState.IconeNivel;
        lblColetas.Text = AppState.TotalColetas.ToString();
    }




}