using store.API;
using store.Domain.Config;
using store.Repository.Data;
using store.Domain.Interfaces;
using store.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using UserServiceV1 = store.Service.Service.v1.UsersService;
using UserServiceV2 = store.Service.Service.v2.UsersService;
using userRepositoryv2 = store.Repository.Repository.v2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<UserServiceV1>();
builder.Services.AddScoped<userRepositoryv2.UserRepository>();
builder.Services.AddScoped<UserServiceV2>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    // o.ApiVersionReader = ApiVersionReader.Combine(
    //     new QueryStringApiVersionReader("api-version"),
    //     new HeaderApiVersionReader("X-Version"),
    //     new MediaTypeApiVersionReader("ver"));
});
builder.Services.AddVersionedApiExplorer(options =>
{
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddTransient<MongoContext>();
builder.Services.AddDbContext<StoreContext>(options => { 
    options.UseNpgsql(builder.Configuration.GetConnectionString("StoreContext"), b => b.MigrationsAssembly("store.Repository"));
});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddHealthChecks();

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json", 
                description.GroupName.ToUpperInvariant());
        }
    });
}
app.MapHealthChecks("/healthz");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();