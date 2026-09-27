using ReportCreator.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrar o ExceptionFilter no DI antes de configurar os controllers
builder.Services.AddScoped<ReportCreator.API.Filters.ExceptionFilter>();

// Configura controllers e adiciona o filtro via DI
builder.Services.AddControllers(options => options.Filters.AddService<ReportCreator.API.Filters.ExceptionFilter>());
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
