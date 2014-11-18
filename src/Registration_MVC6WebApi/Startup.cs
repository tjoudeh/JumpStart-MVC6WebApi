using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Registration_MVC6WebApi.Models;


namespace Registration_MVC6WebApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration().AddJsonFile("config.json").AddEnvironmentVariables();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework().AddSqlServer().AddDbContext<RegistrationDbContext>();

            services.AddMvc();

            //Resolve dependency injection
            services.AddSingleton<IRegistrationRepo, RegistrationRepo>();
            services.AddSingleton<RegistrationDbContext, RegistrationDbContext>();
        }
        public void Configure(IApplicationBuilder app)
        {

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
            app.UseMvc();

            app.UseWelcomePage();

        }
    }
}
