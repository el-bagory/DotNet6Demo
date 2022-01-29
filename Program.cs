using Demo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;  
using Newtonsoft.Json.Serialization;

using AutoMapper;
using Demo.Data.Entities;
using Demo.BL.Repository; 
using Demo.BL.Interface;
using Demo.BL.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// builder.Services.AddDefaultIdentity<IdentityUser>
// builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//             {
//                 options.SignIn.RequireConfirmedAccount = false;
//                 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
//                 options.User.RequireUniqueEmail = true;
//             }).AddEntityFrameworkStores<ApplicationDbContext>();
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// builder.Services.AddDefaultIdentity<IdentityUser>
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                // options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                options.User.RequireUniqueEmail = true;
                        // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt=> {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();
builder.Services.AddScoped<IApplicationUserRep, ApplicationUserRep>();
builder.Services.AddScoped<ICountryRep, CountryRep>();
builder.Services.AddScoped<ICityRep, CityRep>();
builder.Services.AddScoped<IDistrictRep, DistrictRep>();
builder.Services.AddScoped<IProjectRep, ProjectRep>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();


builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));





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


app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
// app.MapRazorPages();