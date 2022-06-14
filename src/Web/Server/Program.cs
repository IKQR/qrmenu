using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Mappers.Base;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddDbContext<DataDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.MapServices();
builder.Services.BackMapServices();

#endregion

#region App

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
}
app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

#endregion