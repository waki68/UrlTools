using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shortener.BL;
using Shortener.Models;
using Shortener.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener.Root
{
    public class CompositionRoot
    {
        private static readonly ILoggerFactory _dbLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, level => level == LogLevel.Information);
        });

        public static void InjectDependencies(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(opt => opt
                                                    .UseLoggerFactory(_dbLoggerFactory)
                                                    .EnableSensitiveDataLogging(true)
                                                    .UseSqlServer(connectionString));

            services.AddTransient<IUrlService, UrlService>();
            services.AddTransient<IUrlRepository, UrlRepository>();
        }
    }
}
