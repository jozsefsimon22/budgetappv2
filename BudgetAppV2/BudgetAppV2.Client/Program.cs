global using System.Net.Http.Json;
global using Shared.Entities;
global using BudgetAppV2.Client.Services.TransactionService;
global using Shared.Entities.Users;
global using Blazored.LocalStorage;
global using BudgetAppV2.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
using BudgetAppV2.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Radzen Services
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "MyApplicationTheme"; // The name of the cookie
    options.Duration = TimeSpan.FromDays(365); // The duration of the cookie
});

// HTTP Client
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Authentication
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

//Custom Services
builder.Services.AddScoped<IClientFinancialTransactionService, ClientFinancialTransactionService>();
builder.Services.AddScoped<IClientFinancialTransactionHistoryService, ClientFinancialTransactionHistoryService>();
builder.Services.AddScoped<IClientAuthService, ClientAuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();