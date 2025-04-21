global using System.Net.Http.Json;
global using Shared.Entities;
global using BudgetAppV2.Client.Services.TransactionService;
global using Shared.Entities.Users;
using BudgetAppV2.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddRadzenComponents();

builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "MyApplicationTheme"; // The name of the cookie
    options.Duration = TimeSpan.FromDays(365); // The duration of the cookie
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Custom Services
builder.Services.AddScoped<IClientFinancialTransactionService, ClientFinancialTransactionService>();
builder.Services.AddScoped<IClientFinancialTransactionHistoryService, ClientFinancialTransactionHistoryService>();
builder.Services.AddScoped<IClientAuthService, ClientAuthService>();

await builder.Build().RunAsync();