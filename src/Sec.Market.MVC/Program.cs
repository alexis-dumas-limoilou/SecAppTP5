using Microsoft.AspNetCore.Mvc;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Services;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddHttpClient<IProductService, ProductServiceProxy>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlApi")));
builder.Services.AddHttpClient<IUserService, UserServiceProxy>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlApi")));
builder.Services.AddHttpClient<IOrderService, OrderServiceProxy>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlApi")));
builder.Services.AddHttpClient<ICustomerReviewService, CustomerReviewServiceProxy>(client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("UrlApi")));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Auth";
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
