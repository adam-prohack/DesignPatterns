using System.Collections.Generic;
using System;

namespace StrategyPattern.Domain
{
    public class Travel
    {
        public ICollection<(string From, string To)> Stops { get; set; } = new List<(string From, string To)>();

        public long TotalLenght { get; set; }

        public long TotalCost { get; set; }

        public TimeSpan TotalTime { get; set; }
    }
}
