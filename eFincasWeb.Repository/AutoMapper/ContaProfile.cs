using AutoMapper;
using eFincasWeb.Domain.Entity.Conta;
using eFincasWeb.Model.Request.Conta;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.AutoMapper
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<RegistrarContaRequest, Conta>()
                .ForMember(c => c.Descricao, d => d.MapFrom(e => e.Descricao))
                .ForMember(c => c.Valor, d => d.MapFrom(e => e.Valor))
                .ForMember(c => c.Tipo, d => d.MapFrom(e => e.Tipo))
                .ForMember(c => c.DataCriacao, d => d.MapFrom(e => e.DataCriacao)).ReverseMap();

            CreateMap<AtualizarContaRequest, Conta>()
                .ForMember(c => c.Descricao, d => d.MapFrom(e => e.Descricao))
                .ForMember(c => c.Valor, d => d.MapFrom(e => e.Valor))
                .ForMember(c => c.Tipo, d => d.MapFrom(e => e.Tipo))
                .ForMember(c => c.DataCriacao, d => d.MapFrom(e => e.DataCriacao)).ReverseMap();
        }
    }
}
