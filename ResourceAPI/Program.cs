using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ResourceAPI.EF.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JSON serializer - Added
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

//Json configuration
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables().Build();

//Database Connection String Configuration
builder.Services.AddDbContext<PaymentsContext>(optionsAction =>
{
    optionsAction.UseSqlServer(configuration.GetConnectionString(name: "PaymentDatabase"));
});

//Updated CORS
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAnyOrigin",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    }));

var app = builder.Build();

//Enable CORS - Added 
//Later use whitelisted sources instead of allowing all
//app.UseCors(configuration => configuration.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseCors("AllowAnyOrigin");

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
