namespace AlmoxarifadoBackAPI.Models
{
    public class Saida
    {
        public int Codigo { get; set; }
        public DateTime DataSaida { get; set; }
        public int CodigoSecretaria { get; set; }
        public int CodigoProduto { get; set; }
        public double PrecoProduto { get; set; }
        public double PrecoTotal { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        
    }
}
