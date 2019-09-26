using NewWebPortal.ApplicationCore.Entities;
using System.Collections.Generic;

namespace NewWebPortal.ApplicationCore.Utilities
{
    public static class CostCalculatorUtility
    {
        public static List<Cost> CostList=>
            new List<Cost>()
            {
                new Cost() { Area = Enums.Area.Metro, State = Enums.State.Vic, ChildCount = 1, PrimaryCost = 10000, SecondaryCost = 30000, UniversityCost = 120000 },
                new Cost() { Area = Enums.Area.Metro, State = Enums.State.Vic, ChildCount = 2, PrimaryCost = 20000, SecondaryCost = 60000, UniversityCost = 240000 },
                new Cost() { Area = Enums.Area.Regional, State = Enums.State.Vic, ChildCount = 1, PrimaryCost = 5000, SecondaryCost = 15000, UniversityCost = 60000 },
                new Cost() { Area = Enums.Area.Regional, State = Enums.State.Vic, ChildCount = 2, PrimaryCost = 7000, SecondaryCost = 20000, UniversityCost = 90000 },
                new Cost() { Area = Enums.Area.Metro, State = Enums.State.Nsw, ChildCount = 1, PrimaryCost = 7000, SecondaryCost = 20000, UniversityCost = 90000 }
            };
    }
}
