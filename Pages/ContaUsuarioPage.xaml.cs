namespace AppReciclique;

public partial class ContaUsuarioPage : ContentPage
{
    public ContaUsuarioPage()
    {
        InitializeComponent();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        lblBoasVindas.Text = $"Olá, {AppState.NomeUsuario}!";

        lblId.Text = $"ID do usuário: {AppState.IdUsuario}";
        lblNome.Text = $"Nome: {AppState.NomeUsuario}";
        lblEmail.Text = $"Email: {AppState.EmailUsuario}";
        lblNascimento.Text = $"Data de nascimento: {AppState.DataNascimentoUsuario}";
        lblTelefone.Text = $"Telefone: {AppState.TelefoneUsuario}";
        lblEndereco.Text = $"Endereço: {AppState.EnderecoUsuario}";
        lblCep.Text = $"CEP: {AppState.CepUsuario}";
        lblPlano.Text = AppState.PlanoUsuario;

  
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert("Sair", "Deseja sair da conta?", "Sim", "Não");

        if (confirmar)
        {
            AppState.NomeUsuario = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}
