
using FreeCourse.Services.Catalog.Mapping;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Settings;
using Microsoft.Extensions.Options;

namespace FreeCourse.Services.Catalog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(GeneralMapping));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICourseService, CourseService>();


        var test = builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

        builder.Services.AddSingleton<IDatabaseSettings>(sp =>
        {
            return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
