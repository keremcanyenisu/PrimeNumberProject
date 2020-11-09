using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeNumberApi.Controllers.Base;
using PrimeNumberBusiness.Interfaces;

namespace PrimeNumberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeNumberController : BaseController
    {
        private readonly IPrimeNumberService _primeNumberService;

        public PrimeNumberController(IPrimeNumberService primeNumberService)
        {
            _primeNumberService = primeNumberService;
        }

        [HttpGet("getPrimeNumber/{index}")]
        public async  Task<IActionResult> GetPrimeNumber(int index) {
            var result = await _primeNumberService.GetPrimeNumberAsync(index);
            return Json(result);
        }
    }
}
