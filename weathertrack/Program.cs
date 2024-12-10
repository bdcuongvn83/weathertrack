var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Thêm Session vào các dịch vụ của ứng dụng
services.AddDistributedMemoryCache(); // Cấu hình cache để lưu session
services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thiết lập thời gian timeout
});


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Sử dụng session
app.UseSession();//cuongbd moi them 

app.MapRazorPages();

app.Run();
