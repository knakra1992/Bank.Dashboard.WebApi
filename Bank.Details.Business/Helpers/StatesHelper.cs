using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Bank.Details.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Business.Helpers
{
    public class StatesHelper : IStatesHelper
    {
        private readonly IDataRepo _dataRepo;

        public StatesHelper(IDataRepo dataRepo) =>
            _dataRepo = dataRepo;

        public async Task<List<States>> GetAllStates() =>
            await _dataRepo.GetDataBySql<States>("SELECT * FROM States");
    }
}
