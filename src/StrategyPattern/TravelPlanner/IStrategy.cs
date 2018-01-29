using StrategyPattern.Data;
using StrategyPattern.Domain;

namespace StrategyPattern.TravelPlanner
{
    public interface IStrategy
    {
        Travel CalculateTravel(ApplicationDbContext dbContext, string from, string to);
    }
}
