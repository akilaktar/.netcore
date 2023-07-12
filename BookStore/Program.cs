using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("hellow my first middleware");
//    await next();
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello World From 2nd Middleware!");

//    await next();
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World From 3rd Middleware");
//});

app.UseHttpsRedirection();
//if we use anystatic file like images and css,js file or folder
app.UseStaticFiles();

app.UseRouting();

//app.UseEndpoints(endpoint =>
//{

//    endpoint.Map("/akil", async context =>
//    {
//        await context.Response.WriteAsync("Hello Akil World");
//    });
//});

app.UseEndpoints(endpoint =>
{
    endpoint.MapDefaultControllerRoute();
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
