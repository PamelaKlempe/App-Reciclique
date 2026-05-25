namespace AppReciclique;

using Microsoft.Maui.Devices.Sensors;

public partial class MapaPage : ContentPage
{
    public MapaPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            Location? location = null;

            if (status == PermissionStatus.Granted)
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(
                        new GeolocationRequest(GeolocationAccuracy.High));
                }
            }

            double lat = location?.Latitude ?? -15.7939;
            double lng = location?.Longitude ?? -47.8828;
            bool usarLocalizacaoAtual = location != null;

            MapaWebView.Source = new HtmlWebViewSource
            {
                Html = GerarHtmlMapa(lat, lng, usarLocalizacaoAtual)
            };
        }
        catch
        {
            MapaWebView.Source = new HtmlWebViewSource
            {
                Html = GerarHtmlMapa(-15.7939, -47.8828, false)
            };
        }
    }

    private string GerarHtmlMapa(double latitude, double longitude, bool usarLocalizacaoAtual)
    {
        string popupUsuario = usarLocalizacaoAtual
            ? "<b>Voce esta aqui</b>"
            : "<b>Localizacao nao autorizada</b><br>Ative a localizacao para ver sua cidade";

        string html = @"
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
        var map = L.map('map').setView([LATITUDE, LONGITUDE], 14);

        L.tileLayer('https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png', {
            attribution: 'OpenStreetMap CARTO'
        }).addTo(map);

        L.marker([LATITUDE, LONGITUDE])
            .addTo(map)
            .bindPopup('POPUP_USUARIO')
            .openPopup();

        var iconeVerde = L.icon({
            iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png',
            shadowUrl: 'https://unpkg.com/leaflet@1.9.4/dist/images/marker-shadow.png',
            iconSize: [25, 41],
            iconAnchor: [12, 41],
            popupAnchor: [1, -34]
        });

        var coletores = [
            { nome: 'Coletor 1', lat: LATITUDE + 0.010, lng: LONGITUDE - 0.010 },
            { nome: 'Coletor 2', lat: LATITUDE - 0.010, lng: LONGITUDE + 0.010 },
            { nome: 'Coletor 3', lat: LATITUDE + 0.006, lng: LONGITUDE + 0.012 }
        ];

        coletores.forEach(function(c) {
            L.marker([c.lat, c.lng], { icon: iconeVerde })
                .addTo(map)
                .bindPopup('<b>' + c.nome + '</b><br>Disponivel para coleta');
        });
    </script>
</body>
</html>";

        return html
            .Replace("LATITUDE", latitude.ToString(System.Globalization.CultureInfo.InvariantCulture))
            .Replace("LONGITUDE", longitude.ToString(System.Globalization.CultureInfo.InvariantCulture))
            .Replace("POPUP_USUARIO", popupUsuario);
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
