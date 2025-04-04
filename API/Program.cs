using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//    builder.Services.AddDbContext<DataContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddCors(options =>
//  {

//      options.AddPolicy("CorsPolicy", policy =>
//      {
//          policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("*");
//          //policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
//      });

//  });

// builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));
// builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();//! GIVE US THE DESIRE SERVICE 
    //var userManager = services.GetRequiredService<UserManager<Member>>();

    await context.Database.MigrateAsync();//! this will create the database if it does not exist and apply any pending migrations
    await DbInitializer.SeedData(context);//! and then dotnet watch run
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();//! GIVE US THE DESIRE SERVICE  again 
    logger.LogError(ex, "An error occurred during migration!");
}


app.Run();
