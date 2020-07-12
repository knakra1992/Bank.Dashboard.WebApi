using Bank.Details.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Data.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly IDataRepo _dataRepo;

        public AuthRepo(IDataRepo dataRepo) =>
            _dataRepo = dataRepo;

        public async Task<T> AuthenticateUser<T>(string userName, string password) =>
            (await _dataRepo.GetDataBySql<T>(
                $"SELECT * FROM [dbo].[User] WHERE UserName = '{userName}' AND Password = '{password}'"))
            .FirstOrDefault();
    }
}
