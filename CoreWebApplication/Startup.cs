using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace CoreWebApplication
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }
        public IConfigurationRoot Configuration { get; }

        //IHostingEnvironment to configure services by environment.
        //IConfiguration to configure the app during startup.
        public Startup(IHostingEnvironment env)//, IConfiguration config
        {
            HostingEnvironment = env;
            //Configuration = config;
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                                                      .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                                                      .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                                                      .AddEnvironmentVariables()//You can save ConnectionString in system variables and read from it or save it in project propertis in debug section enviroment variables
                                                      .Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        //Can optionally include a ConfigureServices method to configure the app's services.
        //Called by the web host before the Configure method to configure the app's services.
        public void ConfigureServices(IServiceCollection services)
        {
            //Transient: Transient lifetime services are created "each time they are requested".This lifetime works best for lightweight, stateless services.
            //The AddTransient method is used to map abstract types to concrete services that are "instantiated separately for every object that requires it".
            //This is known as the service's lifetime
            //Scoped: Scoped lifetime services "are created once per request".
            //Singleton: Singleton lifetime services "are created the first time they are requested"(or when ConfigureServices is run if
            //you specify an instance there) and then every subsequent request will use the same instance.

            services.AddSingleton(Configuration);//Injected to the Constructor in any class

            services.AddDbContext<CoreContext>();//Injected to the Constructor in any class
            //services.AddScoped<IWorldRepository, WorldRepository>();

            // Add framework services.
            services.AddMvc()
                    //Configure Accept application/xml
                    .AddMvcOptions(mvc => mvc.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
                    //.AddMvcOptions(mvc => mvc.OutputFormatters.Remove(new JsonOutputFormatter()).Add(new XmlDataContractSerializerOutputFormatter());
                    //ToClearAllFormatter
                    //.AddMvcOptions(mvc => mvc.OutputFormatters.Clear());
                    .AddJsonOptions(js =>
                    {//Same as Class Property Name instead of camelCase Property Name
                        if (js.SerializerSettings.ContractResolver != null)
                        {
                            DefaultContractResolver casted = js.SerializerSettings.ContractResolver as DefaultContractResolver;
                            casted.NamingStrategy = null; //Same as Class Property Name instead of camelCase Property Name
                        }
                    });

            services.AddLogging();
        }



        //Must include a Configure method to create the app's request processing pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CoreContext dbContext)
        {


            //How to pipeline works
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello pipeline! {0}", context.Request.Path);
            //    await next();
            //});

            loggerFactory.AddConsole(); //Log To Console
            loggerFactory.AddDebug(); //Log To Output 

            //For Log To File:
            //loggerFactory.AddProvider(new NLogLoggerProvider());
            //add NLog to ASP.NET Core
            //loggerFactory.AddNLog();
            //add NLog.Web
            //app.AddNLogWeb();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStatusCodePages();//Middleware pipeline

            //attribute base for routing!
            app.UseMvc();//Middleware pipeline

            //app.UseMvc(config =>
            //{
            //    config.MapRoute(
            //        name: "Default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "App", action = "Index" },
            //        constraints: new { id = @"\d+" }
            //    );
            //});

            //app.Run((context) =>
            //{
            //    throw new Exception("new exception!");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
