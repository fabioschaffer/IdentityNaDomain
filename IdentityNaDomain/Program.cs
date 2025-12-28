using Aplicacao.Interfaces;
using InfraEstrutura.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AdicionaRepositorio(builder.Configuration);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

