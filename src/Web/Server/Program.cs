using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Data;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddDbContext<DataDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion

#region App

var app = builder.Build();

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

app.Run();

#endregion