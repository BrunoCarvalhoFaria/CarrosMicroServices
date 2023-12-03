using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http.Features;
using Carros.Aluguel.Api.Configuration;
using Carros.Aluguel.Infra.Data;
using Carros.Aluguel.Domain.Interfaces;
using Carros.Aluguel.Infra.Data.Repository;
using Carros.Aluguel.Api.AutoMapper;
using Carros.Aluguel.Application.AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aluguel de carros", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
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
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//Dependency Injection
builder.Services.AddDIConfiguration();

builder.Services.AddOptions();

//ConfigServices
var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql")!;
builder.Services.AddDbContext<CarrosCompraDbContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql)));

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
});

builder.Services.AddOptions();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Interface e Repositorio
builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

//Serviço Dominio
//builder.Services.AddSingleton<IServiceMessage, IServiceMessage>();

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile(new ViewModelToDomainMappingProfile());
    options.AddProfile(new ApplicationMappingProfile());
    options.AllowNullCollections = true;
});


var app = builder.Build();
var devClient = "http://localhost:7068";
app.UseCors(builder => builder.SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowCredentials()
    .WithOrigins(devClient));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CarrosCompraDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();



