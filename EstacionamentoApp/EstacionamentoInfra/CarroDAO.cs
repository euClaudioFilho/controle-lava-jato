using Dapper;
using EstacionamentoModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EstacionamentoInfra.DAOs
{
    public class CarroDAO : ICarroDAO
    {
        private readonly IDbConnection _dbConnection;

        public CarroDAO(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Carro>> GetAllAsync()
        {
            var sql = "SELECT * FROM Carros";
            return await _dbConnection.QueryAsync<Carro>(sql);
        }

        public async Task<Carro> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Carros WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Carro>(sql, new { Id = id });
        }

        public async Task AddAsync(Carro carro)
        {
            var sql = "INSERT INTO Carros (Modelo, Placa) VALUES (@Modelo, @Placa)";
            await _dbConnection.ExecuteAsync(sql, carro);
        }

        public async Task UpdateAsync(Carro carro)
        {
            var sql = "UPDATE Carros SET Modelo = @Modelo, Placa = @Placa WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, carro);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Carros WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Carro> GetByPlacaAsync(string placa) 
        {
            var sql = "SELECT * FROM Carros WHERE Placa = @Placa";
            return await _dbConnection.QueryFirstOrDefaultAsync<Carro>(sql, new { Placa = placa });
        }
        public async Task<int> GetCarrosSemMovimentacoesAsync() 
        {
            var sql = @"
                SELECT COUNT(*)
                FROM Carros c
                LEFT JOIN Movimentacoes m ON c.Placa = m.Placa
                WHERE m.Id IS NULL";
            return await _dbConnection.ExecuteScalarAsync<int>(sql);
        }
    }
}
