using Microsoft.VisualBasic;

namespace AlmoxarifadoBackAPI.Models
{
    public class Entrada
    {
        public int Codigo { get; set; }
        public DateTime DataEntrada { get; set; } 
        public int CodigoFronecedor { get; set; }
        public string Observacao { get; set; }
    }
}
