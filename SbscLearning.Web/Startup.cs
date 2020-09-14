using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbcLearningHub.Business.Services;
using AbcLearningHub.Data.DataAccess;
using AbcLearningHub.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SbscLearning.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SbscLearning.Web.Mappers;

namespace SbscLearning.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<AbcLearningHubContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddTransient<DbContext, AbcLearningHubContext>();
            services.AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>));
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseExamService, CourseExamService>();
            services.AddTransient<ICourseExamRepository, CourseExamRepository>();
            services.AddTransient<IUserCourseExamCertificateService, UserCourseExamCertificateService>();
            services.AddTransient<IUserCourseExamCertificateRepository, UserCourseExamCertificateRepository>();
            services.AddTransient<IUserCourseService, UserCourseService>();
            services.AddTransient<IUserCourseRepository, UserCourseRepository>();
            services.AddTransient<IUserCourseExamService, UserCourseExamService>();
            services.AddTransient<IUserCourseExamRepository, UserCourseExamRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
