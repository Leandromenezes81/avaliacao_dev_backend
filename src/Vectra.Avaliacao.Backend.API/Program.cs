using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vectra.Avaliacao.Backend.Domain.Interfaces.Repositories;
using Vectra.Avaliacao.Backend.Domain.Interfaces.UnitOfWork;
using Vectra.Avaliacao.Backend.Infra.Persistence.Data;
using Vectra.Avaliacao.Backend.Infra.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);
ConfigureRepositories(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#region Services
void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<VectraDbContext>(options =>
        options.UseSqlServer(connectionString));
}
#endregion

#region Repositories
void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(IRepositoryBase<>));    
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
#endregion
