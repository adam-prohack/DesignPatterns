using StrategyPattern.Data;
using StrategyPattern.Domain;

namespace StrategyPattern.TravelPlanner
{
    public class Planner<TStrategy> where TStrategy : IStrategy
    {
        public string From { get; set; }
        public string To { get; set; }

        readonly IStrategy _strategy;
        readonly ApplicationDbContext _dbContext;

        public Travel Plan() => _strategy.CalculateTravel(_dbContext, From, To);

        public Planner(TStrategy strategy, ApplicationDbContext dbContext)
        {
            _strategy = strategy;
            _dbContext = dbContext;
        }
    }
}
