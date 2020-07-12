using Bank.Details.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Business.Interfaces
{
    public interface IAuthHelper
    {
        Task<string> AuthenticateUser(string userName, string password);
    }
}
