namespace EmptyWebApplication

open Microsoft.AspNetCore.Builder;
open Microsoft.AspNetCore.Hosting;
open Microsoft.AspNetCore.Http;
open Microsoft.Extensions.DependencyInjection;
open Microsoft.Extensions.Logging;

type Startup() =

    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member this.ConfigureService(services:IServiceCollection) =
        ()
    

    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure (app:IApplicationBuilder, env:IHostingEnvironment, ILoggerFactory loggerFactory) =
        loggerFactory.AddConsole()
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage();

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
