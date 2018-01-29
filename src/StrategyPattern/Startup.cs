using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StrategyPattern.Data;
using StrategyPattern.Extension;
using StrategyPattern.TravelPlanner;

namespace StrategyPattern
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationDbContext>(config =>
            {
                config.UseInMemoryDatabase("StrategyPatternDB", options => { });
            }).AddEntityFrameworkInMemoryDatabase();

            services.AddTransient<CheapTravelStrategy>();
            services.AddTransient<Planner<CheapTravelStrategy>>();

            services.AddTransient<ShortTravelStrategy>();
            services.AddTransient<Planner<ShortTravelStrategy>>();

            services.AddTransient<QuickTravelStrategy>();
            services.AddTransient<Planner<QuickTravelStrategy>>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDataSeed();
            app.UseMvc();
        }
    }
}
