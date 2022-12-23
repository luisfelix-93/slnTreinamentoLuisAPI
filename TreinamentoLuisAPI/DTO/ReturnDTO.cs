using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoLuisAPI.Models;

namespace TreinamentoLuisAPI.DTO
{
    public class ReturnBaseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }

    }

    public class ReturnDTO : ReturnBaseDTO 
    {
        public object ResultObject { get; set; }
        
    }

    public class ReturnPersonDTO : ReturnBaseDTO 
    {
        public PersonAPI person { get; set; }
    }

}
