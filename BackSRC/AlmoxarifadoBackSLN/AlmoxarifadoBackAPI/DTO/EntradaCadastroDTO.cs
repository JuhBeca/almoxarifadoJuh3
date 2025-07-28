using Microsoft.VisualBasic;

namespace AlmoxarifadoBackAPI.DTO
{
    public class EntradaCadastroDTO
    {
        public DateTime DataEntrada { get; set; }
        public int CodigoFronecedor { get; set; }
        public string Observacao { get; set; }
    }
}
