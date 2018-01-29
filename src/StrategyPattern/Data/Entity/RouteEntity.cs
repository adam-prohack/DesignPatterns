using System;

namespace StrategyPattern.Data.Entity
{
    public class RouteEntity : EntityBase
    {
        public long Length { get; set; }

        public TimeSpan Time { get; set; }

        public long Cost { get; set; }

        public virtual BusStopEntity From { get; set; }

        public virtual BusStopEntity To { get; set; }

        public RouteEntity()
        {

        }

        public RouteEntity(long cost, long length, long hours, BusStopEntity from, BusStopEntity to)
        {
            Cost = cost;
            Length = length;
            Time = TimeSpan.FromHours(hours);
            From = from;
            To = to;
        }
    }
}
