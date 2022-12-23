using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoLuisAPI.Models
{
    public class PersonAPI
    {
        public PersonAPI() { }

        public PersonAPI(string nuRegistration, string nmPerson, string nmStatus, string nmRole)
        {
            this.NuRegistration = nuRegistration;
            this.NmPerson = nmPerson;
            this.NmStatus = nmStatus;
            this.NmRole = nmRole;
        }
        public PersonAPI(dynamic row)
        {
            NuRegistration = row.NU_REGISTRATION;
            NmPerson = row.NM_PERSON;
            NmStatus = row.NM_STATUS;
            NmRole = row.NM_ROLE;
        }

        [JsonProperty(PropertyName = "NuRegistration", Order = int.MinValue)]
        public string NuRegistration { get; set; }

        [JsonProperty(PropertyName = "NmPerson", Order = 1)]
        public string NmPerson { get; set; }

        [JsonProperty(PropertyName = "NmStatus", Order = 2)]
        public string NmStatus { get; set; }

        [JsonProperty(PropertyName = "NmRole", Order = 3)]
        public string NmRole { get; set; }
    }
}
