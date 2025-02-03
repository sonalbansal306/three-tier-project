using BusinessLogicLayer.LogicServices;
using DataAccessLayer.DataContext;
using DataAccessLayer.DataServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IStudentsLogic, StudentsLogic>();
builder.Services.AddSingleton<IStudentsDataDAL, StudentsDataDAL>();
builder.Services.AddSingleton<IDapperOrmHelper, DapperOrmHelper>();
builder.Services.AddSingleton<ICoursesLogic, CoursesLogic>();
builder.Services.AddSingleton<ICoursesDataDAL, CoursesDataDAL>();



builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(20);
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

app.UseRouting();
app.UseSession();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
            name: "area",           
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

       app.MapControllerRoute(
            name: "area",           
            pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}");

       app.MapControllerRoute(            
            name: "default",
            pattern: "{controller=Students}/{action=StudentsList}/{id?}");

       app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Courses}/{action=CoursesList}/{id?}");

       app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();


