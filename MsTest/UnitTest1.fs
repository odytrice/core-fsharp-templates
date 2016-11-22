namespace UnitTest1

open System;
open Microsoft.VisualStudio.TestTools.UnitTesting;
open System.Threading.Tasks;


// see example explanation on xUnit.net website:
// https://xunit.github.io/docs/getting-started-dotnet-core.html
[<TestClass>]
type UnitTest1() =

    let add x y = x + y

    [<TestMethod>]
    member this.PassingTest () =
        Assert.Equals(4, (add 2 2));

    [<TestMethod>]
    member this.FailingTest () = 
        Assert.Equals(5, (add 2 2));
