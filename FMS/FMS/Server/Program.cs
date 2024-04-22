using FMS.Server.Databases;
using FMS.Server.Hubs;
using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserService, UserService>();


// ������ ����
=======
// ������ ����
>>>>>>> origin/main
builder.Services.AddTransient<IUserInfoRepository, UserInfoRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddDbContext<FmsContext>(options =>
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
