using Domain.Services.Promotions;
using Domain.Services.Promotions.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add a custom scoped service.
builder.Services.AddScoped<IBasketPromotionsService, BasketPromotionsService>();
builder.Services.AddScoped<IBasketProductsService, BasketProductsService>();

builder.Services.AddDateOnlyTimeOnlyStringConverters();
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
