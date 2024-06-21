using EstacionamentoInfra.DAOs;
using EstacionamentoModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstacionamentoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly IMovimentacaoDAO _movimentacaoDAO;

        public MovimentacoesController(IMovimentacaoDAO movimentacaoDAO)
        {
            _movimentacaoDAO = movimentacaoDAO;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Movimentacao movimentacao)
        {
            await _movimentacaoDAO.AddAsync(movimentacao);
            return Ok();
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            return await _movimentacaoDAO.GetCountAsync();
        }

        [HttpGet("totalvalue")]
        public async Task<decimal> GetTotalValue()
        {
            return await _movimentacaoDAO.GetTotalValueAsync();
        }
    }
}