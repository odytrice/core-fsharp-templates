namespace WebApplicationBasic

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging


type Startup(env: IHostingEnvironment) =
    
    let builder = ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile((sprintf "appsettings.%s.json",env.Environment), true)
                    .AddEnvironmentVariables();

    let Configuration = builder.Build();
    

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddMvc();


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app:IApplicationBuilder, env:IHostingEnvironment,loggerFactory: ILoggerFactory) =
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();

        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
        else
            app.UseExceptionHandler("/Home/Error");

        app.UseStaticFiles();

        app.UseMvc(fun routes -> routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}"))