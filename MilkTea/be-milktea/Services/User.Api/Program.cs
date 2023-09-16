using Microsoft.EntityFrameworkCore;
using User.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MT_DB_UserContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB"))
);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
