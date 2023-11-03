using System;
using System.Net;
using System.Threading;
using KowWhoisApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace KowWhoisApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var webHost = CreateHostBuilder(args).Build();
			Migrate(webHost);
			webHost.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog((context, services, configuration) => configuration
					.ReadFrom.Configuration(context.Configuration)
					.ReadFrom.Services(services)
					.Enrich.FromLogContext()
					.WriteTo.Console())
				.ConfigureWebHostDefaults(webBuilder =>
				{
					// Make sure it listens to 127.0.0.1.
					// (Docker does not like IPv6 that much.)
					webBuilder.ConfigureKestrel(serverOptions =>
						serverOptions.Listen(IPAddress.Any, 5000));

					webBuilder.UseStartup<Startup>();
				});

		private static void Migrate(IHost webHost)
		{
			using (var scope = webHost.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var db = services.GetRequiredService<WhoisContext>();
					db.Database.Migrate();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occured while migrating the datbase.");
					Thread.Sleep(TimeSpan.FromSeconds(10));
					Migrate(webHost);
				}
			}
		}
	}
}
