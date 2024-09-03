using Application;
using InfoTehTestTask.Data;
using Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
//Add services to the container.
builder.Services.Configure<KestrelServerOptions>(config.GetSection("Kestrel"));



builder.Services.AddApplicationCore();
builder.Services.AddPersistence(config);
builder.Services.AddScoped<DatabaseMigrator>();
builder.Services.AddCors();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{

    // To Enable authorization using Swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                }
    );
});
builder.Services.AddAuthorization();
//builder.Services.AddSpaStaticFiles(configuration =>
//{
//    configuration.RootPath = "../ClientApp/dist";
//});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();
app.MapControllers();


app.MapFallbackToFile("index.html");


//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = "ClientApp";
//});
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
    await db.MigrateAsync();
}
app.UseExceptionHandler(builder =>
{

});
app.Run();
