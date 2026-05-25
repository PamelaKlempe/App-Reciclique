using AppReciclique.Helpers;
using AppReciclique.Models;
using System.Text.Json;

namespace AppReciclique;

public partial class AgendamentoPage : ContentPage
{
    SQLiteHelper db;
    bool buscandoCep;

    public AgendamentoPage()
    {
        InitializeComponent();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db3");
        db = new SQLiteHelper(dbPath);
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnAgendarClicked(object sender, EventArgs e)
    {
        string tipo = pickerTipo.SelectedItem?.ToString() ?? "";
        string endereco = txtEndereco.Text ?? "";
        string numero = txtNumero.Text ?? "";
        string complemento = txtComplemento.Text ?? "";
        string telefone = txtTelefone.Text ?? "";
        DateTime data = dataColeta.Date;
        TimeSpan hora = horaColeta.Time;
        string obs = txtObs.Text ?? "";

        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(endereco))
        {
            await DisplayAlert("Erro", "Preencha os campos obrigatorios", "OK");
            return;
        }

        string enderecoCompleto = string.IsNullOrWhiteSpace(numero) && string.IsNullOrWhiteSpace(complemento)
            ? endereco
            : $"{endereco}, {numero} {complemento}";

        var novo = new Agendamento
        {
            Tipo = tipo,
            Endereco = enderecoCompleto,
            Data = data,
            Hora = hora.ToString(@"hh\:mm"),
            Telefone = telefone,
            Observacao = obs
        };

        await db.SalvarAgendamento(novo);

        AppState.TotalColetas++;
        AppState.UltimoAgendamento = $"{data:dd/MM} as {hora}";

        if (tipo.Contains("Super"))
        {
            AppState.Pontos += 50;
        }
        else
        {
            AppState.Pontos += 30;
        }

        AppState.VerificarNivel();
        AppState.AdicionarNotificacao($"Voce ganhou pontos por uma coleta ({tipo})!");

        lblSucesso.IsVisible = true;

        await lblSucesso.FadeTo(1, 300);
        await Task.Delay(2000);
        await lblSucesso.FadeTo(0, 300);

        lblSucesso.IsVisible = false;

        LimparCampos();
    }

    private async void OnBuscarCep(object sender, EventArgs e)
    {
        await BuscarCepAsync();
    }

    private async void OnCepTextChanged(object sender, TextChangedEventArgs e)
    {
        string cep = SomenteNumeros(e.NewTextValue);

        if (cep.Length == 8)
        {
            await BuscarCepAsync();
        }
    }

    private async Task BuscarCepAsync()
    {
        try
        {
            if (buscandoCep)
                return;

            string cep = SomenteNumeros(txtCep.Text);

            if (cep.Length != 8)
                return;

            buscandoCep = true;

            using HttpClient client = new HttpClient();
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            string response = await client.GetStringAsync(url);
            Endereco? endereco = JsonSerializer.Deserialize<Endereco>(response);

            if (endereco != null && endereco.erro != true)
            {
                txtEndereco.Text = $"{endereco.logradouro}, {endereco.bairro} - {endereco.localidade}";
            }
            else
            {
                await DisplayAlert("CEP", "CEP nao encontrado", "OK");
            }
        }
        catch
        {
            await DisplayAlert("Erro", "Nao foi possivel buscar o CEP", "OK");
        }
        finally
        {
            buscandoCep = false;
        }
    }

    private void OnEditarClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(AppState.UltimoAgendamento))
        {
            DisplayAlert("Editar", "Funcao de edicao em desenvolvimento", "OK");
        }
    }

    private void OnNovoClicked(object sender, EventArgs e)
    {
        LimparCampos();
    }

    private void LimparCampos()
    {
        pickerTipo.SelectedItem = null;
        txtCep.Text = "";
        txtEndereco.Text = "";
        txtNumero.Text = "";
        txtComplemento.Text = "";
        txtTelefone.Text = "";
        txtObs.Text = "";
    }

    private static string SomenteNumeros(string? texto)
    {
        return new string((texto ?? "").Where(char.IsDigit).ToArray());
    }

    public class Endereco
    {
        public string? logradouro { get; set; }
        public string? bairro { get; set; }
        public string? localidade { get; set; }
        public bool? erro { get; set; }
    }
}
