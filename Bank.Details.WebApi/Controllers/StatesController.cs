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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatesController : ControllerBase
    {
        private readonly IStatesHelper _statesHelper;

        public StatesController(IStatesHelper statesHelper) =>
            _statesHelper = statesHelper;

        [HttpGet]
        public async Task<List<States>> GetStatesAsync() =>
            await _statesHelper.GetAllStates();
    }
}