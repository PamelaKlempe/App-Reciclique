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


        lblId.Text = AppState.IdUsuario.ToString();
        lblNome.Text = AppState.NomeUsuario;
        lblEmail.Text = AppState.EmailUsuario;
        lblNascimento.Text = AppState.DataNascimentoUsuario;
        lblTelefone.Text = AppState.TelefoneUsuario;
        lblEndereco.Text = AppState.EnderecoUsuario;
        lblCep.Text = AppState.CepUsuario;

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
            //LIMPA OS DADOS DO USUÁRIO NA MEMÓRIA
            AppState.IdUsuario = 0;
            AppState.NomeUsuario = "";
            AppState.EmailUsuario = "";
            AppState.TelefoneUsuario = "";
            AppState.DataNascimentoUsuario = "";
            AppState.EnderecoUsuario = "";
            AppState.CepUsuario = "";

            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

    }
}
