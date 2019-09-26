using NewWebPortal.ApplicationCore.Utilities;

namespace NewWebPortal.ApplicationCore.Entities
{
    public class Cost
    {
        public Enums.Area Area { get; set; }
        public Enums.State State { get; set; }
        public byte ChildCount { get; set; }
        public float PrimaryCost { get; set; }
        public float SecondaryCost { get; set; }
        public float UniversityCost { get; set; }
    }
}
