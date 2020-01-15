using AutoMapper;
using eFincasWeb.Domain.Entity.Conta;
using eFincasWeb.Domain.Entity.Historico;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFincasWeb.Repository.AutoMapper
{
    public class HistoricoProfile : Profile
    {
        public HistoricoProfile()
        {
            CreateMap<Conta, Historico>()
                .ForMember(e => e.Descricao, d => d.MapFrom(p => p.Descricao))
                .ForMember(e => e.Valor, d => d.MapFrom(p => p.Valor))
                .ForMember(e => e.DataInclusao, d => d.MapFrom(p => p.DataCriacao)).ReverseMap();
        }
    }
}
