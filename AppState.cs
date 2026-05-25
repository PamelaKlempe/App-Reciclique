using System.Collections.ObjectModel;

namespace AppReciclique
{
    public static class AppState
    {
        public static string UltimoAgendamento { get; set; } = "";

        public static int Pontos
        {
            get => Preferences.Get($"pontos_{IdUsuario}", 0);
            set
            {
                Preferences.Set($"pontos_{IdUsuario}", value);
                VerificarNivel();
            }
        }

        public static int TotalColetas
        {
            get => Preferences.Get($"coletas_{IdUsuario}", 0);
            set => Preferences.Set($"coletas_{IdUsuario}", value);
        }


        public static int IdUsuario { get; set; }
        public static string NomeUsuario { get; set; } = "";
        public static string EmailUsuario { get; set; } = "";
        public static string TelefoneUsuario { get; set; } = "";
        public static string DataNascimentoUsuario { get; set; } = "";
        public static string EnderecoUsuario { get; set; } = "";
        public static string CepUsuario { get; set; } = "";
        public static string PlanoUsuario { get; set; } = "Plano gratuito";
        public static string NivelUsuario { get; set; } = "Bronze";
        public static string IconeNivel { get; set; } = "🟤";

        public static ObservableCollection<string> Historico { get; set; } = new();

        public static ObservableCollection<string> Notificacoes { get; set; } = new();

        public static void AdicionarNotificacao(string mensagem)
        {
            if (!Notificacoes.Contains(mensagem))
            {
                Notificacoes.Insert(0, mensagem);
            }
        }

        public static void VerificarNivel()
        {
            if (IdUsuario <= 0)
                return;

            string nivelAnterior = NivelUsuario;

            int pontos = Pontos;


            string nivel;
            string icone;


            if (pontos <= 100)
            {
                nivel = "Bronze";
                icone = "bronze.png";
            }
            else if (pontos <= 250)
            {
                nivel = "Prata";
                icone = "prata.png";
            }
            else if (pontos <= 400)
            {
                nivel = "Ouro";
                icone = "ouro.png";
            }
            else if (pontos <= 1500)
            {
                nivel = "Platina";
                icone = "platina.png";
            }
            else
            {
                nivel = "Diamante";
                icone = "diamante.png";
            }


            NivelUsuario = nivel;
            IconeNivel = icone;

            if (nivelAnterior != NivelUsuario)
            {
                AdicionarNotificacao($"Parabéns! Você subiu para o nível {NivelUsuario}!");
            }

        }



    }
}
