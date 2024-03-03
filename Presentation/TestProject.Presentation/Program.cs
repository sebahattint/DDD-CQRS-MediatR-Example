using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestProject.Application.Handlers.User;
using TestProject.Infrastructure.Context;
using TestProject.Infrastructure.Repositories.Base.Concrete;
using TestProject.Infrastructure.Repositories.Base.Interfaces;
using TestProject.Infrastructure.Repositories.User;
using TestProject.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddElastic(builder.Configuration);
builder.Services.AddScoped(typeof(IElasticSearchRepository<>), typeof(ElasticSearchRepository<>));
builder.Services.AddTransient<CreateUserQueryHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddDbContext<TestProjectDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

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
