using AutoMapper;
using Menu.Business.DTO;
using Menu.Business.UniversalClassesAbstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.UniversalClassesConcrete
{

    public class Functions : IFunctions
    {
        Mapper mapper;
        public Functions()
        {
            var mapConfig = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<Adress, Adress_DTO>()
                        .ForMember(dest => dest.IdState, act => act.MapFrom(src => src.IdState != null ? src.IdState : null))

                        .ReverseMap()
                        .ForMember(dest => dest.State, act => act.Ignore());
                
                });

            mapper = new Mapper(mapConfig);
        }
        public Mapper Mapper()
        {
            return mapper;
        }
    }
}
