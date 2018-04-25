using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcAngular.Generator;

namespace RankAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //固定模式:给angular生成代码,if为检查是否有要生成代码的
            if (AngularGenerator.ShouldRunMvc(args))
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
             //   .UseUrls("http://*;8678")Linux系统下使用.
                .Build();
    }
}
