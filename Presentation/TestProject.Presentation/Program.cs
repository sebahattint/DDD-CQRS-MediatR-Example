using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System.Reflection;
using TestProject.Application.Commands.User.Request;
using TestProject.Application.Handlers.User;
using TestProject.Infrastructure.Context;
using TestProject.Infrastructure.Extensions;
using TestProject.Infrastructure.Repositories.Base.Concrete;
using TestProject.Infrastructure.Repositories.Base.Interfaces;
using TestProject.Infrastructure.Repositories.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddElastic(builder.Configuration);
builder.Services.AddScoped(typeof(IElasticSearchRepository<>), typeof(ElasticSearchRepository<>));
//builder.Services.AddMediatR(typeof(CreateUserCommandRequest).GetTypeInfo().Assembly);
builder.Services.AddTransient<CreateUserQueryHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddDbContext<TestProjectDbContext>(db => db.UseSqlServer("Server=THE-CODED\\SQLEXPRESS2019;Database=TestDb;User Id=testproject;Password=123123"));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

//builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
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
