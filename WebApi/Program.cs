using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contexts;
using WebApi.Data.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddGrpc();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("EventsDb")));
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

app.MapGrpcService<GrpcEventService>();

app.MapOpenApi();
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
