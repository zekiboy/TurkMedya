using TurkMedya.Data;
using TurkMedya.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Projenin diğer katmanlarını sunum katmanımız olan Presentation için tanıtıyoruz
builder.Services.AddDataServices();
builder.Services.AddBusinessServices();

//Projemizde web üzerinden json data çekerken kullanabilmek adına httpClient ekliyoruz
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

