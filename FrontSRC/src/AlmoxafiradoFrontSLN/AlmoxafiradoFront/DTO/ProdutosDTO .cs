namespace AlmoxafiradoFront.DTO
{
    public class ProdutosDTO
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public float EstoqueAtual { get; set; }
        public bool Epermanente { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
