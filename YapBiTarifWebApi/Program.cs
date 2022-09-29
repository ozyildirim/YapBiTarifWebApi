using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<DataContext>(
        options =>
            options.UseNpgsql(
                "Host=127.0.0.1;Database=yapbitarifDB;Port=5432;Username=postgres;Password=postgre123"
            )
    );

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    }
);

app.UseAuthorization();

app.MapControllers();

app.Run();
