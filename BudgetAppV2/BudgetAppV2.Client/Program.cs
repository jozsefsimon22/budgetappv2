global using System.Net.Http.Json;
global using Shared.Entities;
global using BudgetAppV2.Client.Services.TransactionService;
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
builder.Services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();

await builder.Build().RunAsync();