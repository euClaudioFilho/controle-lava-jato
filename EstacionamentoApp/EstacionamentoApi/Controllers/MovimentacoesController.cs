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
        public async Task<ActionResult<Movimentacao>> PostAsync(Movimentacao movimentacao)
        {
            await _movimentacaoDAO.AddAsync(movimentacao);
            return CreatedAtAction(
                nameof(PostAsync),
                new { id = movimentacao.Id },
                movimentacao);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            var count = await _movimentacaoDAO.GetCountAsync();
            return Ok(count);
        }

        [HttpGet("totalvalue")]
        public async Task<ActionResult<decimal>> GetTotalValue()
        {
            var totalValue = await _movimentacaoDAO.GetTotalValueAsync();
            return Ok(totalValue);
        }
    }
}
