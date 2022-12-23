using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TreinamentoLuisAPI.Models;
using TreinamentoLuisAPI.DTO;
using TreinamentoLuisAPI.Helper;
using static Dapper.SqlMapper;

namespace TreinamentoLuisAPI.Repositories
{
    public class PersonRepository
    {
        
        private readonly IOptions<AppSettings> _appsettings;


        public PersonRepository(IOptions<AppSettings> appsettings)
        {
            _appsettings = appsettings;
        }
        public async Task<ReturnDTO> GetPerson(string pNuRegistration)
        {
            AppSettings appSettings = new AppSettings();
            List<PersonAPI> personList = new List<PersonAPI>();
            ReturnDTO returnDTO = new ReturnDTO
            {
                Message = ConstantManager.MsgDefBegin,
                Success = false,
                ResultObject = null
            };
            try
            {
                using (SqlConnection connection = appSettings.GetConnection())
                {
                    
                    //IEnumerable<dynamic> reader = await connection.QueryAsync(ConstantManager.SPR_API_GET_PERSON,
                    GridReader reader = await connection.QueryMultipleAsync(ConstantManager.SPR_API_GET_PERSON,
                        new
                        {
                            P_NU_REGISTRATION = pNuRegistration,
                        },
                        commandType: System.Data.CommandType.StoredProcedure);


                    //if (reader.Count() < 1)
                    //{
                    //    return null;
                    //}


                    List<dynamic> returnList = reader.Read().AsList();
                    personList = returnList.Select(row => new PersonAPI(row)).ToList();
                    returnDTO.Success = (personList.Count > 0) ? true : false;

                    if (returnDTO.Success)
                    {
                        returnDTO.Message = ConstantManager.MsgDefOk;
                        returnDTO.ResultObject = personList;
                    }

                    //PersonAPI personAPI = new PersonAPI(reader.FirstOrDefault());
                }
            }
            catch (Exception)
            {
                returnDTO.Success = false;
                returnDTO.Message = ConstantManager.MsgDefError;
                returnDTO.ResultObject = null;
                
            }
            return returnDTO;
        }

        //public static PersonAPI GetPersonID(string pNuRegistration)
        //{
        //    var persons = new List<PersonAPI>();
        //    persons.Add(new PersonAPI { NuRegistration = "73384121031"});

        //    return persons.FirstOrDefault(x => x.NuRegistration.ToLower() == pNuRegistration.ToLower());
        //}

        //public static PersonAPI GetPerson(string pNuRegistration)
        //{
        //    var persons = new List<PersonAPI>();
        //    persons.Add(new PersonAPI { NmPerson = "Gabriel Santos Silva", NuRegistration = "73384121031", DeStatus = "DISPONÍVEL" });

        //    return persons.FirstOrDefault(x => x.NuRegistration.ToLower() == pNuRegistration.ToLower());
        //}
    }
}
