using Mecalux.Domain.Service;
using Mecalux.Domain.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICharacterCounterService, CharacterCounterService>();
builder.Services.AddSingleton<ITextAnalyticsService, TextAnalyticsService>();
builder.Services.AddSingleton<ITextService, TextService>();
builder.Services.AddSingleton<IWordsService, WordsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
