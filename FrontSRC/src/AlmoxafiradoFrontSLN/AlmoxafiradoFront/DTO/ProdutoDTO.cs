
namespace AlmoxafiradoFront.DTO
{
    public class ProdutoDTO
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public string unidadeMedida { get; set; }
        public float estoqueAtual { get; set; }
        public bool epermanente { get; set; }
        public int codigoCategoria { get; set; }
    }
}

