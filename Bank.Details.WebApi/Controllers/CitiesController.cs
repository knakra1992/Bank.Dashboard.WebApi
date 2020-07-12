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
    [Route("api/states")]
    [ApiController]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesHelper _citiesHelper;

        public CitiesController(ICitiesHelper citiesHelper) =>
            _citiesHelper = citiesHelper;

        [HttpGet("{stateCode}/cities")]
        public async Task<List<Cities>> GetCitiesByState(string stateCode) =>
            await _citiesHelper.GetCitiesByState(stateCode);
    }
}