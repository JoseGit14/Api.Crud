using Api.Crud.Application.CommandHandler;
using Api.Crud.Application.Configuration.Dependencies;
using Api.Crud.Application.QueryHandler;
using Api.Crud.Config;
using Api.Crud.Data.Dependencies;
using Api.Crud.Domain.Configuration.Settings;
using AutoWrapper;
using AutoWrapper.Wrappers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddDataDependencies();
builder.Services.AddServiceDependencies();
builder.Services.Configure<DbConnection>(builder.Configuration.GetSection("DbConnection"));
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

builder.Services.AddMediatR(typeof(ProductCommandHandler));
builder.Services.AddMediatR(typeof(ProductQueryHandler));
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Api.Crud"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
{
    ShowApiVersion = true,
    ShowStatusCode = true,
    ApiVersion = "1.0",
    IsApiOnly = true
});

app.Run();
