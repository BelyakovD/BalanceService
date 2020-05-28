using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalanceService.Models
{
    public class BalanceOutput
    {
        private bool isBalanced;
        private String message;
        private double[] flows;

        public bool IsBalanced { get => isBalanced; set => isBalanced = value; }
        public string Message { get => message; set => message = value; }
        public double[] Flows { get => flows; set => flows = value; }
    }
}