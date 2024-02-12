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
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Magic.Words.Infrastructure.Configuration;
using Magic.Words.Core.Interfaces;
using Magic.Words.Infrastructure.Services;
using Magic.Words.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Magic.Words.Infrastructure.Jobs;

var builder = WebApplication.CreateBuilder(args);


 
builder.Services.AddHangfire((sp, config) => {
    var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("DBConnection");
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



builder.Services.AddRazorComponents();
// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "975859080538523";
    option.AppSecret = "c39feaea74bb535b754a7afa309cf751";
});

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.AddScoped<TestJobs>();
builder.Services.AddHttpClient();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
         new CultureInfo("ua-UA")
    };
    options.DefaultRequestCulture = new RequestCulture("ua-UA");  
    options.SupportedCultures = supportedCultures;
});
builder.Services.AddDbContext<ApplicationDbContext>(options=> 
                   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<OpenAIConfiguration>(builder.Configuration.GetSection("OpenAI"));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));


builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Shared/Index", "/Index");
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmailSender, EmailSenderService>();
builder.Services.AddScoped<IOpenAIService, OpenAIService>();
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapHub<ChatHub>("/chatHub");
app.UseHttpsRedirection();
app.UseStaticFiles();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
 
  app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
// app.MapControllerRoute(
//   name: "default",
//  pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


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
 
app.UseHangfireDashboard("/test/job-dashboard", new DashboardOptions {
 DashboardTitle = "Hangfire Job Demo Application",
DarkModeEnabled = true,
DisplayStorageConnectionString = false,
});
 

app.Run();
