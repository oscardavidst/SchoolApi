using Application;
using Identity;
using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Persistence;
using Shared;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddIdentityInfraestructure(builder.Configuration);
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(optionsSwagger =>
{
    optionsSwagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SchoolApi",
        Description = "ASP.NET Core Web API para prueba t�cnica",
        Contact = new OpenApiContact
        {
            Name = "Oscar David Soto Tellez",
            Url = new Uri("https://www.linkedin.com/in/oscar-david-soto/")
        }
    });
    optionsSwagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Porfavor ingrese el token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    optionsSwagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {{ new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }}, new string [] {} }});
});

var app = builder.Build();

// Identity
var services = app.Services.CreateAsyncScope();
var userManager = services.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleManager = services.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await DefaultRoles.SeedAsync(userManager, roleManager);
await DefaultAdministratorUser.SeedAsync(userManager, roleManager);
await DefaultBasicUser.SeedAsync(userManager, roleManager);
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UserErrorHandlingMiddleware();
app.MapControllers();

app.Run();
