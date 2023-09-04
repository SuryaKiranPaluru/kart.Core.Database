using kart.Service.Buisness;
using kart.Service.DataAccess;
using kart.Service.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static kart.Service.Buisness.EntityMapperConfiguration;


var builder = WebApplication.CreateBuilder(args);



var builder1 = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


var configuration = builder1.Build();
// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//DBContext should always be Transient
builder.Services.AddDbContext<kartContext>(options => options.UseSqlServer(builder.Configuration["ConfigurationStrings:DefaultConnection"]));



//AddScoped is used for the lifetime of the request
builder.Services.AddScoped<IkartService, kartService>();
builder.Services.AddScoped<IkartRepository, kartRepository>();



var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperWebProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



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