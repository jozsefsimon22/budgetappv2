global using Shared.Entities;
global using Shared.Entities.Users;
global using Shared.Enums;
global using Microsoft.EntityFrameworkCore;
global using BudgetAppV2.Data;
global using BudgetAppV2.Services;
global using BudgetAppV2.Services.AuthService;
using BudgetAppV2.Client.Pages;
using BudgetAppV2.Client.Services.AuthService;
using BudgetAppV2.Client.Services.TransactionService;
using BudgetAppV2.Components;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddRazorComponents()
     .AddInteractiveServerComponents()
     .AddInteractiveWebAssemblyComponents();

builder.Services.AddRadzenComponents();

builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "MyApplicationTheme"; // The name of the cookie
    options.Duration = TimeSpan.FromDays(365); // The duration of the cookie
});

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

// Client Services
builder.Services.AddHttpClient<IClientFinancialTransactionService, ClientFinancialTransactionService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5194/");
});

builder.Services.AddHttpClient<IClientFinancialTransactionHistoryService, ClientFinancialTransactionHistoryService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5194/");
});

builder.Services.AddHttpClient<IClientAuthService, ClientAuthService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5194/");
});


//Register Custom Services
builder.Services.AddScoped<IServerFinancialTransactionService, ServerFinancialTransactionService>();
builder.Services.AddScoped<IServerFinancialTransactionHistoryService, ServerFinancialTransactionHistoryService>();
builder.Services.AddScoped<IServerAuthService, ServerAuthService>();

var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

// app.UseRouting();
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();