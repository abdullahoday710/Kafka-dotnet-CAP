
using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.EntityFrameworkCore;
using System;

namespace KafkaCAPPlayground
{
    public class Program
    {
        public class SampleSubscriber : ICapSubscribe
        {
            [CapSubscribe("sample.message")]
            public void HandleMessage(dynamic message)
            {
                Console.WriteLine($"Received: {message}");
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("cap"));

            // Configure CAP with Kafka
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
            builder.Services.AddTransient<SampleSubscriber>();

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
