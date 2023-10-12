using Business.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IUserService _userService;

        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService, IConfiguration configuration)
        {
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var getUser = await _userService.GetUser(model);
            if (getUser != null)
            {
                TokenService tokenService = new TokenService(_configuration);
                Token token = _tokenService.CreateAccessToken(getUser);
                await _userService.GenerateUserRefreshToken(getUser.Id, token.RefreshToken, DateTime.Now, token.Expiration);
                return RedirectToAction("Index", "Room");
            }

            return View(model);
        }
    }
}
