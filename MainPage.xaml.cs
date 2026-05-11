namespace AppReciclique;

public partial class MainPage : ContentPage
{

    List<string> parceiros = new List<string>
    {
        "banner1.jpg",
        "banner2.jpg",
        "banner3.jpg",
        "banner4.jpg",
        "banner5.jpg",
        "banner6.jpg",
        "banner7.jpg",
        "banner8.jpg",
        "banner9.jpg",
        "banner10.jpg",
    };

    public MainPage()
    {
        InitializeComponent();

        carouselParceiros.ItemsSource = parceiros;
    }

    

    private async void OnAgendarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgendamentoPage());
    }

    private async void OnPontosClicked(object sender, EventArgs e)
    {
        // Placeholder navigation or action for Pontos
        await Navigation.PushAsync(new PontuacaoPage());
    }

    private async void OnHistoricoClicked(object sender, EventArgs e)
    {
        // Placeholder navigation or action for Histórico
        await Navigation.PushAsync(new HistoricoPage());
    }

    private async void OnEducacaoClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new EducacaoPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnMapaClicked(object sender, EventArgs e)
    {
        // Placeholder action for Mapa; replace with Navigation.PushAsync(new MapaPage()) if you add a MapaPage
        await Navigation.PushAsync(new MapaPage());
    }

    private async void OnNotificacoesClicked(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        // Placeholder action for Avisos
        await Navigation.PushAsync(new NotificacoesPage());
    }

    private async void OnContaClicked(object sender, EventArgs e)
    {
        // Navigate to existing ContaUsuarioPage
        await Navigation.PushAsync(new ContaUsuarioPage());
    }


    private async void OnAjudaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AjudaPage());
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        int pontos = AppState.Pontos;

        lblPontos.Text = pontos.ToString();

        lblColetas.Text = AppState.TotalColetas.ToString();

        lblNivel.Text = AppState.NivelUsuario;
        lblIconeNivel.Text = AppState.IconeNivel;

        lblSaudacao.Text = $"Olá, {AppState.NomeUsuario}";
    }

    private async void OnBannerClicked(object sender, EventArgs e)
    {
        var image = sender as Image;

        if (image?.Source is FileImageSource fileSource)
        {
            string banner = fileSource.File;

            switch (banner)
            {
                case "banner1.jpg":
                    await Launcher.Default.OpenAsync("https://www.uber.com/br/pt-br/");
                    break;

                case "banner2.jpg":
                    await Launcher.Default.OpenAsync("https://www.marilia.sp.gov.br/");
                    break;

                case "banner3.jpg":
                    await Launcher.Default.OpenAsync("https://www.ifood.com.br/");
                    break;

                case "banner4.jpg":
                    await Launcher.Default.OpenAsync("https://99app.com/");
                    break;

                case "banner5.jpg":
                    await Launcher.Default.OpenAsync("https://www.nike.com.br/");
                    break;

                case "banner6.jpg":
                    await Launcher.Default.OpenAsync("https://www.americanas.com.br/");
                    break;

                case "banner7.jpg":
                    await Launcher.Default.OpenAsync("https://www.riachuelo.com.br/");
                    break;

                case "banner8.jpg":
                    await Launcher.Default.OpenAsync("https://www.semparar.com.br/");
                    break;

                case "banner9.jpg":
                    await Launcher.Default.OpenAsync("https://www.magazineluiza.com.br/");
                    break;

                case "banner10.jpg":
                    await Launcher.Default.OpenAsync("https://www.credpam.com.br/");
                    break;
            }
        }
    }


}
























