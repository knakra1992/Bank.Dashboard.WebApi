using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Bank.Details.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Business.Helpers
{
    public class CitiesHelper : ICitiesHelper
    {
        private readonly IDataRepo _dataRepo;

        public CitiesHelper(IDataRepo dataRepo) =>
            _dataRepo = dataRepo;

        public async Task<List<Cities>> GetCitiesByState(string stateCode) =>
            await _dataRepo.GetDataBySql<Cities>($"SELECT * FROM Cities WHERE StateCode = '{stateCode}'");
    }
}
