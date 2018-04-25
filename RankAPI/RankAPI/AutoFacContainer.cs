using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Autofac;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace RankAPI
{
    public class AutoFacContainer
    {
        public AutoFacContainer()
        {
            var configBuilder = new ConfigurationBuilder();

           // System.Environment.GetEnvironmentVariable("IsDevelopment");
            configBuilder.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.json");
            Configuration = configBuilder.Build();

            ContainerBuilder = new ContainerBuilder();

            //从APPsetting中获取serilogOptions中获取值.
            var serilogOptions = Configuration.GetSection(nameof(SerilogOptions)).Get<SerilogOptions>();

            LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
            loggerConfiguration.MinimumLevel.Debug();
            loggerConfiguration.WriteTo.RollingFile("logs/{Date}.txt", serilogOptions.RollingFileLogEventLevel);
            loggerConfiguration.WriteTo.ColoredConsole(serilogOptions.ConsoleLogEventLevel);

            var logger = loggerConfiguration.CreateLogger();

            ContainerBuilder.RegisterInstance<ILogger>(logger);

            var azureMLRequestOptions = Configuration.GetSection(nameof(AzureMLRequestOptions)).Get<AzureMLRequestOptions>();
            ContainerBuilder.RegisterInstance(azureMLRequestOptions);
        }

        public IConfiguration Configuration { get; set; }

        public ContainerBuilder ContainerBuilder { get; set; }
    }
}
