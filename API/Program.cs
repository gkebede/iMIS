using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

 
   builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddCors(options =>
//  {

//  options.AddPolicy("CorsPolicy", policy =>
//  {
//  policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("*");
//                     //policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
//  });

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

app.Run();
