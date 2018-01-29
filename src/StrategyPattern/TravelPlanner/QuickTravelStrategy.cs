using Microsoft.EntityFrameworkCore;
using StrategyPattern.Data;
using StrategyPattern.Domain;
using System.Linq;

namespace StrategyPattern.TravelPlanner
{
    public class QuickTravelStrategy : IStrategy
    {
        public Travel CalculateTravel(ApplicationDbContext dbContext, string from, string to)
        {
            var result = new Travel();
            var busStops = dbContext.BusStops
                .Include(e => e.Routes)
                .ToList();
            var current = busStops.First(e => e.Name.ToLower() == from.ToLower());
            while (current.Name.ToLower() != to.ToLower())
            {
                var route = current.Routes.OrderBy(e => e.Time).First();
                result.TotalCost += route.Cost;
                result.TotalLenght += route.Length;
                result.TotalTime = result.TotalTime.Add(route.Time);
                result.Stops.Add((current.Name, route.To.Name));
                current.Routes.Remove(route);
                current = route.To;
            }
            return result;
        }
    }
}
