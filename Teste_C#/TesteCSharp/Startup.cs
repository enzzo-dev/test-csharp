using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCSharp.Dominio.Handlers.CandidatesHandle;
using TesteCSharp.Dominio.Handlers.ExperienceCandidatesHandle;
using TesteCSharp.Dominio.Repositories;
using TesteCSharp.InfraData.Contexts;
using TesteCSharp.InfraData.Repositories;

namespace TesteCSharp
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
            services.AddControllersWithViews();
            services.AddDbContext<CSharpContext>(x => x.UseSqlServer(Configuration.GetConnectionString("StringConnection")));
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //Injeções de dependências
            #region Candidates
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<RegisterCandidateHandler, RegisterCandidateHandler>();
            services.AddTransient<UpdateCandidateHandler, UpdateCandidateHandler>();
            services.AddTransient<DeleteCandidateHandler, DeleteCandidateHandler>();
            #endregion
            #region Candidates Experiences
            services.AddTransient<ICandidateExperienceRepository, CandidateExperienceRepository>();
            services.AddTransient<RegisterExperienceCandidateHandler,RegisterExperienceCandidateHandler>();
            services.AddTransient<UpdateExperienceCandidateHandler, UpdateExperienceCandidateHandler>();
            services.AddTransient<DeleteExperienceCandidateHandler, DeleteExperienceCandidateHandler>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Candidates}/{action=Index}/{id?}");
            });
        }
    }
}
