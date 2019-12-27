using AutoMapper;
using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Usuario;
using eFincasWeb.Domain.Helpers;
using eFincasWeb.Model.Request.Login;
using eFincasWeb.Model.Response;
using eFincasWeb.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eFincasWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        #region Variáveis
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        #endregion

        #region Construtor
        public LoginController(ILoginRepository loginRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _loginRepository = loginRepository;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método para logar no sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("logar")]
        public async Task<IActionResult> Logar(LoginRequest request)
        {
            var usuario = await _loginRepository.Login(request.email, request.pass);

            if (usuario == null)
                return Unauthorized();

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    //new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            usuario.Password = null;

            return Ok(new { token = tokenHandler.WriteToken(token), email = usuario.Email });
        }

        /// <summary>
        /// Método para registrar um login no sistema
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(RegistrarRequest request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            var usuarioCriado = await _loginRepository.Registrar(usuario, request.Pass);
            return StatusCode(201, new { usuarioCriado });
        }
        #endregion
    }
}
