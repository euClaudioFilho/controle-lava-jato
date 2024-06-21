using Dapper;
using EstacionamentoModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EstacionamentoInfra.DAOs
{
    public class MovimentacaoDAO : IMovimentacaoDAO
    {
        private readonly IDbConnection _dbConnection;

        public MovimentacaoDAO(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Movimentacao>> GetAllAsync()
        {
            var sql = "SELECT * FROM Movimentacoes";
            return await _dbConnection.QueryAsync<Movimentacao>(sql);
        }

        public async Task AddAsync(Movimentacao movimentacao)
        {
            var sql = "INSERT INTO Movimentacoes (Placa, Data, Valor) VALUES (@Placa, @Data, @Valor)";
            await _dbConnection.ExecuteAsync(sql, movimentacao);
        }

        public async Task<int> GetCountAsync()
        {
            var sql = "SELECT COUNT(*) FROM Movimentacoes";
            return await _dbConnection.ExecuteScalarAsync<int>(sql);
        }

        public async Task<decimal> GetTotalValueAsync()
        {
            var sql = "SELECT SUM(Valor) FROM Movimentacoes";
            return await _dbConnection.ExecuteScalarAsync<decimal>(sql);
        }
    }
}
