using FMS.Server.Databases;
using FMS.Server.Hubs;
using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserService, UserService>();


// ÀÇÁ¸¼º ÁÖÀÔ
=======
// ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
>>>>>>> origin/main
builder.Services.AddTransient<IUserInfoRepository, UserInfoRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<FmsContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));



#region SIGNAL R CORS ï¿½ï¿½ï¿½
// SIGNAL R CORS ï¿½ï¿½ï¿½
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

#region SIGNAL R ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½
// SIGNAL R ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
#endregion


var app = builder.Build();

#region SIGNAL CORS ï¿½ï¿½ï¿½
// CORS ï¿½ï¿½ï¿½
app.UseCors();
#endregion

#region SIGNAL R ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½
// SIGNAL R ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½
app.UseResponseCompression();
app.MapHub<BroadcastHub>("/broadcastHub");
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



SetupServices setup = new();
await setup.SetupAdmin();



app.Run();
