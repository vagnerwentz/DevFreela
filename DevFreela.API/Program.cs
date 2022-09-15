using DevFreela.API.Filters;
using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Application.Validators.UserValidator;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region "[Adding option]"
//Configure the OpeningTimeOption
//builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));
#endregion

#region "[Database]"
var connectionString = builder.Configuration.GetConnectionString("DevFreela");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region "[Dependency Injection]"
#endregion

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilters)));
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();

// Will search all classes at the Application Assembly, that implements the IRequestHandler and associate handler to each respective command
builder.Services.AddMediatR(typeof(CreateProjectCommand));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
