using Bank.Details.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Details.Business.Interfaces
{
    public interface IBankHelper
    {
        Task<BankInfo> GetBankDetails(int id);

        Task<List<BankInfo>> GetAllBankDetails();

        Task SaveBankDetails(BankInfo bankInfo);

        Task UpdateBankDetails(BankInfo bankInfo);

        Task DeleteBankDetails(int id);

        Task<List<Banks>> GetBankLists();
    }
}
