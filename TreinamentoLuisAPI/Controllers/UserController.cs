using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoLuisAPI.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "Anonimo";

        [HttpGet]
        [Route("api/funcionario")]
        [Authorize(Roles = "funcionario,gerente")]
        public string Employee() => "Funcionario";

        [HttpGet]
        [Route("api/gerente")]
        [Authorize(Roles = "gerente")]
        public string Manager() => "Gerente";


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
