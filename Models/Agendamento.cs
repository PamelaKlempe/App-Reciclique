using SQLite;

namespace AppReciclique.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string Tipo { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Hora { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}