# Mão na Massa

**1)** Crie a classe `LeitorDeArquivo` com o código abaixo. Certifique-se de adicionar no cabeçalho do arquivo desta classe a diretiva `using System.IO;` pois usaremos classes deste namespace:

```
public class LeitorDeArquivo
{
    public string Arquivo { get; }

    public LeitorDeArquivo(string arquivo)
    {
        Arquivo = arquivo;

        // throw new FileNotFoundException();
        Console.WriteLine("Abrindo arquivo: " + arquivo);
    }

    public string LerProximaLinha()
    {
        Console.WriteLine("Lendo linha. . .");

        // throw new IOException();
        return "Linha do arquivo";
    }

    public void Fechar()
    {
        Console.WriteLine("Fechando arquivo.");
    }
}
```

**2)** Escreva o código de teste para esta classe:

```
private static void CarregarContas()
{
    LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");

    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();

    leitor.Fechar();
}
```

Executando o método `CarregarContas()`, você encontrará a saída:

```
Abrindo arquivo: contas.txt
Lendo linha. . .
Lendo linha. . .
Lendo linha. . .
Fechando arquivo.
```

**3)** Contudo, problemas acontecem. Não é sempre que conseguiremos ler o arquivo. Para simular isto, vamos lançar uma exceção do tipo `IOException` em `LerProximaLinha`:

```
public string LerProximaLinha()
{
    Console.WriteLine("Lendo linha. . .");

    throw new IOException();
    return "Linha do arquivo";
}
```

**4)** Com esta alteração feita, será necessário tratar a exceção em `CarregarContas`, pois é fundamental chamar o método `Fechar`:

```
LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");
try
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.Fechar();
}
catch(IOException e)
{
    leitor.Fechar();
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
```

**5)** Podemos evitar esta duplicação do código `leitor.Fechar()`, onde temos um código que **deve ser executado ao fim do try e ao fim do catch**, quando houver uma exceção, podemos usar o `finally`:

```
LeitorDeArquivo leitor =  new LeitorDeArquivo("contas.txt");
try
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
catch(IOException e)
{
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
finally
{
    leitor.Fechar();
}
```

**6)** Existem outras exceções em potencial na leitura de arquivos, como quando o arquivo não é encontrado. Vamos simular isto através da alteração no construtor da classe `LeitorDeArquivo`:

```
public LeitorDeArquivo(string arquivo)
{
    Arquivo = arquivo;

    throw new FileNotFoundException();
    Console.WriteLine("Abrindo arquivo: " + arquivo);
}
```

**7)** Agora será necessário mover a instanciação desta classe para dentro do bloco `try`:

```
LeitorDeArquivo leitor = null;
try
{
    leitor = new LeitorDeArquivo("contas.txt");
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
catch(IOException e)
{
    Console.WriteLine("Exceção do tipo IOException capturada e tratada.");
}
finally
{
    leitor.Fechar();
}
```

**8)** Mas, executar este código nos trará problemas. A tentativa de atribuição na variável `leitor` irá gerar uma exceção e, no bloco finally, encontraremos uma referência nula. Devemos verificar isto:

```
finally
{
    if(leitor != null)
    {
        leitor.Fechar();
    }
}
```

**9)** Nada legal esse código, né? Como a única função de nosso try/catch/finally é ter certeza de que o método `Fechar` de nosso recurso foi invocado, podemos trocar o que escrevemos com o bloco `using`:

```
using(LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
{
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
    leitor.LerProximaLinha();
}
```

**10)** O bloco `using` é um açúcar sintático para nosso código escrito no try/finally. Mas, o bloco `using` não conhece o método `Fechar`, apenas o método `Dispose` da interface `IDisposable`. Por isto, vamos alterar a classe `LeitorDeArquivo` e implementar esta interface:

```
public class LeitorDeArquivo : IDisposable
{
    public string Arquivo { get; }

    public LeitorDeArquivo(string arquivo)
    {
        Arquivo = arquivo;

        // throw new FileNotFoundException();
        Console.WriteLine("Abrindo arquivo: " + arquivo);
    }

    public string LerProximaLinha()
    {
        Console.WriteLine("Lendo linha. . .");

        // throw new IOException();
        return "Linha do arquivo";
    }

    public void Fechar()
    {
        Console.WriteLine("Fechando arquivo.");
    }
}
```

**11)** Troque o nome do método `Fechar` para `Dispose`:

```
public void Fechar()
{
    Console.WriteLine("Fechando arquivo.");
}
```