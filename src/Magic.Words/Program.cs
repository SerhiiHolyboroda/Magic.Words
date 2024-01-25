using Magic.Words.Core.Repositories;
using Magic.Words.Core.Repository;
using Magic.Words.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Magic.Words.Shared;
using Stripe;
using Magic.Words.Shared.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.Connections;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire((sp, config) => {
    var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
    config.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();

builder.Services.AddSignalR(hubOptions =>
{
  //  hubOptions.AddFilter<GlobalHubFilter>();

    hubOptions.EnableDetailedErrors = true;
    hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);

})
    .AddHubOptions<MyHub>(options =>
    {
     //   options.AddFilter<LocalChatHubFilter>();
        options.EnableDetailedErrors = true;
        options.KeepAliveInterval = TimeSpan.FromMinutes(5);

    });




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=> 
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
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
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
; app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<MyHub>("/myHub", options => { 
options.ApplicationMaxBufferSize = 128;
    options.TransportMaxBufferSize = 128;
    options.LongPolling.PollTimeout = TimeSpan.FromMinutes(1);
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});

/*
app.MapHub<MyHub>("/myHub", async string message, IHubContext<MyHub> hubContext) =>
{ string data = "some string test data";
    await hubContext.Clients.All.SendAsync("Receive", data);
}
);
*/
app.UseHangfireDashboard();
//app.UseHangfireDashboard("test/job-dashboard" , new DashboardOptions {
// DashboarsTitle = "Hangfire Job Demo Application";
//DarkModeEnabed = false;
//DisplayStorageConnectionString = false;
//});
app.Run();
