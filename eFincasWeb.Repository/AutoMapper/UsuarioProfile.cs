using AutoMapper;
using eFincasWeb.Domain.Entity;
using eFincasWeb.Domain.Entity.Usuario;
using eFincasWeb.Model.Request.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarRequest, Usuario>()
                .ForMember(c => c.Email, s => s.MapFrom(b => b.Email))
                .ForMember(c => c.Password, s => s.MapFrom(b => Encoding.UTF8.GetBytes(b.Pass))).ReverseMap();
        }
    }
}
