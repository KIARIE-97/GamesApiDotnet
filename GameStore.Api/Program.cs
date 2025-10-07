using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add scoped lifetime? an new instance of the db context is created for every request:
// dbconnection are limited and expensive ensure they are open and close, transactions for data consistency, shortlived , reduce mem overhead
builder.Services.AddDbContext<GameStoreContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

app.MapGameEndpoints();

await app.MigrateDbAsync();

app.Run();
