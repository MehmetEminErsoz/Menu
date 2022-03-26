using JWTAuthentication.NET6._0.Auth;
using Menu.Business.Abstract;
using Menu.Business.Concrete;
using Menu.Business.DTO;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IGenericService<Person_DTO> _personManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(


            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IGenericService<Person_DTO> personManager,
            IConfiguration configuration)
        {
            
            _userManager = userManager;
            _roleManager = roleManager;
            _personManager = personManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("PersonEkle")]
        public IActionResult Personekle(RegisterModel model)
        {
            Person_DTO person = new()
            {
                Id = 0,
                Name = model.Name,
                Surname = model.Surname,
                Birthday = (DateTime)model.Birthday,
                Mail = model.Email,
                Password = model.Password,
                IsDeleted = false,
                IsActive = true,
                CreateTime = DateTime.Now,

            };


            try
            {
                var res = _personManager.add(person);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = "Person Tablosuna eklenemedi", Status = "Failed" });
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
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
                    expiration = token.ValidTo.AddHours(3),
                    role = userRoles
                    
                });
            }
            return Unauthorized();
        }

       
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName =model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message ="Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });


            Personekle(model);
            

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        
       
        [HttpPost]
        [Authorize (Roles ="SAdmin")]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            Personekle(model);
            
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        [Authorize(Roles = "SAdmin")]
        [Route("Register-SAdmin")]
        public async Task<IActionResult> SAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.SAdmin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.SAdmin));

            if (await _roleManager.RoleExistsAsync(UserRoles.SAdmin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.SAdmin);

            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            Personekle(model);
            return Ok(new Response { Status = "Success", Message = "Super Admin created successfully!" });
        }
        [HttpPost]
        [Authorize (Roles ="Admin")]
        [Route("AddWaiter")]
        public async Task<IActionResult> AddWaiter([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Böyle bir kullanıcı mevcut" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Kullanıcı eklenemedi ! Lütfen bilgileri doğrulayın." });

            
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Waiter))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Waiter));

            if (await _roleManager.RoleExistsAsync(UserRoles.Waiter))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Waiter);
            }
            
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            Personekle(model);
            return Ok(new Response { Status = "Success", Message = "Garson başarıyla eklendi!" });
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        
    }
}