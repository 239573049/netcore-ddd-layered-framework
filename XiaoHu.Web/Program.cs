using Autofac.Extensions.DependencyInjection;
using Cx.NetCoreUtils.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace XiaoHu.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(kestrelOptions =>
                    {
                        kestrelOptions.Limits.MaxRequestBodySize = AppSettings.GetValue<int>("FileServer:SingleFileMaxSize") * 1024 * 1024;
                        kestrelOptions.ConfigureHttpsDefaults(s => s.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13);
                    });
                    webBuilder.UseStartup<Startup>();
                    if (args.Length > 0) {
                        webBuilder.UseUrls(args[0]);
                    }
                });
    }
}
