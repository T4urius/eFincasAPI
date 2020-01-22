using eFincasWeb.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFincasWeb.Controllers
{
    [Route("api/historico")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoController(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarHistorico()
        {
            var response = await _historicoRepository.ListarHistorico();

            if (response == null)
                return NotFound();

            return Ok(response);
        }
    }
}
