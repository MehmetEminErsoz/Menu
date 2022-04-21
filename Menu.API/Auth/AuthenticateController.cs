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
        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly RoleManager<IdentityRole> _identityRoleManager;
        public IPersonService _personManager;
        public IGenericService<User_DTO> _userManager;
        public IGenericService<Customer_DTO> _customerManager;
        //public IRoleService _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(


            UserManager<IdentityUser> identityUserManager,
            RoleManager<IdentityRole> identityRoleManager,
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
            return Unauthorized(new Response { Message="İdentity olarak rolü yok" ,  Status="Login sorgulaması yapılacak"});
        }

       
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists =  _personManager.getByEmail(model.Email);
            if (userExists  != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person_DTO>();
            var user = new Person_DTO();
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


           /* Customer_DTO customer = new()
            {
                Id = 1,
               IdPerson = user.Id,
                CreateTime = DateTime.Now,
                IpAdress = "192.168.1.1",
                IsActive = true,
                IsApproved = false,
                IsDeleted = false

            };*/

            //_personManager.add(person);
            //_customerManager.add(customer);
            
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.User));
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
        //[Authorize (Roles ="SAdmin")]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminModel model)
        {
            var userExists = _personManager.getByEmail(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            var passwordHasher = new PasswordHasher<Person_DTO>();
            var user = new Person_DTO();
            var hashedPassword = passwordHasher.HashPassword(user, model.Password);

            Person_DTO person = new()
            {
                NormalizedEmail = model.Email.ToUpper(),
                NormalizedUserName = model.Email.ToUpper(),
                Birthday = (DateTime)model.Birthday,
                Name = model.Name,
                Surname = model.Surname,
                IsActive = true,
                IsDeleted = false,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = hashedPassword,
                CreateTime = DateTime.Now,

            };
            User_DTO userWithPerson = new() {
                Id = 0,
                Phone=model.PhoneNumber,
            IdPerson=person.Id,
            CreateTime=DateTime.Now,
            IsActive=true,
            IsDeleted=false,
            PasswordAnswer=model.PasswordAnswer,
            PasswordQuestion=model.PasswordQuestion,
            SecondMail=model.SecondEmail,
            };
            _personManager.add(person);
            _userManager.add(userWithPerson);
/*
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.User));
           
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _identityUserManager.AddToRoleAsync(person, UserRoles.Admin);
                
            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityUserManager.AddToRoleAsync(person, UserRoles.User);
            }
          */
            
            return Ok(new Response { Status = "Success", Message = "Admin/User created successfully!" });
        }

        
        [HttpPost]
        //[Authorize(Roles = "SAdmin")]
        [Route("Register-SAdmin")]
        public async Task<IActionResult> SAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _identityUserManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.SAdmin))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.SAdmin));

            if (await _identityRoleManager.RoleExistsAsync(UserRoles.SAdmin))
            {
                await _identityUserManager.AddToRoleAsync(user, UserRoles.SAdmin);

            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _identityUserManager.AddToRoleAsync(user, UserRoles.Admin);

            }
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
            }
            /*if (result.Succeeded)
            {
                Personekle(model);
            }*/
            
            return Ok(new Response { Status = "Success", Message = "Super Admin created successfully!" });
        }
        [HttpPost]
        [Authorize (Roles ="Admin")]
        [Route("AddWaiter")]
        public async Task<IActionResult> AddWaiter([FromBody] RegisterModel model)
        {
            var userExists = await _identityUserManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _identityUserManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.User))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _identityRoleManager.RoleExistsAsync(UserRoles.Waiter))
                await _identityRoleManager.CreateAsync(new IdentityRole(UserRoles.Waiter));

            if (await _identityRoleManager.RoleExistsAsync(UserRoles.Waiter))
            {
                await _identityUserManager.AddToRoleAsync(user, UserRoles.Waiter);
            }
            
            if (await _identityRoleManager.RoleExistsAsync(UserRoles.User))
            {
                await _identityUserManager.AddToRoleAsync(user, UserRoles.User);
            }
            /*if (result.Succeeded)
            {
                Personekle(model);
            }*/
            
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