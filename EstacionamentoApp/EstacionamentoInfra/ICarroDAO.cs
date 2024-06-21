using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstacionamentoInfra.DAOs
{
    public interface ICarroDAO
    {
        Task<IEnumerable<Carro>> GetAllAsync();
        Task<Carro> GetByIdAsync(int id);
        Task AddAsync(Carro carro);
        Task UpdateAsync(Carro carro);
        Task DeleteAsync(int id);
        Task<Carro> GetByPlacaAsync(string placa);
        Task<int> GetCarrosSemMovimentacoesAsync();
    }
}

