﻿namespace AlmoxarifadoBackAPI.Models
{
    public class Saida
    {
        public int Codigo { get; set; }

        public DateTime DataSaida { get; set; }
        public int CodigoSecretaria { get; set; }
        public string Observacao { get; set; }
        
    }
}
