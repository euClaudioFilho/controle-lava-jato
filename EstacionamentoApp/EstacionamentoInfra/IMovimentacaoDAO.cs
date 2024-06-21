using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EstacionamentoModel;

namespace EstacionamentoInfra.DAOs
{
    public interface IMovimentacaoDAO
    {
        Task<IEnumerable<Movimentacao>> GetAllAsync();
        Task AddAsync(Movimentacao movimentacao);
        Task<int> GetCountAsync();
        Task<decimal> GetTotalValueAsync();
    }
}

