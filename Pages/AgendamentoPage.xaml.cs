using AppReciclique.Helpers;
using AppReciclique.Models;
using System.Text.Json;

namespace AppReciclique;

public partial class AgendamentoPage : ContentPage
{
    SQLiteHelper db; //  DECLARAÇÃO DO BANCO

    public AgendamentoPage()
    {
        InitializeComponent();

        //  CONSTRUTOR 
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
        string tipo = pickerTipo.SelectedItem?.ToString();
        string endereco = txtEndereco.Text;
        string numero = txtNumero.Text;
        string complemento = txtComplemento.Text;
        string telefone = txtTelefone.Text;
        DateTime data = dataColeta.Date;
        TimeSpan hora = horaColeta.Time;
        string obs = txtObs.Text;

        // VALIDAÇÃO PRIMEIRO (CORRETO)
        if (string.IsNullOrWhiteSpace(tipo) || string.IsNullOrWhiteSpace(endereco))
        {
            await DisplayAlert("Erro", "Preencha os campos obrigatórios", "OK");
            return;
        }

        //  MONTA ENDEREÇO COMPLETO
        string enderecoCompleto = string.IsNullOrWhiteSpace(numero) && string.IsNullOrWhiteSpace(complemento)
            ? endereco
            : $"{endereco}, {numero} {complemento}";

        //  CRIA OBJETO
        var novo = new Agendamento
        {
            Tipo = tipo,
            Endereco = enderecoCompleto,
            Data = data,
            Hora = hora.ToString(@"hh\:mm"),
            Telefone = telefone,
            Observacao = obs
        };

        // SALVA NO BANCO
        await db.SalvarAgendamento(novo);

        // SALVA COLETAS
        AppState.TotalColetas++;

        //  SALVA RESUMO
        string resumo = $"{data:dd/MM} às {hora}";
        AppState.UltimoAgendamento = resumo;

        //  SOMA PONTOS

        if (tipo?.Contains("Super") == true)
        {
            AppState.Pontos += 50;
        }
        else
        {
            AppState.Pontos += 30;
        }

        AppState.VerificarNivel();

        AppState.AdicionarNotificacao($"Você ganhou pontos por uma coleta ({tipo})!");

        //  MOSTRA SUA NOTIFICAÇÃO BONITA
        lblSucesso.IsVisible = true;

        await lblSucesso.FadeTo(1, 300);
        await Task.Delay(2000);
        await lblSucesso.FadeTo(0, 300);

        lblSucesso.IsVisible = false;

        pickerTipo.SelectedItem = null;
        txtCep.Text = "";
        txtEndereco.Text = "";
        txtNumero.Text = "";
        txtComplemento.Text = "";
        txtTelefone.Text = "";
        txtObs.Text = "";

    }


    private async void OnBuscarCep(object sender, EventArgs e)
    {
        try
        {
            string cep = txtCep.Text;

            if (string.IsNullOrEmpty(cep))
                return;

            HttpClient client = new HttpClient();
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await client.GetStringAsync(url);

            var endereco = JsonSerializer.Deserialize<Endereco>(response);

            if (endereco != null)
            {
                txtEndereco.Text = $"{endereco.logradouro}, {endereco.bairro} - {endereco.localidade}";
            }
        }
        catch
        {
            await DisplayAlert("Erro", "Não foi possível buscar o CEP", "OK");
        }
    }

    private void OnEditarClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(AppState.UltimoAgendamento))
        {
            DisplayAlert("Editar", "Função de edição em desenvolvimento", "OK");
        }
    }

    private void OnNovoClicked(object sender, EventArgs e)
    {
        pickerTipo.SelectedItem = null;
        txtCep.Text = "";
        txtEndereco.Text = "";
        txtNumero.Text = "";
        txtComplemento.Text = "";
        txtTelefone.Text = "";
        txtObs.Text = "";
    }

    public class Endereco
    {
        public string? logradouro { get; set; }
        public string? bairro { get; set; }
        public string? localidade { get; set; }
    }



}