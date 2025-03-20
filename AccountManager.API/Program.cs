using AccountManager.Client;
using AccountManager.Interfaces.Repositories;
using AccountManager.Interfaces.Services;
using AccountManager.Mappings.AutoMapperProfiles;
using AccountManager.Repository;
using AccountManager.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();


var web = WebAssemblyHostBuilder.CreateDefault(args);
web.RootComponents.Add<App>("#app");
web.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(web.HostEnvironment.BaseAddress) });

// Registering the API service
builder.Services.AddScoped<IAccountApiService, AccountApiService>();

await builder.Build().RunAsync();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AccountProfile>();
    cfg.AddProfile<SubscriptionProfile>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
