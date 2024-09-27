
using MongoDB.Driver;
using sharurl_api.Repositories;
using dotenv.net;
using UrlGeneratorTest;
using sharurl_api.Shorteners;
using sharurl_api.Middlewares;

namespace sharurl_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            DotEnv.Load();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            string dbUser = Environment.GetEnvironmentVariable("DB_USER")!;
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST")!;
            string dbPort = Environment.GetEnvironmentVariable("DB_PORT")!;

            var mongoConnectionString = $"mongodb://{dbUser}:{dbPassword}@{dbHost}:{dbPort}";

            builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));

            builder.Services.AddSingleton<IUrlInfoRepository,MongoRepositoryImpl>();
            builder.Services.AddSingleton<ICodeGenerator, RandomShortenerImpl>();
            builder.Services.AddScoped<UrlShortenerService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionHandlerMiddelware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
