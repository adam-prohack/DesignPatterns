using Microsoft.AspNetCore.Mvc;
using StrategyPattern.TravelPlanner;

namespace StrategyPattern.Controllers
{
    [Route("travel")]
    public class TravelController : Controller
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok(true);

        // Calculate cheapest way from manhatan to dubai
        [HttpGet("cheapest")]
        public IActionResult CheapestWay([FromServices] Planner<CheapTravelStrategy> planner)
        {
            planner.From = "manhatan";
            planner.To = "dubai";
            return Ok(planner.Plan());
        }

        // Calculate shortest way from manhatan to dubai
        [HttpGet("shortest")]
        public IActionResult ShortestWay([FromServices] Planner<ShortTravelStrategy> planner)
        {
            planner.From = "manhatan";
            planner.To = "dubai";
            return Ok(planner.Plan());
        }

        // Calculate quickest way from manhatan to dubai
        [HttpGet("quickest")]
        public IActionResult QuickestWay([FromServices] Planner<QuickTravelStrategy> planner)
        {
            planner.From = "manhatan";
            planner.To = "dubai";
            return Ok(planner.Plan());
        }
    }
}