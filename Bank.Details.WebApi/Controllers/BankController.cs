using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Details.Business.Interfaces;
using Bank.Details.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Details.WebApi.Controllers
{
    [Route("api/banks")]
    [ApiController]
    [Authorize]
    public class BankController : ControllerBase
    {
        private readonly IBankHelper _bankHelper;

        public BankController(IBankHelper bankHelper) =>
            _bankHelper = bankHelper;

        [HttpGet("{id}")]
        public async Task<BankInfo> GetBankDetailsById(int id) =>
            await _bankHelper.GetBankDetails(id);

        [HttpGet("details")]
        public async Task<List<BankInfo>> GetAllBankDetails() =>
            await _bankHelper.GetAllBankDetails();

        [HttpGet]
        public async Task<List<Banks>> GetBanksAsync() =>
            await _bankHelper.GetBankLists();

        [HttpPost]
        public async Task SaveBankDetails(BankInfo bankInfo) =>
            await _bankHelper.SaveBankDetails(bankInfo);

        [HttpPut]
        public async Task UpdateBankDetails(BankInfo bankInfo) =>
            await _bankHelper.UpdateBankDetails(bankInfo);

        [HttpDelete("{id}")]
        public async Task DeleteBankDetails(int id) =>
            await _bankHelper.DeleteBankDetails(id);
    }
}