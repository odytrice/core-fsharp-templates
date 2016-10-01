namespace WebApplicationBasic

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration


type Program() =

    static member Main (args:string[]) =
    
        var config = ConfigurationBuilder()
                        .AddCommandLine(args)
                        .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                        .Build()

        var host = WebHostBuilder()
                        .UseConfiguration(config)
                        .UseKestrel()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .UseStartup<Startup>()
                        .Build()

        host.Run() |> ignore