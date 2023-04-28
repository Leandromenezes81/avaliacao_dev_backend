using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using Vectra.Avaliacao.Backend.Application.Commands.Users.CreateUser;
using Vectra.Avaliacao.Backend.Application.Validators.Users;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Services;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;
using Vectra.Avaliacao.Backend.Infra.Auth;
using Vectra.Avaliacao.Backend.Infra.Persistence.Data;
using Vectra.Avaliacao.Backend.Infra.Repositories;
using Vectra.Avaliacao.Backend.Infra.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureSwagger(builder);
ConfigureServices(builder);
ConfigureRepositories(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();

#region Authentication
void ConfigureAuthentication(WebApplicationBuilder builder)
{
    builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
}
#endregion

#region MVC
void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });

    builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
}
#endregion

#region Swagger
void ConfigureSwagger(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vectra.API", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using Bearer scheme."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });
}
#endregion

#region Services
void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<VectraDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddScoped<IAuthService, AuthService>();

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
}
#endregion

#region Repositories
void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
    builder.Services.AddScoped<IAccountRepository, AccountRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
#endregion
