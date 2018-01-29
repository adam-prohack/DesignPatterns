using Microsoft.AspNetCore.Http;
using StrategyPattern.Data;
using System.Threading.Tasks;
using System.Linq;
using StrategyPattern.Data.Entity;

namespace StrategyPattern.Middleware
{
    public class DataSeed
    {
        readonly RequestDelegate _next;

        public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
        {
            if (dbContext.Routes.Count() > 0 && dbContext.BusStops.Count() > 0)
            {
                await _next(context);
                return;
            }

            var manhatanBusStop = new BusStopEntity("Manhatan");
            var newYorkBusStop = new BusStopEntity("NewYork");
            var londonBusStop = new BusStopEntity("London");
            var bangkokBusStop = new BusStopEntity("Bangkok");
            var dubaiBusStop = new BusStopEntity("Dubai");

            dbContext.Routes.Add(new RouteEntity(20, 10, 2, manhatanBusStop, newYorkBusStop));
            dbContext.Routes.Add(new RouteEntity(20, 10, 2, newYorkBusStop, dubaiBusStop));

            dbContext.Routes.Add(new RouteEntity(20, 20, 1, manhatanBusStop, londonBusStop));
            dbContext.Routes.Add(new RouteEntity(10, 20, 1, londonBusStop, dubaiBusStop));

            dbContext.Routes.Add(new RouteEntity(10, 20, 2, manhatanBusStop, bangkokBusStop));
            dbContext.Routes.Add(new RouteEntity(10, 20, 2, bangkokBusStop, londonBusStop));

            dbContext.BusStops.AddRange(manhatanBusStop, newYorkBusStop, londonBusStop, bangkokBusStop, dubaiBusStop);
            await dbContext.SaveChangesAsync();
            await _next(context);
        }

        public DataSeed(RequestDelegate next)
        {
            _next = next;
        }
    }
}
