using Backend.DTOs;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumersController : ControllerBase
    {
        private readonly ILogger<CostumersController> _logger;
        private readonly CostumerService _costumerService;

        public CostumersController(ILogger<CostumersController> logger, CostumerService costumerService)
        {
            _logger = logger;
            _costumerService = costumerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var costumers = await _costumerService.GetAll();

                if (costumers == null)
                {
                    return NotFound();
                }

                return Ok(costumers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar todos os clientes: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var costumer = await _costumerService.Get(name);

                if (costumer == null)
                {
                    return NotFound();
                }

                return Ok(costumer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar o cliente {name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CostumerDTO costumerDTO)
        {
            try
            {
                await _costumerService.Post(costumerDTO);
                return Ok("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao cadastrar o cliente {costumerDTO.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Costumer costumer)
        {
            try
            {
                await _costumerService.Put(costumer);
                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar os dados do cliente {costumer.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _costumerService.Delete(id);
                return Ok("Usuário removido com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao remover o cliente com ID {id} da base de dados: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
