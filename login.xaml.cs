namespace AppReciclique;

public partial class LoginPage : ContentPage
{
    Dictionary<string, string> usuarios = new Dictionary<string, string>()
    {
     { "pamela@etec.com", "123" },
     { "marcos@etec.com", "123" },
     { "maeli@etec.com", "123" },
     { "gabriel@etec.com", "123" }
    };


    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text?.Trim() ?? "";
        string senha = txtSenha.Text?.Trim() ?? "";

        if (!usuarios.ContainsKey(email) || usuarios[email] != senha)
        {
            await DisplayAlert("Erro", "Email ou senha inválidos", "OK");
            return;
        }

        // 👇 define dados por usuário
        switch (email)
        {
            case "pamela@etec.com":
                AppState.IdUsuario = 1;
                AppState.NomeUsuario = "Pamela";
                AppState.EmailUsuario = email;
                AppState.TelefoneUsuario = "(14) 99999-1111";
                AppState.DataNascimentoUsuario = "10/01/2004";
                AppState.EnderecoUsuario = "Rua das Flores, 100 - Marília/SP";
                AppState.CepUsuario = "17500-000";
                break;

            case "marcos@etec.com":
                AppState.IdUsuario = 2;
                AppState.NomeUsuario = "Marcos";
                AppState.EmailUsuario = email;
                AppState.TelefoneUsuario = "(11) 99999-2222";
                AppState.DataNascimentoUsuario = "20/02/2004";
                AppState.EnderecoUsuario = "Av. Brasil, 200 - Guarulhos/SP";
                AppState.CepUsuario = "07000-000";
                break;

            case "maeli@etec.com":
                AppState.IdUsuario = 3;
                AppState.NomeUsuario = "Maeli";
                AppState.EmailUsuario = email;
                AppState.TelefoneUsuario = "(11) 99999-3333";
                AppState.DataNascimentoUsuario = "15/03/2005";
                AppState.EnderecoUsuario = "Rua Central, 300 - São Paulo/SP";
                AppState.CepUsuario = "01000-000";
                break;

            case "gabriel@etec.com":
                AppState.IdUsuario = 4;
                AppState.NomeUsuario = "Gabriel";
                AppState.EmailUsuario = email;
                AppState.TelefoneUsuario = "(11) 99999-4444";
                AppState.DataNascimentoUsuario = "05/04/2003";
                AppState.EnderecoUsuario = "Rua Verde, 400 - Osasco/SP";
                AppState.CepUsuario = "06000-000";
                break;
        }

        // 👇 padrão do sistema
        AppState.PlanoUsuario = "Plano gratuito";

        // 👇 NÃO mexe em pontos aqui
        AppState.VerificarNivel();

        await DisplayAlert("Sucesso", "Login realizado!", "OK");

        Application.Current.MainPage = new NavigationPage(new MainPage());
    }
}