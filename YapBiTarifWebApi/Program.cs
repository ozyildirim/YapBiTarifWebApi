using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

//Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
                "Host=37.148.211.222;Database=yapbitarifDB;Port=5432;Username=postgres;Password=123123"
            )
    );

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseAuthorization();

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

app.MapControllers();

app.Run();
