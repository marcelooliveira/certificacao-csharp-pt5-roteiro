# Interpolação de strings e expressões nameof

Observe o código abaixo:

```
string valor1 = "Alura";
string valor2 = "Cursos";
Console.WriteLine($"resultado: {valor1} {nameof(valor2)}");
```

O que acontece quando esse código é executado? Escolha a melhor resposta:

É impresso no console:

```
resultado: valor1 valor2
```

Ops! O símbolo **$** (dólar) permite a **interpolação da string**. A expressão `{valor1}` é resolvida como "Alura", e não como "valor1".

É impresso no console:

```
resultado: Alura Cursos
```

Ops! O operador **nameof** obtém o nome do símbolo **valor2** ("valor2"), e não o seu valor.

É impresso no console:

```
resultado: Alura valor2
```

Isso mesmo! O símbolo **$** (dólar) permite a **interpolação da string**. Já o operador **nameof**obtém o nome do símbolo **valor2** ("valor2").

É lançada uma exceção: ***`erro CS0103: O nome 'nameof' não existe no contexto atual`***, pois a expressão `nameof` não é um nome de variável.

Ops! Não só variáveis, mas qualquer expressão C# é permitida dentro das chaves numa interpolação de strings. O operador **nameof** irá obter o nome do símbolo **valor2**("valor2").