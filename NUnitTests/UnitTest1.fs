module NUnitTests

open OneScript.StandardLibrary.Collections
open ScriptEngine.HostedScript.Extensions
open ScriptEngine.Hosting
open OneScript.Types

open NUnit.Framework
open OsComponentFSharp

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    
    let Engine = DefaultEngineBuilder.Create().SetupConfiguration( ignore ).SetDefaultOptions().UseImports().UseNativeRuntime().UseFileSystemLibraries().Build()
    
    Engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof<ArrayImpl>))
    Engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof<MyClass>))

    let context = TypeActivationContext(CurrentProcess = Engine.NewProcess())
    let instance = MyClass(context, "123")
    Assert.AreEqual(instance.MyReadOnlyProperty, "123")
    let myMethodResult = instance.MyMethod 1 2
    Assert.AreEqual(myMethodResult, 3)
