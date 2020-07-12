using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Bank.Details.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Business.Helpers
{
    public class BankHelper : IBankHelper
    {
        private readonly IDataRepo _dataRepo;

        private Dictionary<string, object> PrepareParameters(BankInfo bankInfo) =>
            new Dictionary<string, object>
            {
                { "p_id", bankInfo.Id },
                { "p_branchName", bankInfo.BranchName },
                { "p_bank", bankInfo.Bank },
                { "p_ifscCode", bankInfo.IfscCode },
                { "p_state", bankInfo.State },
                { "p_district", bankInfo.District }
            };

        public BankHelper(IDataRepo dataRepo) =>
            _dataRepo = dataRepo;
        
        public async Task<BankInfo> GetBankDetails(int id) =>
            await _dataRepo.GetData<BankInfo>(id);

        public async Task<List<BankInfo>> GetAllBankDetails() =>
            await _dataRepo.GetAllDetails<BankInfo>();

        public async Task SaveBankDetails(BankInfo bankInfo) =>
            await _dataRepo.SaveDetails("SaveBankDetails", PrepareParameters(bankInfo));

        public async Task UpdateBankDetails(BankInfo bankInfo) =>
            await _dataRepo.UpdateDetails("UpdateBankDetails", PrepareParameters(bankInfo));

        public async Task DeleteBankDetails(int id) =>
            await _dataRepo.DeleteDetails(id);

        public async Task<List<Banks>> GetBankLists() =>
            await _dataRepo.GetDataBySql<Banks>("SELECT * FROM Banks");
    }
}
