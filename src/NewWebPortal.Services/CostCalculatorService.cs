using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using NewWebPortal.ApplicationCore.Utilities;
using static NewWebPortal.ApplicationCore.Utilities.Enums;

namespace NewWebPortal.Services
{
    public class CostCalculatorService : ICostCalculatorService
    {
        public Cost CalculateCost(Area area,State  state,byte childCount)
        {
            return CostCalculatorUtility.CostList.Find(c=>c.Area==area && c.State==state && c.ChildCount == childCount);
        }
    }
}
