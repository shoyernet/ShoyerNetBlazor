using ShoyerNetBlazor.BL.HostApplicationExtensions;
using ShoyerNetBlazor.Common.Hubs;
using ShoyerNetBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

var googleJsonPath = builder.Configuration["GOOGLE"] ?? string.Empty;

builder.AddWE4UGoogleServices(googleJsonPath);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapHub<ChatHub>("/chathub");

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
