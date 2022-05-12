using JWTAuthentication.NET6._0.Auth;
using Menu.API.Models;
using Menu.Business.Abstract;
using Menu.Business.Concrete;
using Menu.Business.DTO;
using Menu.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Menu.API.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<Person> _identityUserManager;
        private readonly RoleManager<Role> _identityRoleManager;
        public IPersonService _personManager;
        public IGenericService<User_DTO> _userManager;
        public IGenericService<Customer_DTO> _customerManager;
        //public IRoleService _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(

            
            UserManager<Person> identityUserManager,
            RoleManager<Role> identityRoleManager,
            IGenericService<Customer_DTO> CustomerManager,
            IGenericService<User_DTO> userManager,
            IPersonService personManager,

            //IRoleService roleManager,
            IConfiguration configuration)
        {
            _customerManager = CustomerManager;
            _identityUserManager = identityUserManager;
            _identityRoleManager = identityRoleManager;
            _personManager = personManager;
            _userManager=userManager;
            //_roleManager = roleManager;
            _configuration = configuration;
        }
       

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user =  _personManager.getByEmail(model.Email);
            if (user != null && await _identityUserManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _identityUserManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo.AddHours(8),
                    role = userRoles,
                    mail = user.Email,
                    
                });
            }
            return Unauthorized(new Response { Message = "İdentity olarak rolü yok", Status = "Login sorgulaması yapılacak" });
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = _personManager.getByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person>();
            var user = new Person();
            var hashedPassword = passwordHasher.HashPassword(user, model.Password);
            //burda iki tane person tanımlamış oluyoruz ramde yer ayırılmış oluyor bunu düzeltmek lazım.

            //user.Id = Guid.NewGuid().ToString(),
            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Email.ToUpper();
            user.Birthday = (DateTime)model.Birthday;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Email = model.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = hashedPassword;
            user.CreateTime = DateTime.Now;

            var userPerson = _personManager.getByEmail(user.Email);
            
            
            Customer_DTO customer = new()
             {
                 
                 IdPerson = userPerson.Id,
                 CreateTime = DateTime.Now,
                 IpAdress = "192.168.1.1",
                 IsActive = true,
                 IsApproved = false,
                 IsDeleted = false

             };

            var result = await _identityUserManager.CreateAsync(user, model.Password);
            _customerManager.add(customer);

            if (!result.Succeeded)
            {
                return BadRequest(new Response { Status = "424 Failed", Message = "Kullanıcı eklenemedi." });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
              await _identityRoleManager.CreateAsync(new Role { Id=0,Name="User"} );
            }
                
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
               var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
                if (!exist.Succeeded)
                {
                    return BadRequest (new Response { Message ="Rol eklenemedi" ,Status = "Error"});
                }
            }

            return Ok(new Response { Status = "Başarılı ", Message = "Müşteri Eklendi." });
        }


        [HttpPost]
        [Authorize (Roles ="SAdmin")]
        [Route("register-admin")]
        public async Task<IActionResult> registerAdmin([FromBody] RegisterAdminModel model)
        {
            var userExists = _personManager.getByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person>();
            var user = new Person();
            var hashedPassword = passwordHasher.HashPassword(user, model.Password);

            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Email.ToUpper();
            user.Birthday = (DateTime)model.Birthday;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Email = model.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = hashedPassword;
            user.CreateTime = DateTime.Now;

            User_DTO Suser = new()
            {
               CreateTime= DateTime.Now,
               IdPerson=user.Id,
               IsActive=true,
               IsDeleted=false,
               SecondMail=model.SecondEmail,
               PasswordQuestion=model.PasswordQuestion,
               PasswordAnswer=model.PasswordAnswer,
               Phone=model.PhoneNumber
            };
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            
            
            if (!result.Succeeded)
            {
                return BadRequest(new Response { Status = "424 Failed", Message = "Kullanıcı eklenemedi." });
            }
            _userManager.add(Suser);
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "User" });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "Admin" });
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.Admin);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }

            return Ok(new Response { Status = "Success", Message = "Admin/User created successfully!" });
        }


        [HttpPost]
        //[Authorize(Roles = "SAdmin")]
        [Route("register-SAdmin")]
        //[Authorize(Roles = "SAdmin")]
        public async Task<IActionResult> SAdmin([FromBody] RegisterAdminModel model)
        {
            var userExists = _personManager.getByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person>();
            var user = new Person();
            var hashedPassword = passwordHasher.HashPassword(user, model.Password);

            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Email.ToUpper();
            user.Birthday = (DateTime)model.Birthday;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Email = model.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = hashedPassword;
            user.CreateTime = DateTime.Now;



            User_DTO Suser = new()
            {
                CreateTime = DateTime.Now,
                IdPerson = 1,
                IsActive = true,
                IsDeleted = false,
                SecondMail = model.SecondEmail,
                PasswordQuestion = model.PasswordQuestion,
                PasswordAnswer = model.PasswordAnswer,
                Phone = model.PhoneNumber
            };
            var result = await _identityUserManager.CreateAsync(user, model.Password);

            
            if (!result.Succeeded)
            {
                return BadRequest(new Response { Status = "424 Failed", Message = "Kullanıcı eklenemedi." });
            }
            _userManager.add(Suser);
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "User" });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "Admin" });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.SAdmin))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "SAdmin" });
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.Admin);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.SAdmin))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.SAdmin);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }


            return Ok(new Response { Status = "Success", Message = "Super Admin created successfully!" });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddWaiter")]
        public async Task<IActionResult> AddWaiter([FromBody] RegisterAdminModel model)
        {
            var userExists = _personManager.getByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person>();
            var user = new Person();
            var hashedPassword = passwordHasher.HashPassword(user, model.Password);

            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Email.ToUpper();
            user.Birthday = (DateTime)model.Birthday;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.IsActive = true;
            user.IsDeleted = false;
            user.Email = model.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = hashedPassword;
            user.CreateTime = DateTime.Now;

            User_DTO Suser = new()
            {
                CreateTime = DateTime.Now,
                IdPerson = user.Id,
                IsActive = true,
                IsDeleted = false,
                SecondMail = model.SecondEmail,
                PasswordQuestion = model.PasswordQuestion,
                PasswordAnswer = model.PasswordAnswer,
                Phone = model.PhoneNumber
            };
            var result = await _identityUserManager.CreateAsync(user, model.Password);

            _userManager.add(Suser);
            if (!result.Succeeded)
            {
                return BadRequest(new Response { Status = "424 Failed", Message = "Kullanıcı eklenemedi." });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "User" });
            }
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Waiter))
            {
                await _identityRoleManager.CreateAsync(new Role { Id = 0, Name = "Waiter" });
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Waiter))
            {
                var exist = await _identityUserManager.AddToRoleAsync(user, UserRoles.Waiter);
                if (!exist.Succeeded)
                {
                    return BadRequest(new Response { Message = "Rol eklenemedi", Status = "Error" });
                }
            }
  

            return Ok(new Response { Status = "Success", Message = "Garson başarıyla eklendi!" });
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(8),
                claims: authClaims,
                
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        
    }
}