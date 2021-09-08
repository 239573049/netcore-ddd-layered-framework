using Autofac;
using CSRedis;
using Cx.NetCoreUtils;
using Cx.NetCoreUtils.Common;
using Cx.NetCoreUtils.Extensions;
using Cx.NetCoreUtils.Filters;
using Cx.NetCoreUtils.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using XiaoHu.EntityFrameworkCore;
using XiaoHu.EntityFrameworkCore.Core;
using XiaoHu.EntityFrameworkCore.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using static Cx.NetCoreUtils.Swagger.SwaggerSetup;
using XiaoHu.Uitl.Util;

namespace XiaoHu.Web
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 人口
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        /// <summary>
        /// appsettings文件
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// </summary>
        public IWebHostEnvironment Env { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var csredis = new CSRedisClient(Configuration["ConnectionString:Redis"]);
            RedisHelper.Initialization(csredis);
            services.AddSingleton(new AppSettings(Env.ContentRootPath));
            //根据配置文件选择数据库
            if (Configuration["database"].ToLower() == "mysql") {
                services
                    .AddDbContext<MasterDbContext>(option => option.UseMySql(Configuration["ConnectionString:Default"].MD5Decrypt(),
                    new MySqlServerVersion(new Version(5, 7, 29))));
            }
            else {
                services
                    .AddDbContext<MasterDbContext>(option => option.UseSqlServer(Configuration["ConnectionString:Default"].MD5Decrypt()));
            }
            services
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddTransient(typeof(IRedisUtil),typeof(RedisUtil));
            services
                .AddTransient(typeof(IMasterDbRepositoryBase<,>), typeof(MasterDbRepositoryBase<,>));
            services
                .AddAuthenticationSetup();
            services
                .AddCorsSetup();
            services
                .AddMemoryCache();
            services
                .AddSwaggerSetup("1.0.0.1", "XiaoHu API", "XiaoHu Web API", new Contact { Email = "239573049@qq.com", Name = "xiaohu", Url = new System.Uri("https://github.com/239573049") });
            services
                .AddAutoMapperSetup("XiaoHu.Application", "XiaoHu.Web.Code");
            services
                .AddHttpContext();
            services
                .AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
                o.Filters.Add(typeof(GlobalResponseFilter));
                o.Filters.Add<GlobalModelStateValidationFilter>();
            })
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatString = Constants.DefaultFullDateFormat;
            });
        }

        /// <summary>
        /// 管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="log"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            log.AddLog4Net();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseGlobalBufferMiddleware();
            app.UseCors(Constants.CorsPolicy);
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0.0.1/swagger.json", "XiaoHu API V1");
                c.DocExpansion(DocExpansion.None);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var basePath = ApplicationEnvironment.ApplicationBasePath;

            var servicesDllFile = Path.Combine(basePath, "XiaoHu.Application.dll");
            var repositoryDllFile = Path.Combine(basePath, "XiaoHu.EntityFrameworkCore.dll");

            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            containerBuilder.RegisterAssemblyTypes(assemblysServices)
                .Where(x => x.FullName.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerDependency();//引用Autofac.Extras.DynamicProxy;

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            containerBuilder.RegisterAssemblyTypes(assemblysRepository)
                .Where(x => x.FullName.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerDependency();
        }
    }
}