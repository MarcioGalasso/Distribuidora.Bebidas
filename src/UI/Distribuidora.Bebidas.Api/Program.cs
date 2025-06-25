using FluentValidation;
using FluentValidation.AspNetCore;
using Distribuidora.Bebidas.DependencyInjector.Configuration;
using Distribuidora.Bebidas.Domain.Options;
using Distribuidora.Bebidas.Domain.Validators;
using Distribuidora.Bebidas.Repository.Postgresql.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<DistribuidoraKafkaOption>(builder.Configuration.GetSection("Kafka:DeliveryDistribuidora"));
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .ConfigureDistribuidoraContext(builder.Configuration)
    .AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<OrderValidator>()
    .AddServices()
    .AddClient()
    .AddRepositories()
    .AddConsumers()
    .AddProducers()
    .AddProfiles()
    .AddKafka(builder.Configuration);



var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (feature?.Error is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            // Extrai só as mensagens
            var errors = validationException.Errors
                              .Select(e => e.ErrorMessage)
                              .Distinct()
                              .ToList();

            await context.Response.WriteAsJsonAsync(new { errors });
        }
        else
        {
            // Outras exceções: opcionalmente trate de forma genérica
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { errors = new[] { "An unexpected error occurred." } });
        }
    });
});
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
