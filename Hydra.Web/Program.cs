using Hydra.Infrastructure.Configuration;
using Hydra.Migrations;
using Microsoft.EntityFrameworkCore;
//using Serilog;
using System.Reflection;

//SerilogStartup.ConfigureLogging();


var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureApplicationServices(builder);

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//// Update Database
//builder.Services.AddDbContext<MigrationContext>((serviceProvider, options) =>
//    options.UseSqlServer(connectionString), ServiceLifetime.Transient);
//try
//{

//    using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
//    {
//        var context = serviceProvider.GetRequiredService<MigrationContext>();
//        context.Database.Migrate();
//    }
//}
//catch (System.Exception ex)
//{
//    //Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
//    //throw;
//}

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureRequestPipeline();


app.Run();

public partial class Program { }