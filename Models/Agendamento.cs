using SQLite;

namespace AppReciclique.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string Tipo { get; set; }
        public string Endereco { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Telefone { get; set; }
        public string Observacao { get; set; }
    }
}
