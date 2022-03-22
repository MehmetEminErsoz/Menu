using Menu.Business.Abstract;
using Menu.Business.Concrete;
using Menu.Business.DTO;
using Menu.Business.UniversalClassesAbstract;
using Menu.Business.UniversalClassesConcrete;
using Menu.DataAccess;
using Menu.DataAccess.Abstract;
using Menu.DataAccess.Concrete;
using Menu.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGenericRepository<Adress>, AdressRepository>();
builder.Services.AddScoped<IGenericService<Adress_DTO>, AdressManager>();

builder.Services.AddScoped<IGenericRepository<Adress_C>, Adress_CRepository>();
builder.Services.AddScoped<IGenericService<Adress_C_DTO>, Adress_CManager>();

builder.Services.AddScoped<IGenericRepository<AdressType>, AdressTypeRepository>();
builder.Services.AddScoped<IGenericService<AdressType_DTO>, AdressTypeManager>();

builder.Services.AddScoped<IGenericRepository<Bill>, BillRepository>();
builder.Services.AddScoped<IGenericService<Bill_DTO>, BillManager>();

builder.Services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IGenericService<Category_DTO>, CategoryManager>();

builder.Services.AddScoped<IGenericRepository<City>, CityRepository>();
builder.Services.AddScoped<IGenericService<City_DTO>, CityManager>();

builder.Services.AddScoped<IGenericRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<IGenericService<Company_DTO>, CompanyManager>();

builder.Services.AddScoped<IGenericRepository<Country>, CountryRepository>();
builder.Services.AddScoped<IGenericService<Country_DTO>, CountryManager>();

builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IGenericService<Customer_DTO>, CustomerManager>();

builder.Services.AddScoped<IGenericRepository<Desk>, DeskRepository>();
builder.Services.AddScoped<IGenericService<Desk_DTO>, DeskManager>();

builder.Services.AddScoped<IGenericRepository<MenuPackageProduct_C>, MenuPackageProduct_CRepository>();
builder.Services.AddScoped<IGenericService<MenuPackageProduct_C_DTO>, MenuPackageProduct_CManager>();

builder.Services.AddScoped<IGenericRepository<Menu.Entities.Menu>, MenuRepository>();
builder.Services.AddScoped<IGenericService<Menu_DTO>, MenuManager>();

builder.Services.AddScoped<IGenericRepository<OrderPackageProduct_C>, OrderPackageProduct_CRepository>();
builder.Services.AddScoped<IGenericService<OrderPackageProduct_C_DTO>, OrderPackageProduct_CManager>();

builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IGenericService<Order_DTO>, OrderManager>();

builder.Services.AddScoped<IGenericRepository<PackageProduct_C>, PackageProduct_CRepository>();
builder.Services.AddScoped<IGenericService<PackageProduct_C_DTO>, PackageProduct_CManager>();

builder.Services.AddScoped<IGenericRepository<Package>, PackageRepository>();
builder.Services.AddScoped<IGenericService<Package_DTO>, PackageManager>();

builder.Services.AddScoped<IGenericRepository<PaymentMethod>, PaymentMethodRepository>();
builder.Services.AddScoped<IGenericService<PaymentMethod_DTO>, PaymentMethodManager>();

builder.Services.AddScoped<IGenericRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IGenericService<Person_DTO>, PersonManager>();

builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IGenericService<Product_DTO>, ProductManager>();

builder.Services.AddScoped<IGenericRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IGenericService<Role_DTO>, RoleManager>();

builder.Services.AddScoped<IGenericRepository<State>, StateRepository>();
builder.Services.AddScoped<IGenericService<State_DTO>, StateManager>();

builder.Services.AddScoped<IGenericRepository<SubCategory>, SubCategoryRepository>();
builder.Services.AddScoped<IGenericService<SubCategory_DTO>, SubCategoryManager>();

builder.Services.AddScoped<IGenericRepository<UserCompany_C>, UserCompany_CRepository>();
builder.Services.AddScoped<IGenericService<UserCompany_C_DTO>, UserCompany_CManager>();

builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IGenericService<User_DTO>, UserManager>();

builder.Services.AddSingleton<IFunctions, Functions>();

builder.Services.AddDbContext<MenuDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));


//identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MenuDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
