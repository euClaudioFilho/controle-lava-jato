using EstacionamentoInfra.DAOs;
using EstacionamentoModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstacionamentoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroDAO _carroDAO;

        public CarrosController(ICarroDAO carroDAO)
        {
            _carroDAO = carroDAO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAsync()
        {
            var carros = await _carroDAO.GetAllAsync();

            if (carros == null)
                return NotFound();

            return Ok(carros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetId(int id)
        {
            var carro = await _carroDAO.GetByIdAsync(id);
             
            if (carro == null)
                return NotFound();

            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> PostAsync(Carro carro)
        {
            await _carroDAO.AddAsync(carro);

            return CreatedAtAction(
                nameof(GetId),
                new { id = carro.Id },
                carro
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Carro carro)
        {
            if (id != carro.Id)
                return BadRequest();

            var carroOrig = await _carroDAO.GetByIdAsync(id);

            if (carroOrig == null)
                return NotFound();

            carroOrig.Modelo = carro.Modelo;
            carroOrig.Placa = carro.Placa;

            await _carroDAO.UpdateAsync(carroOrig);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var carro = await _carroDAO.GetByIdAsync(id);

            if (carro == null)
                return NotFound();

            await _carroDAO.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Carro>> GetByPlaca(string placa)
        {
            var carro = await _carroDAO.GetByPlacaAsync(placa);

            if (carro == null)
                return NotFound();

            return Ok(carro);
        }

        [HttpGet("sem-movimentacoes")]
        public async Task<ActionResult<int>> GetCarrosSemMovimentacoes()
        {
            var count = await _carroDAO.GetCarrosSemMovimentacoesAsync();
            return Ok(count);
        }
    }
}
