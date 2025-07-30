namespace AlmoxafiradoFront.DTO
{
    public class ProdutosDTO
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string UnMedida { get; set; }
        public int EstoqueAtual { get; set; }
        public bool EPermanente { get; set; }
        public int CodigoCategoria { get; set; }
    }
}
