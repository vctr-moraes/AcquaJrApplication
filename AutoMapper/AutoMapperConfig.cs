using AcquaJrApplication.Models;
using AcquaJrApplication.ViewsModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcquaJrApplication.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Membro, MembroViewModel>().ReverseMap();
        }
    }
}
