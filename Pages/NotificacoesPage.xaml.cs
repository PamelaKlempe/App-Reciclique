namespace AppReciclique;

public partial class NotificacoesPage : ContentPage
{
    public NotificacoesPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // ALTERADO PARA O PEDIDO:
        // carrega as notificações salvas no AppState
        cvNotificacoes.ItemsSource = null;
        cvNotificacoes.ItemsSource = AppState.Notificacoes;
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}