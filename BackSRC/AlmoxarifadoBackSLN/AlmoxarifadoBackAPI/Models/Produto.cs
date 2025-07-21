namespace AlmoxarifadoBackAPI.Models
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string UnMedida { get; set; }
        public float EstoqueAtual { get; set; }
        public bool EPermanente { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
