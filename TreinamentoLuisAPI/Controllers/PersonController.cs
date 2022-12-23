using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoLuisAPI.DTO;
using TreinamentoLuisAPI.Models;
using TreinamentoLuisAPI.Repositories;
using TreinamentoLuisAPI.Services;

namespace TreinamentoLuisAPI.Controllers
{
    
    [ApiController]

    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        
        public PersonController(PersonService personService)
        {
            _personService = personService;

        }

        [Route("api/GetPersonByNuRegistration/{pNuRegistration}")]
        [HttpGet]
        public async Task<ActionResult> GetPersonByNuRegistration(string pNuRegistration)
        {
            ReturnDTO returnDTO = await _personService.SearchPersonByNuRegistration(pNuRegistration);

            if (returnDTO.Success)
            {
                return new OkObjectResult(returnDTO);
            }
            else
            {
                return new NotFoundObjectResult(returnDTO);
            }

        }

        //[HttpGet]
        //[Route("api/GetPersonByNuRegistration")]
        //public async Task<IActionResult> GetPersonByNuRegistration([FromQuery] string pNuRegistration)
        //{
        //    ReturnDTO returnDTO = new ReturnDTO();

        //    returnDTO = await personService.SearchPersonByNuRegistration(pNuRegistration, this.Request.Headers);
        //    if (returnDTO.Success)
        //    {
        //        return new OkObjectResult(returnDTO);
        //    }
        //    else
        //    {
        //        return new NotFoundObjectResult(returnDTO);
        //    }
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
