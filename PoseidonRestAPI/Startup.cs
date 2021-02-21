using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PoseidonRestAPI.Data;
using PoseidonRestAPI.Repositories;
using PoseidonRestAPI.Services;
using PoseidonRestAPI.Profiles;

namespace PoseidonRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // context
            services.AddDbContext<LocalDbContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddAutoMapper(typeof(AutoMapping));           

            // repository
            services.AddScoped<IBidListRepository, BidListRepository>();
            services.AddScoped<ICurvePointRepository, CurvePointRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // services
            services.AddTransient<IBidListService, BidListService>();
            services.AddTransient<ICurvePointService, CurvePointService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IRuleService, RuleService>();
            services.AddTransient<ITradeService, TradeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJWTTokenRepository, JWTTokenRepository>();

            // Swagger doc
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
