using AcquaJrApplication.Models;
using AcquaJrApplication.ViewsModels;
using AutoMapper;

namespace AcquaJrApplication.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Membro, MembroViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Servico, ServicoViewModel>().ReverseMap();
            CreateMap<Projeto, ProjetoViewModel>().ReverseMap();
        }
    }
}
