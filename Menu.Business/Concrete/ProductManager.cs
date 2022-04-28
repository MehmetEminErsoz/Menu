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
    public class ProductManager : GenericManager<Product, Product_DTO>,IProductService
    {
        IGenericRepository<Product> repository;
        IFunctions functions;
        Mapper mapper;
        public ProductManager(IGenericRepository<Product> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }

        public List<Product> getByIdCompany(int IdCompany)
        {

            var x = repository.getAll();

            var z = x.Where(s=>s.IdCompany==IdCompany).ToList();
            return (List<Product>)z;
        }
    }
}
