using AspNetMVC_P324.DAL;

using Microsoft.EntityFrameworkCore;

namespace AspNetMVC_P324
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
                    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Error");

            }
            app.UseStatusCodePagesWithReExecute("/Eror/Error1", "?code={0}");


            app.UseEndpoints(endpoints => {
                
                
             endpoints.MapControllerRoute(
             name: "areas",
             pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
             );
                
                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            

            app.Run();
        }
    }
}