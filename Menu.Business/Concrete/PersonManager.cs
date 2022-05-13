using AutoMapper;
using Menu.Business.Abstract;
using Menu.Business.DTO;
using Menu.Business.UniversalClassesAbstract;
using Menu.DataAccess.Abstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Concrete
{
    public class PersonManager :GenericManager<Person, Person_DTO>,IPersonService
    {
        IGenericRepository<Person> repository;
        IFunctions functions;
        Mapper mapper;
        public PersonManager(IGenericRepository<Person> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;

            
        }
        public Person getByEmail(string mail)
        {

            var x = repository.getAll();
            
            var z = x.Where(s=>s.Email==mail).FirstOrDefault();
            return z;
        }

       

        


    }
}
