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
                    
                        .ForMember(dest => dest.IdState, act => act.MapFrom(src => src.IdState))
                        //.ForMember(dest=>dest.Adress_C,act=>act.MapFrom(src => src.Adress_C !=null ? src.Adress_C.Count() : src.Id))
                        .ReverseMap()
                        .ForMember(dest => dest.State, act => act.Ignore())
                        .ForMember(dest=>dest.Adress_C, act=>act.Ignore());

                    cfg.CreateMap<Adress_C, Adress_C_DTO>()
                    .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson))
                    .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                    .ForMember(dest => dest.IdAdressType, act => act.MapFrom(src => src.IdAdressType))
                    .ForMember(dest => dest.IdAdress, act => act.MapFrom(src => src.IdAdress))
                    .ReverseMap()
                    .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson))
                    .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                    .ForMember(dest => dest.IdAdressType, act => act.MapFrom(src=>src.IdAdressType))
                    .ForMember(dest => dest.IdAdress, act => act.MapFrom(src => src.IdAdress));

                    cfg.CreateMap<AdressType,AdressType_DTO>()
                        //.ForMember(dest => dest.Adress_C, act => act.MapFrom(src => src.Adress_C != null ? src.Adress_C.Count() : src.Id))
                        .ReverseMap()
                        .ForMember(dest => dest.Adress_C, act => act.Ignore());

                    cfg.CreateMap<Bill, Bill_DTO>()
                     .ForMember(dest => dest.IdDesk, act => act.MapFrom(src => src.IdDesk))
                     .ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser))
                     .ForMember(dest => dest.IdPaymentMethod, act => act.MapFrom(src => src.IdPaymentMethod))
                     //.ForMember(dest => dest.Order, act => act.MapFrom(src => src.Order != null ? src.Order.Count() : src.Id))
                     .ReverseMap()
                     .ForMember(dest => dest.IdDesk, act => act.MapFrom(src => src.IdDesk))
                     .ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser))
                     .ForMember(dest => dest.IdPaymentMethod, act => act.MapFrom(src => src.IdPaymentMethod))
                     .ForMember(dest => dest.Order, act => act.Ignore());
                    

                    cfg.CreateMap<Category, Category_DTO>()
                     .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                     //.ForMember(dest => dest.Package, act => act.MapFrom(src => src.Package != null ? src.Package.Count() : src.Id))
                    // .ForMember(dest => dest.Product, act => act.MapFrom(src => src.Product != null ? src.Product.Count() : src.Id))
                     //.ForMember(dest => dest.SubCategory, act => act.MapFrom(src => src.SubCategory != null ? src.SubCategory.Count() : src.Id))
                     .ReverseMap()
                     .ForMember(dest => dest.Package, act => act.Ignore())
                     .ForMember(dest => dest.Product, act => act.Ignore())
                     .ForMember(dest => dest.SubCategory, act => act.Ignore())
                     .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany));

                    cfg.CreateMap<City, City_DTO>()
                     .ForMember(dest => dest.IdCountry, act => act.MapFrom(src => src.IdCountry))
                     //.ForMember(dest => dest.State, act => act.MapFrom(src => src.State != null ? src.State.Count() : src.Id))
                     .ReverseMap()
                     .ForMember(dest => dest.State, act => act.Ignore())
                     .ForMember(dest => dest.IdCountry, act => act.MapFrom(src => src.IdCountry));

                    cfg.CreateMap<Company, Company_DTO>()
                     /*.ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category != null ? src.Category.Count() : src.Id))
                     .ForMember(dest => dest.Package, act => act.MapFrom(src => src.Package != null ? src.Package.Count() : src.Id))
                     .ForMember(dest => dest.Product, act => act.MapFrom(src => src.Product != null ? src.Product.Count() : src.Id))
                     .ForMember(dest => dest.Adress_C, act => act.MapFrom(src => src.Adress_C != null ? src.Adress_C.Count() : src.Id))
                     .ForMember(dest => dest.Desk, act => act.MapFrom(src => src.Desk != null ? src.Desk.Count() : src.Id))
                     .ForMember(dest => dest.Menu, act => act.MapFrom(src => src.Menu != null ? src.Menu.Count() : src.Id))
                     .ForMember(dest => dest.UserCompany_C, act => act.MapFrom(src => src.UserCompany_C != null ? src.UserCompany_C.Count() : src.Id))*/
                     .ReverseMap()
                     .ForMember(dest => dest.Package, act => act.Ignore())
                     .ForMember(dest => dest.Product, act => act.Ignore())
                     .ForMember(dest => dest.Category, act => act.Ignore())
                     .ForMember(dest => dest.Adress_C, act => act.Ignore())
                     .ForMember(dest => dest.Desk, act => act.Ignore())
                     .ForMember(dest => dest.Menu, act => act.Ignore())
                     .ForMember(dest => dest.UserCompany_C, act => act.Ignore());


                    /*cfg.CreateMap<Country, Country_DTO>()

                     .ForMember(dest => dest.City, act => act.MapFrom(src => src.City != null ? src.City.Count() : src.Id))
                     .ReverseMap()
                     .ForMember(dest => dest.City, act => act.Ignore());*/


                    cfg.CreateMap<Customer, Customer_DTO>()

                    .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson))
                    .ReverseMap()
                    .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson));

                    cfg.CreateMap<Desk, Desk_DTO>()

                   .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                   //.ForMember(dest => dest.Bill, act => act.MapFrom(src => src.Bill != null ? src.Bill.Count() : src.Id))
                   .ReverseMap()
                   .ForMember(dest => dest.Bill, act => act.Ignore())
                   .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany));

                    cfg.CreateMap<Menu.Entities.Menu, Menu_DTO>()

                   .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                   //.ForMember(dest => dest.MenuPackageProduct_C, act => act.MapFrom(src => src.MenuPackageProduct_C != null ? src.MenuPackageProduct_C.Count() : src.Id))
                   .ReverseMap()
                   .ForMember(dest => dest.MenuPackageProduct_C, act => act.Ignore())
                   .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany));

                    cfg.CreateMap<MenuPackageProduct_C, MenuPackageProduct_C_DTO>()

                   .ForMember(dest => dest.IdMenu, act => act.MapFrom(src => src.IdMenu))
                   .ForMember(dest => dest.IdPackage, act => act.MapFrom(src => src.IdPackage))
                   .ForMember(dest => dest.IdProduct, act => act.MapFrom(src => src.IdProduct))
                   //.ForMember(dest => dest.OrderPackageProduct_C, act => act.MapFrom(src => src.OrderPackageProduct_C != null ? src.OrderPackageProduct_C.Count() : src.Id))
                   .ReverseMap()
                   .ForMember(dest => dest.OrderPackageProduct_C, act => act.Ignore())
                   .ForMember(dest => dest.IdPackage, act => act.MapFrom(src => src.IdPackage))
                   .ForMember(dest => dest.IdProduct, act => act.MapFrom(src => src.IdProduct))
                   .ForMember(dest => dest.IdMenu, act => act.MapFrom(src => src.IdMenu));


                    cfg.CreateMap<Order, Order_DTO>()

                  .ForMember(dest => dest.IdBill, act => act.MapFrom(src => src.IdBill))
                  //.ForMember(dest => dest.OrderPackageProduct_C, act => act.MapFrom(src => src.OrderPackageProduct_C != null ? src.OrderPackageProduct_C.Count() : src.Id))
                  .ReverseMap()
                  .ForMember(dest => dest.OrderPackageProduct_C, act => act.Ignore())
                  .ForMember(dest => dest.IdBill, act => act.MapFrom(src => src.IdBill));

                    cfg.CreateMap<OrderPackageProduct_C, OrderPackageProduct_C_DTO>()

                  .ForMember(dest => dest.IdOrder, act => act.MapFrom(src => src.IdOrder))
                  .ForMember(dest => dest.IdMenuPackageProduct_C, act => act.MapFrom(src => src.IdMenuPackageProduct_C))
                  .ReverseMap()
                  .ForMember(dest => dest.IdOrder, act => act.MapFrom(src => src.IdOrder))
                  .ForMember(dest => dest.IdMenuPackageProduct_C, act => act.MapFrom(src => src.IdMenuPackageProduct_C));

                    cfg.CreateMap<Package, Package_DTO>()

                  .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                  .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                  .ForMember(dest => dest.IdSubCategory, act => act.MapFrom(src => src.IdSubCategory))
                  // .ForMember(dest => dest.MenuPackageProduct_C, act => act.MapFrom(src => src.MenuPackageProduct_C != null ? src.MenuPackageProduct_C.Count() : src.Id))
                   //.ForMember(dest => dest.PackageProduct_C, act => act.MapFrom(src => src.PackageProduct_C != null ? src.PackageProduct_C.Count() : src.Id))
                  .ReverseMap()
                  .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                  .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                  .ForMember(dest => dest.IdSubCategory, act => act.MapFrom(src => src.IdSubCategory))
                  .ForMember(dest => dest.MenuPackageProduct_C, act => act.Ignore())
                  .ForMember(dest => dest.PackageProduct_C, act => act.Ignore());


                    cfg.CreateMap<PackageProduct_C, PackageProduct_C_DTO>()

                 .ForMember(dest => dest.IdPackage, act => act.MapFrom(src => src.IdPackage))
                 .ForMember(dest => dest.IdProduct, act => act.MapFrom(src => src.IdProduct))
                 
                 .ReverseMap()
                 .ForMember(dest => dest.IdPackage, act => act.MapFrom(src => src.IdPackage))
                 .ForMember(dest => dest.IdProduct, act => act.MapFrom(src => src.IdProduct));

                    cfg.CreateMap<PaymentMethod, PaymentMethod_DTO>()

                   //.ForMember(dest => dest.Bill, act => act.MapFrom(src => src.Bill != null ? src.Bill.Count() : src.Id))
                  .ReverseMap()
                  .ForMember(dest => dest.Bill, act => act.Ignore());

                    cfg.CreateMap<Person, Person_DTO>()

                   //.ForMember(dest => dest.Adress_C, act => act.MapFrom(src => src.Adress_C != null ? src.Adress_C.Count() : src.Id))
                   //.ForMember(dest => dest.Customer, act => act.MapFrom(src => src.Customer != null ? src.Customer.Count() : src.Id))
                   //.ForMember(dest => dest.User, act => act.MapFrom(src => src.User != null ? src.User.Count() : src.Id))
                  .ReverseMap()
                 .ForMember(dest => dest.Adress_C, act => act.Ignore())
                  .ForMember(dest => dest.Customer, act => act.Ignore())
                  .ForMember(dest => dest.User, act => act.Ignore());


                    cfg.CreateMap<Product, Product_DTO>()

                 .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                 .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                 .ForMember(dest => dest.IdSubCategory, act => act.MapFrom(src => src.IdSubCategory))
                  //.ForMember(dest => dest.MenuPackageProduct_C, act => act.MapFrom(src => src.MenuPackageProduct_C != null ? src.MenuPackageProduct_C.Count() : src.Id))
                 // .ForMember(dest => dest.PackageProduct_C, act => act.MapFrom(src => src.PackageProduct_C != null ? src.PackageProduct_C.Count() : src.Id))
                 .ReverseMap()
                 .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                 .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                 .ForMember(dest => dest.IdSubCategory, act => act.MapFrom(src => src.IdSubCategory))
                 .ForMember(dest => dest.MenuPackageProduct_C, act => act.Ignore())
                 .ForMember(dest => dest.PackageProduct_C, act => act.Ignore());

                    cfg.CreateMap<Role, Role_DTO>()

                  //.ForMember(dest => dest.UserCompany_C, act => act.MapFrom(src => src.UserCompany_C != null ? src.UserCompany_C.Count() : src.Id))
                 .ReverseMap()
                 .ForMember(dest => dest.UserCompany_C, act => act.Ignore());

                    cfg.CreateMap<State, State_DTO>()

                 .ForMember(dest => dest.IdCity, act => act.MapFrom(src => src.IdCity))
               
                 // .ForMember(dest => dest.Adress, act => act.MapFrom(src => src.Adress != null ? src.Adress.Count() : src.Id))
                 .ReverseMap()
                 .ForMember(dest => dest.IdCity, act => act.MapFrom(src => src.IdCity))
                 .ForMember(dest => dest.Adress, act => act.Ignore());


                    cfg.CreateMap<SubCategory, SubCategory_DTO>()

                 .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                  //.ForMember(dest => dest.Package, act => act.MapFrom(src => src.Package != null ? src.Package.Count() : src.Id))
                  //.ForMember(dest => dest.Product, act => act.MapFrom(src => src.Product != null ? src.Product.Count() : src.Id))
                 .ReverseMap()
                
                 .ForMember(dest => dest.IdCategory, act => act.MapFrom(src => src.IdCategory))
                 .ForMember(dest => dest.Package, act => act.Ignore())
                 .ForMember(dest => dest.Product, act => act.Ignore());

                    cfg.CreateMap<User, User_DTO>()

                 .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson))
                 // .ForMember(dest => dest.Bill, act => act.MapFrom(src => src.Bill != null ? src.Bill.Count() : src.Id))
                  //.ForMember(dest => dest.UserCompany_C, act => act.MapFrom(src => src.UserCompany_C != null ? src.UserCompany_C.Count() : src.Id))
                 .ReverseMap()
                 .ForMember(dest => dest.IdPerson, act => act.MapFrom(src => src.IdPerson))
                 .ForMember(dest => dest.Bill, act => act.Ignore())
                 .ForMember(dest => dest.UserCompany_C, act => act.Ignore());

                    cfg.CreateMap<UserCompany_C, UserCompany_C_DTO>()

                 //.ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                 //.ForMember(dest => dest.IdRole, act => act.MapFrom(src => src.IdRole))
                 //.ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser))

                 .ReverseMap()
                 .ForMember(dest => dest.IdCompany, act => act.MapFrom(src => src.IdCompany))
                 .ForMember(dest => dest.IdRole, act => act.MapFrom(src => src.IdRole))
                 .ForMember(dest => dest.IdUser, act => act.MapFrom(src => src.IdUser));
             

                });

            mapper = new Mapper(mapConfig);
        }
        public Mapper Mapper()
        {
            return mapper;
        }
    }
}
