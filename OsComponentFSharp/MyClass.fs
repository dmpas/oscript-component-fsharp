namespace OsComponentFSharp

open ScriptEngine.Machine.Contexts
open ScriptEngine.Machine
open OneScript.Contexts
open OneScript.Types

[<ContextClass("МойКласс", "MyClass")>]
type MyClass(context: TypeActivationContext, initialValue) = 
    inherit AutoContext<MyClass>()

    [<ContextProperty("МоеСвойствоДляЧтенияТолько")>]
    member val MyReadOnlyProperty = initialValue

    [<ContextProperty("МоеСвойство")>]
    member val MyProperty = "" with get,set

    // a и b - числа
    [<ContextMethod("МойМетод")>]
    member this.MyMethod a b = a + b

    [<ContextMethod("МойВторойМетод")>]
    member this.MySecondMethod (a:IValue, b:IValue) = ValueFactory.Add(a, b, context.CurrentProcess)

    static member StringHelper(context: TypeActivationContext, data: IValue) = data.AsString(context.CurrentProcess)

    [<ScriptConstructor>]
    static member DefaultConstructor (context: TypeActivationContext) = MyClass(context, "321") :> IRuntimeContextInstance

    [<ScriptConstructor>]
    static member ConstructorWithValue context data =
        let dataInput:IValue = data // таков вывод типов в F#
        MyClass(context, data.AsString(context.CurrentProcess))
