using AutoMapper;
using eFincasWeb.Domain.Entity.Conta;
using eFincasWeb.Domain.Entity.Historico;
using eFincasWeb.Model.Request.Conta;
using eFincasWeb.Model.Response;
using eFincasWeb.Model.Response.Conta;
using eFincasWeb.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFincasWeb.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ContaController : ControllerBase
    {
        #region Variaveis
        private readonly IContaRepository _contaRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Construtor
        public ContaController(IMapper mapper, IContaRepository contaRepository, IHistoricoRepository historicoRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
            _historicoRepository = historicoRepository;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método para listar todos as contas registradas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<IActionResult> ListarContas()
        {
            var response = await _contaRepository.Listar();
            if (response == null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Método para registrar uma conta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarConta(RegistrarContaRequest request)
        {
            var data = _mapper.Map<Conta>(request);
            var response = await _contaRepository.RegistrarConta(data);
            return Ok(response);
        }

        /// <summary>
        /// Método para atualizar uma conta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarConta(int id, AtualizarContaRequest request)
        {
            id = request.Id;
            if (request == null || id == 0)
                return BadRequest();

            var data = _mapper.Map<Conta>(request);
            var response = await _contaRepository.AtualizarConta(id, data);
            return Ok(response);
        }

        /// <summary>
        /// Método para deletar uma conta
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("deletar")]
        public async Task<IActionResult> DeletarConta(int id)
        {
            if (id == 0)
                return BadRequest();

            var data = await _contaRepository.GetById(id);
            var map = _mapper.Map<Historico>(data);

            await _historicoRepository.RegistrarHistorico(map);

            _contaRepository.DeleteConta(id);

            return NoContent();
        }
        #endregion
    }
}
