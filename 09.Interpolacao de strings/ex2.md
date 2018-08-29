# Interpolando strings

Observe o seguinte método override `ToString()`:

```
public override string ToString()
{
    return string.Format("Numero:{0}, Saldo:{1}, Titular:{2}",
                            , this.Numero, this.Saldo, this.Titular.Nome);
}
```

Utilize alguns recursos que aprendemos no C# 6 para reescrever o mesmo código usando **interpolação de strings**:

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-   Alternativa correta

    ```
    public override string ToString()
    {
        return $"Numero:{this.Numero}, Saldo:{this.Saldo}, Titular:{this.Titular.Nome}";
    }
    ```

    Isso mesmo! A sintaxe de interpolação de strings foi aplicada corretamente.

    -   Alternativa correta

    ```
    public override string ToString()
    {
        return $"Numero:{0:this.Numero}, Saldo:{1:this.Saldo}, Titular:{2:this.Titular.Nome}";
    }
    ```

    Ops! Quando utilizamos a sintaxe de interpolação de strings, não podemos prefixar as expressões entre chaves com índices.

    -   Alternativa correta

    ```
    public override string ToString()
    {
        return $"Numero:[this.Numero], Saldo:[this.Saldo], Titular:[this.Titular.Nome]";
    }
    ```

    Ops! A sintaxe de interpolação de strings exige o uso de chaves, e não colchetes, para posicionar os valores a serem inseridos no texto.

    -   Alternativa correta

    ```
    public override string ToString()
    {
        return $"Numero:{this.Numero:0}, Saldo:{this.Saldo:1}, Titular:{this.Titular.Nome:2}";
    }
    ```

    Ops! Quando utilizamos a sintaxe de interpolação de strings, não podemos utilizar índices após as expressões entre chaves.