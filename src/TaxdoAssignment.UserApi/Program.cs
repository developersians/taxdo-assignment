using TaxdoAssignment.Application;
using TaxdoAssignment.Infrastructure;
using TaxdoAssignment.UserApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<OutboxProcessorHostedService>();

builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApiLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
