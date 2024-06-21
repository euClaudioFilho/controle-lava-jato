using System;

namespace EstacionamentoFront.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
