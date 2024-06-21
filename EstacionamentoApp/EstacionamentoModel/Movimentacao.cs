using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoModel
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}

