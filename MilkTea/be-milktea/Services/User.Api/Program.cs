using Microsoft.EntityFrameworkCore;
using User.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MT_DB_UserContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();