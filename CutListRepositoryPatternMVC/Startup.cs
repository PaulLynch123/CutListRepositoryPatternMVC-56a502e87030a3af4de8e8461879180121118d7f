 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
/*not needed as moved the data inside DataAccess project
using CutListRepositoryPatternMVC.Data;
*/
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//replaced the removed one above
using CutList.DataAccess.Data;
using CutList.DataAccess.Data.Repository.IRepository;
using CutList.DataAccess.Data.Repository;
using CutList.DataAccess.Initializer;
using CutList.DataAccess.Seeders;

namespace CutListRepositoryPatternMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Configures dependency injection
        //Build on the services to use in our project
        public void ConfigureServices(IServiceCollection services)
        {
            //moved this file inside DataAccess
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
           //using the default connection string appsettings.json
                    Configuration.GetConnectionString("DefaultConnection")));
            /*when we register for account it will ask for confirmation
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            */
            //remove the above functionality for this application
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //add unitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Add my Initialiser (seeding live environment data, creating and deleting)
            services.AddScoped<IDbInitialiser, DbInitialiser>();

            //Add my data seeder (seeding test data)
            services.AddScoped<IProjectDataSeeder, ProjectDataSeeder>();

            //I have included RazorRuntimeCOmplication neGet package (MVC)
            //.AddNewtonsoftJson() for calling APIs use this Json object
            services.AddControllersWithViews().AddNewtonsoftJson().AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Middleware pipeline for request and response (context pipeline1 then pipeline2 etc response or 404 no response. Context Object goes back)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitialiser paulsInitialiser, IProjectDataSeeder paulsDataSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                //Add seeder data to development only
                paulsInitialiser.DevelopmentInitialise();
                paulsDataSeeder.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //Add my initialise method
            //paulsInitialiser.Initialise();

            app.UseAuthentication();
            app.UseAuthorization();

            //sessions middleware

            //default pattern
            //conventional or endPoint(we inject middleware)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //included Area with default of Factory folder/user
                    pattern: "{area=Factory}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
