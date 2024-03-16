using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopApi.Domain.Handlers;
using ShopApi.Domain.Infra.Context;
using ShopApi.Domain.Infra.Repositories;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddTransient<ClienteHandler, ClienteHandler>();
builder.Services.AddTransient<LoginHandler, LoginHandler>();

var key = Encoding.ASCII.GetBytes("sdasdawdqwfjiadasdasdqwdqsxqwd232543123cnouasdbqw");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//autenticação
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//desafio
}).AddJwtBearer(x =>
{

    x.TokenValidationParameters = new TokenValidationParameters//validando o token
    {
        ValidateIssuerSigningKey = true,//validando a chave
        IssuerSigningKey = new SymmetricSecurityKey(key),//chave de segurança
        ValidateIssuer = false,//validando o emissor
        ValidateAudience = false//validando o publico
    };
});


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
