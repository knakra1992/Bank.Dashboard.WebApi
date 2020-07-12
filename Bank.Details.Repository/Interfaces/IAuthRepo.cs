using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Data.Interfaces
{
    public interface IAuthRepo
    {
        Task<T> AuthenticateUser<T>(string userName, string password);
    }
}
