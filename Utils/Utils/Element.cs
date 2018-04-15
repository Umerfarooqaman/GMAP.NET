

using GMAP.NET.Enums;

namespace GMAP.NET.Utils
{
    public class Element
    {

        public ElementLevelStatus Status { get; set; }

        public Duration duration { get; set; }

        public Duration duration_in_traffic { get; set; }

        public Distance distance { get; set; }

        public Fare fare { get; set; }



    }
}