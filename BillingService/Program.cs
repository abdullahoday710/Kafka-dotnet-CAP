using BillingService.Subscribers;
using DotNetCore.CAP.Messages;
using Microsoft.EntityFrameworkCore;

namespace BillingService
{
    public class Program
    {
        public static void RegisterSubscribers(ref WebApplicationBuilder builder)
        {
            // Register all your kafka subscribers here
            builder.Services.AddTransient<OrderCreateSubscriber>();
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BillingServiceDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BillingServiceDB")));


            // Add services to the container.
            builder.Services.AddCap(x =>
            {
                x.UseInMemoryStorage();
                x.UseKafka(kafka =>
                {
                    kafka.Servers = "localhost:9092";
                });

                x.FailedRetryCount = 3;
                x.FailedThresholdCallback = failed =>
                {
                    Console.WriteLine($"Message failed: {failed.Message.GetId()}");
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterSubscribers(ref builder);

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
