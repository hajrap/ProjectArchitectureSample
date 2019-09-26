using NewWebPortal.ApplicationCore.Entities;
using static NewWebPortal.ApplicationCore.Utilities.Enums;

namespace NewWebPortal.ApplicationCore.Interfaces.Services
{
    public interface ICostCalculatorService
    {
        Cost CalculateCost(Area area , State state, byte childCount);
    }
}
