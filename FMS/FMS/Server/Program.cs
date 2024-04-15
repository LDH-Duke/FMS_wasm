using FMS.Server.Hubs;
using FMS.Server.Models;
using FMS.Server.Repository.UserRepository;
using FMS.Server.Services;
using FMS.Server.Services.Interfaces;
using FMS.Server.Services.UserService;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
builder.Services.AddTransient<IUserServiceAsync, UserService>();
builder.Services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
*/

// User������
builder.Services.AddTransient<IUsersService, UsersService>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));


#region SIGNAL R CORS ���
// SIGNAL R CORS ���
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7191")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((host) => true);
    });
});
#endregion

#region SIGNAL R ���� ���
// SIGNAL R ���� ���
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
#endregion


var app = builder.Build();

#region SIGNAL CORS ���
// CORS ���
app.UseCors();
#endregion

#region SIGNAL R ���� ���
// SIGNAL R ���� ���
app.UseResponseCompression();
app.MapHub<ChatHub>("/chathub");
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
