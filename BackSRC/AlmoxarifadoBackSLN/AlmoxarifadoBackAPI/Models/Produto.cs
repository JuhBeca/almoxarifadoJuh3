namespace AlmoxarifadoBackAPI.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public int EstoqueAtual { get; set; }
        public bool Epermanente { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
