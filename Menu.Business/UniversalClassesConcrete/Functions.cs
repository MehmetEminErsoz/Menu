using AutoMapper;
using Menu.Business.UniversalClassesAbstract;
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
                
                
                });

            mapper = new Mapper(mapConfig);
        }
        public Mapper Mapper()
        {
            return mapper;
        }
    }
}
