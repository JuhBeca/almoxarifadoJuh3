namespace AlmoxafiradoFront.DTO
{
    public class EntradaDTO
    {
        public int codigo { get; set; }
        public DateTime dataEntrada { get; set; }
        public int codigoFronecedor { get; set; }
        public int codigoProduto { get; set; }
        public int quantidade { get; set; }
        public string observacao { get; set; }
    }
}
