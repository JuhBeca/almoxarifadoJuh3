namespace AlmoxafiradoFront.DTO
{
    public class SaidaDTO
    {
        public int codigo { get; set; }
        public DateTime dataSaida { get; set; }
        public int codigoSecretaria { get; set; }
        public int codigoProduto { get; set; }
        public double precoProduto { get; set; }
        public double precoTotal { get; set; }
        public int quantidade { get; set; }
        public string observacao { get; set; }
    }
}
