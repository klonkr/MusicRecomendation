using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MusicRecomendation.API.DAL;
using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;

namespace MusicRecomendation.API
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
            services.AddOptions();
            services.AddCors();
            var section = Configuration.GetSection("ApplicationConfig");
            services.Configure<ApplicationConfig>(section);

            //services.AddScoped<IRepository<Track>, Repository<Track>>();
            //services.AddScoped<IRepository<Token>, Repository<Token>>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IAuthorization, Authorization>();
            services.AddScoped<IClient, Client>();
            services.AddScoped<IRequest, Request>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(
                    options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                );
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
