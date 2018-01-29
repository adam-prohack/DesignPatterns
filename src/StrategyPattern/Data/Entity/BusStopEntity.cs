using System.Collections.Generic;

namespace StrategyPattern.Data.Entity
{
    public class BusStopEntity : EntityBase
    {
        public string Name { get; set; }

        public ICollection<RouteEntity> Routes { get; set; }

        public BusStopEntity()
        {
        }

        public BusStopEntity(string name)
        {
            Name = name;
        }
    }
}
