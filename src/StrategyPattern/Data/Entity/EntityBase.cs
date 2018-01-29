using System.ComponentModel.DataAnnotations;

namespace StrategyPattern.Data.Entity
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
