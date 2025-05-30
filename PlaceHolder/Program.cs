using PlaceHolder.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ApiService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Configuration.AddJsonFile("appsettings.json", false, true);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

