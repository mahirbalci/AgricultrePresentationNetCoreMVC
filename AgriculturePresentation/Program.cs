using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace AgriculturePresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



			builder.Services.AddDbContext<AgricultureContext>();

            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AgricultureContext>();

            builder.Services.ContainerDependencies();

            builder.Services.AddSingleton<IValidator<Team>, TeamValidator>();

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddMvc(config =>
            {
                // buradaki policy aslýnda bir politika yetkilendirmenin inþaa edilmesi için gerekli olan politika yani biz diyoruz ki sayfalarýma eriþim saðlamak için authentike olmuþ bir kullanýcý olmasý gerekiyor bunun sayesinde bunu uygulamada uyguluyor oluyoruz.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddMvc();

            builder.Services.AddAuthentication(
                    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
                    {
                        x.LoginPath="/Login/Index/";  // kiþi authentice deðilse yönlendireleceði komut
                    });
                

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}