namespace WebApplicationBasic.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc


type HomeController() = 
    inherit Controller()

    member this.Index() = View()

    member this.About() =
        this.ViewData.["Message"] <- "Your application description page."
        View()

    member this.Contact() =
        this.ViewData.["Message"] <- "Your contact page.";
        View();

    member this.Error() = View()
