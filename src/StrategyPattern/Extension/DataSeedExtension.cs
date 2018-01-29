using Microsoft.AspNetCore.Builder;

namespace StrategyPattern.Extension
{
    public static class DataSeedExtension
    {
        public static IApplicationBuilder UseDataSeed(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware.DataSeed>();
        }
    }
}
