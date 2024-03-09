using API.Repository.Product;
using API.Service.Product;
using Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();

string MysqlConnctionString = builder.Configuration.GetConnectionString("Mysql") ?? "";
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var ServerVersion = new MySqlServerVersion(new Version(8, 0, 33));
    options.UseMySql(MysqlConnctionString, ServerVersion);
});

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var MysqlContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    MysqlContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
