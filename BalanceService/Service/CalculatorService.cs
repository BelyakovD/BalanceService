using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalanceService.Models;

namespace BalanceService.Service
{
    public class CalculatorService
    {
        public BalanceOutput Calculate(BalanceInput balanceInput)
        {
            DataConverter dataConverter = new DataConverter(balanceInput);
            BalanceOutput balanceOutput = dataConverter.Calculate();
            return balanceOutput;
        }
    }
}