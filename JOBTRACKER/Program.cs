using JOBTRACKER.Data;
using JOBTRACKER.Repositories;
using JOBTRACKER.Services;
using JOBTRACKER.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ─── DATABASE ────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// ─── REPOSITORIES ─ Scoped (new instance per HTTP request) ───────────────────
// Scoped is correct for DB-touching services because one DbContext = one request

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IJobService, Jobservice>();


// Transient: ValidationService is stateless — safe to create every time it's needed

//builder.Services.AddTransient<IValidationService, ValidationService>();

// Singleton: swap this one line to go from Console → Email notifications.
// Every controller, every service, every file — zero changes needed.
// THIS is why we code to interfaces.
builder.Services.AddSingleton<INotificationService, ConsoleNotificationService>();

// Production: builder.Services.AddSingleton<INotificationService, EmailNotificationService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
