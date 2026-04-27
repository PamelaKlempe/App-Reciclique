namespace AppReciclique;

public partial class MapaPage : ContentPage
{
    public MapaPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MapaWebView.Source = new HtmlWebViewSource { Html = GerarHtmlMapa() };
    }

    private string GerarHtmlMapa()
    {
        return @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'/>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css'/>
    <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
    <style>
        body { margin: 0; padding: 0; }
        #map { width: 100vw; height: 100vh; }
    </style>
</head>
<body>
    <div id='map'></div>
    <script>
        var map = L.map('map').setView([-22.2133, -49.9445], 14);

        L.tileLayer('https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png', {
            attribution: '© OpenStreetMap © CARTO'
        }).addTo(map);

        // Marcador do usuário
        L.marker([-22.2133, -49.9445])
            .addTo(map)
            .bindPopup('<b>📍 Você está aqui</b><br>Marília - SP')
            .openPopup();

        // Ícone verde para coletores
        var iconeVerde = L.icon({
            iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png',
            shadowUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png',
            iconSize: [25, 41], iconAnchor: [12, 41], popupAnchor: [1, -34]
        });

        // Coletores simulados
        var coletores = [
            { nome: 'Coletor João', lat: -22.2060, lng: -49.9550 },
            { nome: 'Coletor Maria', lat: -22.2210, lng: -49.9350 },
            { nome: 'Coletor Carlos', lat: -22.2180, lng: -49.9600 }
        ];

        coletores.forEach(function(c) {
            L.marker([c.lat, c.lng], { icon: iconeVerde })
                .addTo(map)
                .bindPopup('<b>♻️ ' + c.nome + '</b><br>Disponível para coleta');
        });
    </script>
</body>
</html>";
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