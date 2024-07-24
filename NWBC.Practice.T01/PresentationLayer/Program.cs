using Common.ExeptionHandler;
using Common.Logger;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Profiles;
using DataAccessLayer.Repositories;
using DataLayer.Context;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Host.ConfigureSerilog();
    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddDbContext<MyDbContext>();    // thêm context
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //thêm automapper (chưa dùng)
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();  // thêm custom eh class vào pipeline
    builder.Services.AddProblemDetails();      // lớp để format output exception cho đẹp
    
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
   
    
    var app = builder.Build();

    
// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler(); // sử dụng global exception handler
    
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch
{
    Log.Fatal("Unexpected exception during host creation.");
}
finally
{
    Log.CloseAndFlush();
}