using System.Linq;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ODataBase
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOData();

            var connection = Configuration.GetConnectionString("Test1");
            services.AddDbContext<WorldContext>(options => options.UseMySQL(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EntitySet<City>("City");
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
                routeBuilder
                        .MaxTop(null)
                        .Filter() // Allow for the $filter Command
                        .Count() // Allow for the $count Command
                        .Expand() // Allow for the $expand Command
                        .OrderBy() // Allow for the $orderby Command
                        .Select() // Allow for the $select Command
                        .Expand();

                routeBuilder.EnableDependencyInjection();
            });
        }
    }
}
