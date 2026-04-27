using AppReciclique.Helpers;

namespace AppReciclique;

public partial class HistoricoPage : ContentPage
{
    SQLiteHelper db;

    public HistoricoPage()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");
        db = new SQLiteHelper(dbPath);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var lista = await db.ListarAgendamentos();
            listaHistorico.ItemsSource = lista;

            // Se não tiver nada salvo
            if (lista.Count == 0)
            {
                await DisplayAlert("Aviso", "Nenhum agendamento encontrado", "OK");
            }
        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Erro ao carregar histórico", "OK");
        }
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