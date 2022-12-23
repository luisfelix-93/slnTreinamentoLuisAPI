using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoLuisAPI.Models;

namespace TreinamentoLuisAPI.Repositories
{
    public class UserRepository
    {
        public static UserAPI GetUser(string pNameUser, string pDePassword)
        {
            var users = new List<UserAPI>();
            users.Add(new UserAPI { NmUser = "Luis", DePassword = "felix@123" });

            return users.FirstOrDefault(x => x.NmUser.ToLower() == pNameUser.ToLower() && x.DePassword == pDePassword);
        }
    }
}
