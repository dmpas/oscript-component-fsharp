ПодключитьВнешнююКомпоненту("OsComponentFSharp/bin/Debug/OsComponentFSharp.dll");

МойОбъект = Новый МойКласс;
Сообщить(МойОбъект.МоеСвойствоДляЧтенияТолько);

МойОбъект = Новый МойКласс("456");
МойОбъект.МоеСвойство = "123";
Сообщить(МойОбъект.МоеСвойствоДляЧтенияТолько);
Сообщить(МойОбъект.МоеСвойство);

Нечто = МойОбъект.МойМетод(1, 2);
Сообщить(Нечто);

Нечто = МойОбъект.МойВторойМетод("1", 2);
Сообщить(Нечто);
