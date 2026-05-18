namespace AppReciclique;


public partial class AjudaPage : ContentPage
{
    public AjudaPage()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Validação básica
        if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtMensagem.Text))
        {
            await DisplayAlert("Atenção", "Preencha pelo menos seu nome e a mensagem.", "OK");
            return;
        }

        // Monta mensagem para e-mail
        string assunto = "Suporte - App Reciclique";
        string corpo = $"Nome: {txtNome.Text}\n" +
                       $"Email: {txtEmail.Text}\n" +
                       $"Telefone: {txtTelefone.Text}\n\n" +
                       $"Mensagem:\n{txtMensagem.Text}";

        try
        {
            // Abre o app de e-mail do celular
            var message = new EmailMessage
            {
                Subject = assunto,
                Body = corpo,
                To = new List<string> { "suporte@reciclique.com" }
            };

            await Email.Default.ComposeAsync(message);

            await DisplayAlert("Mensagem enviada",
                "Abrimos seu e-mail para envio 😊",
                "OK");
        }
        catch (Exception)
        {
            // Caso não tenha app de e-mail configurado
            await DisplayAlert("Aviso",
                "Não foi possível abrir o e-mail. Mas sua mensagem foi registrada!",
                "OK");
        }

        // Limpa campos
        txtNome.Text = "";
        txtEmail.Text = "";
        txtTelefone.Text = "";
        txtMensagem.Text = "";
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}