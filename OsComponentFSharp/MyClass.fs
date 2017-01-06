namespace OsComponentFSharp

open ScriptEngine.Machine.Contexts
open ScriptEngine.Machine

[<ContextClass("МойКласс", "MyClass")>]
type MyClass(initialValue) = 
    inherit AutoContext<MyClass>()

    [<ContextProperty("МоеСвойствоДляЧтенияТолько")>]
    member val MyReadOnlyProperty = initialValue

    [<ContextProperty("МоеСвойство")>]
    member val MyProperty = "" with get,set

    // a и b - числа
    [<ContextMethod("МойМетод")>]
    member this.MyMethod a b = a + b

    [<ContextMethod("МойВторойМетод")>]
    member this.MySecondMethod (a:IValue, b:IValue) = ValueFactory.Add(a, b)

    [<ScriptConstructor>]
    static member DefaultConstructor () = MyClass("321") :> IRuntimeContextInstance

    [<ScriptConstructor>]
    static member ConstructorWithValue (data:IValue) = MyClass(data.AsString()) :> IRuntimeContextInstance
