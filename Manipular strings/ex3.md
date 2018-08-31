Você está desenvolvendo um aplicativo que converterá dados em vários formatos de saída. 
A aplicação inclui o seguinte código.
(Os números de linha são incluídos apenas para referência.)

```
01 public class Formatador : IFormatadorDeSaida<string>
02 {
03     readonly Func<int, char> sufixo = col => col % 2 == 0 ? '\n' : '\t';
04     public string GetSaida(IEnumerator<string> iterador, int tamanhoRegistro)
05     {
06 
07     }
08 }
```

Você está desenvolvendo um segmento que irá produzir strings delimitadas por tabs. Todas as rotinas de saída
implementam a seguinte interface:

```
public interface IFormatadorDeSaida<T>
{
    string GetSaida(IEnumerator<T> iterador, int tamanhoRegistro);
}
```

Você precisa minimizar o tempo de execução do método `GetSaida()`. Qual dos seguintes segmentos de código você deveria inserir na linha 06?

A.
```
string saida = null; 
for (int i = 1; iterador.MoveNext(); i++) 
{ 
    saida = string.Concat(saida, iterador.Current, suffix(i)); 
} 
return saida;
```

B.
```
var saida = new StringBuilder(); 
for (int i = 1; iterador.MoveNext(); i++) 
{ 
    saida.Append(iterador.Current); 
    saida.Append(suffix(i)); 
} 
return saida.ToString();
```

C.
```
string saida = null; 
for (int i = 1; iterador.MoveNext(); i++) 
{ 
    saida = saida + iterador.Current + suffix(i); 
} 
return saida;
```

D.
```
string saida = null; 
for (int i = 1; iterador.MoveNext(); i++) 
{ 
    saida += iterador.Current + suffix(i); 
} 
return saida;
```

> B. (CORRETA)

Sempre que você concatena um objeto string ocorre uma alocação de memória, pois um novo objeto é criado na concatenação.

A classe `StringBuilder` possui um buffer interno que vai concatenando realmente os dados, sem criar novos objetos.
Quando o espaço desse buffer se esgota, um novo buffer maior é alocado, e então os dados do buffer antigo são copiados para o novo.

**Portanto...**

Use a classe String se você estiver concatenando um número pequeno e fixo de objetos String.
Dependendo da situação, o compilador pode otimizar o processo, juntando as operações de concatenação individuais em uma única operação.

Use um `StringBuilder` se você estiver concatenando um número indefinido de strings;
por exemplo, se você estiver usando um loop para concatenar strings lidas a partir de um arquivo.
