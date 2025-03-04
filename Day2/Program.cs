using Microsoft.EntityFrameworkCore;
using Repository;
namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<InstituteContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

            builder.Services.AddSession();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
              name: "CourseShortcut",
              pattern: "crs/{action}",
              defaults: new { controller = "Course", action = "AllCourses"});
            
            app.MapControllerRoute(
              name: "insCourseShortcut",
              pattern: "ins/{action}",
              defaults: new { controller = "Instructor", action = "Index" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
