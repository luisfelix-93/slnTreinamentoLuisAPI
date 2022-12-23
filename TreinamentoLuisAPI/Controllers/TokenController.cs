using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoLuisAPI.Models;
using TreinamentoLuisAPI.Repositories;
using TreinamentoLuisAPI.Services;

namespace TreinamentoLuisAPI.Controllers
{
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]

        public ActionResult<dynamic> Autenticate([FromBody] UserAPI model)
        {
            var user = UserRepository.GetUser(model.NmUser, model.DePassword);
            if (user == null)
            {
                return NotFound(new { message = "Usuario não encontrado" });
            }
            var token = TokenServices.GenerateToken(user);
            user.DePassword = "";
            return new
            {
                user = user,
                token = token
            };
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
