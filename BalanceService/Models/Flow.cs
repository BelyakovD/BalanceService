using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalanceService.Models
{
    public class Flow
    {
        private double delta_error;
        private List<FlowDescription> flows;

        public List<FlowDescription> Flows { get => flows; set => flows = value; }
        public double Delta_error { get => delta_error; set => delta_error = value; }
    }
}