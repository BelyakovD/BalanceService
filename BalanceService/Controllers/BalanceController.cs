using BalanceService.Models;
using BalanceService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BalanceService.Controllers
{
    public class BalanceController : ApiController
    {
        // POST: api/Balance
        public BalanceOutput Post([FromBody] BalanceInput balanceInput)
        {
            CalculatorService calculatorService = new CalculatorService();
            return calculatorService.Calculate(balanceInput);
        }
    }
}