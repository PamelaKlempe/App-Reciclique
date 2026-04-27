namespace AppReciclique.Pages.Educacao;

public partial class Nivel2Page : ContentPage
{
	public Nivel2Page()
	{
		InitializeComponent();
	}


    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }


    async void OnLixoOrganicoClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=ljurLVHpdaw");
    }

    async void OnCompostagemClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/watch?v=AGAHzD8c2I8");
    }

    async void OnPassosClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/shorts/I065NWllAq0");
    }

    async void OnComoClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://www.youtube.com/shorts/cw6WHYqSIN8");
    }
}


