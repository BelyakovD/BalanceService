using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalanceService.Models;
using System.Collections.Generic;
using BalanceService.Controllers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {        
        [TestMethod]
        public void TestMethod1()
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "1", Source = null, NonMeasured = false, Value = 10.005, Tolerance = 0.2, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "2", Destination = "", Source = "1", NonMeasured = false, Value = 3.033, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "2", Source = "1", NonMeasured = false, Value = 6.831, Tolerance = 0.683, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "", Source = "2", NonMeasured = false, Value = 1.985, Tolerance = 0.04, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "3", Source = "2", NonMeasured = false, Value = 5.093, Tolerance = 0.102, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = null, Source = "3", NonMeasured = false, Value = 4.057, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = null, Source = "3", NonMeasured = false, Value = 0.991, Tolerance = 0.02, LowerBound = 0, UpperBound = 1000 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(true, result.IsBalanced);
        }

        [TestMethod]
        public void TestMethod2()
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "1", Source = null, NonMeasured = false, Value = 10.005, Tolerance = 0.2, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "2", Destination = "", Source = "1", NonMeasured = false, Value = 3.033, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "2", Source = "1", NonMeasured = false, Value = 6.831, Tolerance = 0.683, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "", Source = "2", NonMeasured = false, Value = 1.985, Tolerance = 0.04, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "3", Source = "2", NonMeasured = false, Value = 5.093, Tolerance = 0.102, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = null, Source = "3", NonMeasured = false, Value = 4.057, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = null, Source = "3", NonMeasured = false, Value = 0.991, Tolerance = 0.02, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "8", Destination = null, Source = "3", NonMeasured = false, Value = 6.667, Tolerance = 0.667, LowerBound = 0, UpperBound = 1000 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(true, result.IsBalanced);
        }

        [TestMethod]//несводимый
        public void TestMethod3()
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "1", Source = null, NonMeasured = false, Value = 10.005, Tolerance = 0.2, LowerBound = 50, UpperBound = 60 });
            flowDescription.Add(new FlowDescription { Id = "2", Destination = "", Source = "1", NonMeasured = false, Value = 3.033, Tolerance = 0.121, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "2", Source = "1", NonMeasured = false, Value = 6.831, Tolerance = 0.683, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "", Source = "2", NonMeasured = false, Value = 1.985, Tolerance = 0.04, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "3", Source = "2", NonMeasured = false, Value = 5.093, Tolerance = 0.102, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = null, Source = "3", NonMeasured = false, Value = 4.057, Tolerance = 0.081, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = null, Source = "3", NonMeasured = false, Value = 0.991, Tolerance = 0.02, LowerBound = 0, UpperBound = 10 });
            flowDescription.Add(new FlowDescription { Id = "8", Destination = null, Source = "3", NonMeasured = false, Value = 6.667, Tolerance = 0.667, LowerBound = 0, UpperBound = 10 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(false, result.IsBalanced);
        }

        [TestMethod]
        public void TestMethod4()//повторяется название
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "1", Source = null, NonMeasured = false, Value = 10.005, Tolerance = 0.2, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "", Source = "1", NonMeasured = false, Value = 3.033, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "2", Source = "1", NonMeasured = false, Value = 6.831, Tolerance = 0.683, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "", Source = "2", NonMeasured = false, Value = 1.985, Tolerance = 0.04, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "3", Source = "2", NonMeasured = false, Value = 5.093, Tolerance = 0.102, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = null, Source = "3", NonMeasured = false, Value = 4.057, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = null, Source = "3", NonMeasured = false, Value = 0.991, Tolerance = 0.02, LowerBound = 0, UpperBound = 1000 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(false, result.IsBalanced);
        }

        [TestMethod]//больше потоков
        public void TestMethod5()
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "", Source = "1", NonMeasured = false, Value = 5.035, Tolerance = 0.11, LowerBound = 5.03, UpperBound = 5.04 });
            flowDescription.Add(new FlowDescription { Id = "2", Destination = "", Source = "1", NonMeasured = false, Value = 3.002, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "1", Source = "2", NonMeasured = false, Value = 4.523, Tolerance = 0.2, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "1", Source = "3", NonMeasured = false, Value = 3.493, Tolerance = 0.08, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "", Source = "2", NonMeasured = false, Value = 4.028, Tolerance = 0.092, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = "2", Source = "4", NonMeasured = false, Value = 8.544, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = "3", Source = "5", NonMeasured = false, Value = 3.485, Tolerance = 0.02, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "8", Destination = "3", Source = "", NonMeasured = false, Value = 0.02, Tolerance = 0.005, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "9", Destination = "5", Source = null, NonMeasured = false, Value = 2.081, Tolerance = 0.12, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "10", Destination = "4", Source = "6", NonMeasured = false, Value = 2.573, Tolerance = 0.15, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "11", Destination = "3", Source = "7", NonMeasured = false, Value = 6.028, Tolerance = 0.08, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "12", Destination = "7", Source = "", NonMeasured = false, Value = 1.014, Tolerance = 0.05, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "13", Destination = "5", Source = "8", NonMeasured = false, Value = 1.404, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "14", Destination = "6", Source = "8", NonMeasured = false, Value = 2.565, Tolerance = 0.125, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "15", Destination = "7", Source = "9", NonMeasured = false, Value = 5.012, Tolerance = 0.08, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "16", Destination = "8", Source = null, NonMeasured = false, Value = 3.04, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "17", Destination = "8", Source = "9", NonMeasured = false, Value = 0.93, Tolerance = 0.071, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "18", Destination = "9", Source = null, NonMeasured = false, Value = 5.937, Tolerance = 0.125, LowerBound = 0, UpperBound = 1000 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(true, result.IsBalanced);
        }

        [TestMethod]//пустой запрос
        public void TestMethod6()
        {
            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = null, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(false, result.IsBalanced);
        }

        [TestMethod]//неизмеряемый поток
        public void TestMethod7()
        {
            List<FlowDescription> flowDescription = new List<FlowDescription>();
            flowDescription.Add(new FlowDescription { Id = "1", Destination = "1", Source = null, NonMeasured = true, LowerBound = 10, UpperBound = 10.007 });
            flowDescription.Add(new FlowDescription { Id = "2", Destination = "", Source = "1", NonMeasured = false, Value = 3.033, Tolerance = 0.121, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "3", Destination = "2", Source = "1", NonMeasured = false, Value = 6.831, Tolerance = 0.683, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "4", Destination = "", Source = "2", NonMeasured = false, Value = 1.985, Tolerance = 0.04, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "5", Destination = "3", Source = "2", NonMeasured = false, Value = 5.093, Tolerance = 0.102, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "6", Destination = null, Source = "3", NonMeasured = false, Value = 4.057, Tolerance = 0.081, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "7", Destination = null, Source = "3", NonMeasured = false, Value = 0.991, Tolerance = 0.02, LowerBound = 0, UpperBound = 1000 });
            flowDescription.Add(new FlowDescription { Id = "8", Destination = null, Source = "3", NonMeasured = false, Value = 6.667, Tolerance = 0.667, LowerBound = 0, UpperBound = 1000 });

            BalanceInput balanceInput = new BalanceInput();
            balanceInput.Flows = new List<Flow>();
            balanceInput.Flows.Add(new Flow { Flows = flowDescription, Delta_error = 0.001 });

            var controller = new BalanceController();
            var result = controller.Post(balanceInput) as BalanceOutput;
            Assert.AreEqual(true, result.IsBalanced);
        }
    }
}
