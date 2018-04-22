using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MvcAngular.Generator;
using Microsoft.Extensions.Logging;

namespace RankAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (AngularGenerator.ShouldRunMvc(args))
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
