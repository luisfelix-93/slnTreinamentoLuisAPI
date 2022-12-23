using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using TreinamentoLuisAPI.DTO;
using TreinamentoLuisAPI.Models;
using TreinamentoLuisAPI.Repositories;

namespace TreinamentoLuisAPI.Services
{
    public class PersonService
    {

        private PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<ReturnDTO> SearchPersonByNuRegistration(string pNuRegistration)
        {
            return await _personRepository.GetPerson(pNuRegistration);
        } 
    }
}
