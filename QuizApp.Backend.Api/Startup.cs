using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Backend.Library.Database;
using QuizApp.Backend.Library.Models.Identity;
using QuizApp.Backend.Library.Repositories;
using QuizApp.Backend.Library.Repositories.Interfaces;
using QuizApp.Backend.Library.Services;
using QuizApp.Backend.Library.Services.Interfaces;
using System.Text;

namespace QuizApp.Backend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QuizData")));

            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QuizIdentity")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<ICalculationService, CalculationService>();
            services.AddTransient<IStatisticsService, StatisticsService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}