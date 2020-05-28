using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BalanceService.Models;
using BalanceLibrary;
using MathWorks.MATLAB.NET.Arrays;

namespace BalanceService.Service
{
    public class DataConverter
    {
        private List<FlowDescription> FlowDescription;
        private double[] x0;
        private double[] tols;
        private byte[] IsMeas;
        private List<String> flowsName;
        private List<String> nodesName;
        String message = "Баланс сведен";
        bool ok = true;
        private double[] result = null;
        private double delta;

        public DataConverter(BalanceInput balanceInput)
        {
            FlowDescription = new List<FlowDescription>();

            foreach (Flow flow in balanceInput.Flows)
            {
                if (flow.Flows != null)
                {
                    delta = flow.Delta_error;
                    foreach (FlowDescription flowDescription in flow.Flows)
                    {
                        FlowDescription.Add(new Models.FlowDescription
                        {
                            Id = flowDescription.Id,
                            Destination = flowDescription.Destination,
                            Source = flowDescription.Source,
                            NonMeasured = flowDescription.NonMeasured,
                            Value = flowDescription.Value,
                            Tolerance = flowDescription.Tolerance,
                            LowerBound = flowDescription.LowerBound,
                            UpperBound = flowDescription.UpperBound
                        });
                    }
                }
                else
                {
                    ok = false;
                    message = "Не найдено ни одного объекта";
                }
            }
        }

        public BalanceOutput Calculate()
        {
            if (ok)
            {
                flowsName = new List<string>();
                nodesName = new List<string>();

                for (int i = 0; i < FlowDescription.Count; i++)
                {
                    for (int j = 0; j < flowsName.Count; j++)
                    {
                        if (FlowDescription[i].Id.CompareTo(flowsName[j]) == 0)
                            return new BalanceOutput() { IsBalanced = false, Message = "Поток с id = '" + FlowDescription[i].Id + "' уже существует в списке", Flows = null };
                        else if (FlowDescription[i].Id.CompareTo("") == 0)
                            return new BalanceOutput() { IsBalanced = false, Message = "Поток не может иметь в качестве названия пустую строку", Flows = null };
                    }

                    flowsName.Add(FlowDescription[i].Id);
                }

                bool flag1, flag2;
                for (int i = 0; i < FlowDescription.Count; i++)
                {
                    flag1 = true;
                    for (int j = 0; j < nodesName.Count; j++)
                        if (FlowDescription[i].Destination == null || FlowDescription[i].Destination.CompareTo(nodesName[j]) == 0)
                        {
                            flag1 = false;
                            break;
                        }
                    if (flag1 && FlowDescription[i].Destination.CompareTo("") != 0) nodesName.Add(FlowDescription[i].Destination);

                    flag2 = true;
                    for (int j = 0; j < nodesName.Count; j++)
                        if (FlowDescription[i].Source == null || FlowDescription[i].Source.CompareTo(nodesName[j]) == 0)
                        {
                            flag2 = false;
                            break;
                        }
                    if (flag2 && FlowDescription[i].Source.CompareTo("") != 0) nodesName.Add(FlowDescription[i].Source);
                }

                x0 = new double[FlowDescription.Count];
                for (int i = 0; i < FlowDescription.Count; i++)
                    x0[i] = FlowDescription[i].Value;

                tols = new double[FlowDescription.Count];
                for (int i = 0; i < FlowDescription.Count; i++)
                    tols[i] = FlowDescription[i].Tolerance;

                IsMeas = new byte[FlowDescription.Count];
                for (int i = 0; i < FlowDescription.Count; i++)
                {
                    if (FlowDescription[i].NonMeasured) IsMeas[i] = 0;
                    else IsMeas[i] = 1;
                }

                double[,] A = new double[nodesName.Count, FlowDescription.Count];
                double[] b = new double[nodesName.Count];

                double[] lowerBounds = new double[FlowDescription.Count];
                for (int i = 0; i < FlowDescription.Count; i++)
                    lowerBounds[i] = FlowDescription[i].LowerBound;

                double[] upperBounds = new double[FlowDescription.Count];
                for (int i = 0; i < FlowDescription.Count; i++)
                    upperBounds[i] = FlowDescription[i].UpperBound;

                for (int i = 0; i < nodesName.Count; i++)
                {
                    for (int j = 0; j < FlowDescription.Count; j++)
                    {
                        if (FlowDescription[j].Destination != null && FlowDescription[j].Destination.CompareTo(nodesName[i]) == 0 && FlowDescription[j].Destination.CompareTo("") != 0)
                            A[i, j] = 1;
                        else if (FlowDescription[j].Source != null && FlowDescription[j].Source.CompareTo(nodesName[i]) == 0 && FlowDescription[j].Source.CompareTo("") != 0)
                            A[i, j] = -1;
                    }
                    b[i] = 0;
                }

                MWArray[] res;

                try
                {
                    res = Calculator.solve(A, b, x0, tols, IsMeas, lowerBounds, upperBounds);
                }
                catch (Exception ex)
                {
                    return new BalanceOutput() { IsBalanced = false, Message = "Баланс не сводится", Flows = result };
                }

                result = Calculator.xBalanced(res);

                if (Calculator.solveErr(res) > delta)
                {
                    return new BalanceOutput() { IsBalanced = false, Message = "Максимальный разбаланс после балансировки превысил ограничение " + delta, Flows = result };
                }

                BalanceOutput outputFlow = new BalanceOutput() { IsBalanced = true, Message = message, Flows = result };
                return outputFlow;
            }
            else
            {
                BalanceOutput outputFlow = new BalanceOutput() { IsBalanced = false, Message = message, Flows = result };
                return outputFlow;
            }
        }
    }
}