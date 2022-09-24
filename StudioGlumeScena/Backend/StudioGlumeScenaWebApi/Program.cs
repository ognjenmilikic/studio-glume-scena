using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudioGlumeScena.BusinessLogic.Classes;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.DataAccess.Classes;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var dozvoljeneRute = "DozvoljeneRute";
var frontUrl = "http://localhost:4200";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: dozvoljeneRute,
            policy =>
            {
                policy.WithOrigins(frontUrl)
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
        );
});
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IPrijavaZaUpisBL, PrijavaZaUpisBL>();
builder.Services.AddScoped<IAuthBL, AuthBL>();
builder.Services.AddScoped<ILokacijaBL, LokacijaBL>();
builder.Services.AddScoped<IKorisnikBL, KorisnikBL>();
builder.Services.AddScoped<IProfesorBL, ProfesorBL>();
builder.Services.AddScoped<IUcenikBL, UcenikBL>();
builder.Services.AddScoped<IGrupaBL, GrupaBL>();
builder.Services.AddScoped<IUzrastBL, UzrastBL>();
builder.Services.AddScoped<ILokacijaDAL, LokacijaDAL>();
builder.Services.AddScoped<IKorisnikDAL, KorisnikDAL>();
builder.Services.AddScoped<IUcenikDAL, UcenikDAL>();
builder.Services.AddScoped<IProfesorDAL, ProfesorDAL>();
builder.Services.AddScoped<IPrijavaZaUpisDAL, PrijavaZaUpisDAL>();
builder.Services.AddScoped<IGrupaDAL, GrupaDAL>();
builder.Services.AddScoped<IKorisnickaUlogaDAL, KorisnickaUlogaDAL>();
builder.Services.AddScoped<IUzrastDAL, UzrastDAL>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = frontUrl,
            ValidAudience = frontUrl,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AuthSettings").GetSection("JwtSecretKey").Value))
        };
    });

builder.Services.AddControllersWithViews();
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudioGlumeScenaContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("StudioGlumeScenaConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(dozvoljeneRute);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
