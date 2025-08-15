namespace OsComponentFSharp

open ScriptEngine.Machine.Contexts
open ScriptEngine.Machine
open OneScript.Contexts
open OneScript.Types

/// Демонстрационный класс
[<ContextClass("МойКласс", "MyClass")>]
type MyClass(context: TypeActivationContext, initialValue) = 
    inherit AutoContext<MyClass>()

    /// Свойство, только для чтения
    [<ContextProperty("МоеСвойствоДляЧтенияТолько")>]
    member val MyReadOnlyProperty = initialValue

    /// Обычное свойство
    [<ContextProperty("МоеСвойство")>]
    member val MyProperty = "" with get,set

    // a и b - числа
    [<ContextMethod("МойМетод")>]
    member this.MyMethod a b = a + b

    /// Метод складывания
    [<ContextMethod("МойВторойМетод")>]
    member this.MySecondMethod (a:IValue, b:IValue) = ValueFactory.Add(a, b, context.CurrentProcess)

    static member StringHelper(context: TypeActivationContext, data: IValue) = data.AsString(context.CurrentProcess)

    /// Конструтор по-умолчанию
    [<ScriptConstructor>]
    static member DefaultConstructor (context: TypeActivationContext) = MyClass(context, "321") :> IRuntimeContextInstance

    /// Конструктор со значением по-умолчнию
    [<ScriptConstructor>]
    static member ConstructorWithValue context data =
        let dataInput:IValue = data // таков вывод типов в F#
        MyClass(context, data.AsString(context.CurrentProcess))
