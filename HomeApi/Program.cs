
using HomeApi.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HomeApi
{
    public class Program
    {
        


        public static void Main(string[] args)
        {

            var assemly = Assembly.GetAssembly(typeof(MappingProfile));
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("HomeOptions.json");
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Configuration.AddJsonFile("appsettings.Development.json");
            builder.Configuration.AddJsonFile("ScreenApiOptions.json");


            // Add services to the container.
            builder.Services.AddAutoMapper(assemly);
            builder.Services.Configure<ScreenApiOptions>(builder.Configuration);
            builder.Services.Configure<HomeOptions>(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
        }
    }
}
