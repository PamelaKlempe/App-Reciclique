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

    void AtualizarNivel(int pontos)
    {
        string nivel;
        string icone;

        if (pontos <= 100)
        {
            nivel = "Bronze";
            icone = "🟤";
        }
        else if (pontos <= 250)
        {
            nivel = "Prata";
            icone = "⚪";
        }
        else if (pontos <= 400)
        {
            nivel = "Ouro";
            icone = "🟡";
        }
        else if (pontos <= 1500)
        {
            nivel = "Platina";
            icone = "🔷";
        }
        else
        {
            nivel = "Diamante";
            icone = "💎";
        }

        lblNivel.Text = nivel;
        lblIconeNivel.Text = icone;
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

        lblPontos.Text = pontos.ToString(); // 👈 mantém

        AtualizarNivel(pontos); // 👈 chama o método

        lblSaudacao.Text = $"Olá, {AppState.NomeUsuario}";
    }

  
}
























