using Moq;
using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using NewWebPortal.ApplicationCore.Utilities;
using NUnit.Framework;

namespace NewWebPortal.UnitTests.Services
{

    public class CostCalculatorServiceTest
    {
        private readonly ICostCalculatorService _costCalculatorService;

        private static Cost ExpectedCostMetroVicTwoChildren =>
           new Cost()
           {
               PrimaryCost = 20000,
               SecondaryCost = 60000,
               UniversityCost = 240000
           };

        private static Cost ExpectedCostRegionalVicOneChild =>
            new Cost()
            {
                PrimaryCost = 5000,
                SecondaryCost = 15000,
                UniversityCost = 60000
            };

        private static Cost ExpectedCostMetroVicOneChild =>
            new Cost()
            {
                PrimaryCost = 10000,
                SecondaryCost = 30000,
                UniversityCost = 120000
            };


        public CostCalculatorServiceTest()
        {
            _costCalculatorService = new Mock<ICostCalculatorService>().Object;
        }

        [Test]
        public void CalculateCost_MetroVICOneChild_MatchCost()
        {
            //Act
            Cost actualCost = _costCalculatorService.CalculateCost(Enums.Area.Metro, Enums.State.Vic, 1);

            //Assert
            Assert.AreEqual(ExpectedCostMetroVicOneChild.PrimaryCost, actualCost.PrimaryCost);
            Assert.AreEqual(ExpectedCostMetroVicOneChild.SecondaryCost, actualCost.SecondaryCost);
            Assert.AreEqual(ExpectedCostMetroVicOneChild.UniversityCost, actualCost.UniversityCost);
        }

        [Test]
        public void CalculateCost_MetroVICTwoChildren_MatchCost()
        {
            //Act
            Cost actualCost = _costCalculatorService.CalculateCost(Enums.Area.Metro, Enums.State.Vic, 2);

            //Assert
            Assert.AreEqual(ExpectedCostMetroVicTwoChildren.PrimaryCost, actualCost.PrimaryCost);
            Assert.AreEqual(ExpectedCostMetroVicTwoChildren.SecondaryCost, actualCost.SecondaryCost);
            Assert.AreEqual(ExpectedCostMetroVicTwoChildren.UniversityCost, actualCost.UniversityCost);
        }

        [Test]
        public void CalculateCost_RegionalVICOneChild_MatchCost()
        {
            //Act
            Cost actualCost = _costCalculatorService.CalculateCost(Enums.Area.Regional, Enums.State.Vic, 1);

            //Assert
            Assert.AreEqual(ExpectedCostRegionalVicOneChild.PrimaryCost, actualCost.PrimaryCost);
            Assert.AreEqual(ExpectedCostRegionalVicOneChild.SecondaryCost, actualCost.SecondaryCost);
            Assert.AreEqual(ExpectedCostRegionalVicOneChild.UniversityCost, actualCost.UniversityCost);
        }

        [Test]
        public void CalculateCost_RelativesCosts_NotMatch()
        {
            //Act
            Cost actualCost = _costCalculatorService.CalculateCost(Enums.Area.Metro, Enums.State.Nsw, 1);

            //Assert
            Assert.AreEqual(actualCost.PrimaryCost,actualCost.SecondaryCost);
            Assert.AreEqual(actualCost.SecondaryCost, actualCost.UniversityCost);
            Assert.AreEqual(actualCost.PrimaryCost, actualCost.UniversityCost);
        }
    }
}
