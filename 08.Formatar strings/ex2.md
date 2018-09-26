Você está desenvolvendo um jogo que permite aos jogadores coletar de 0 a 1000 moedas. Você está
criando um método que será usado no jogo. O método inclui o seguinte código.
(Os números de linha são incluídos apenas para referência.)

```
01 public string FormatarMoedas(string nome, int moedas)
02 {
03
04 }
```

O método deve atender aos seguintes requisitos:
* Devolve uma string que inclui o nome do jogador e o número de moedas.
* Exibe o número de moedas sem zeros à esquerda se o número for 1 ou maior.
* Exibe o número de moedas como um único 0 se o número for 0.

Você precisa garantir que o método atenda aos requisitos.

Qual segmento de código você deve inserir na linha 03?


```csharp
return String.Format("Jogador {0}, coletou {1} moedas", nome, moedas.ToString("###0"));
```
Correto.
* O índice "0" indica o primeiro argumento (nome do jogador)
* O índice "1" indica o segundo argumento (moedas)
* No formato "###0", o especificador "#" substitui o símbolo "#" pelo dígito correspondente, se houver um presente. Caso contrário, nenhum dígito aparecerá na cadeia de caracteres de resultado.
* No formato "###0", o especificador "0" indica que, no mínimo, um dígito aparecerá nessa posição.

```csharp
return String.Format("Jogador {0} coletou {1:000#} moedas.", nome, moedas);
```
Incorreto. Se o número de moedas for menor que 100, aparecerá com zeros à esquerda. Exemplo:
```
Jogador João, coletou 013 moedas
```

```csharp
return String.Format("Jogador {nome} coletou {moedas.ToString('000')} moedas");
```
Incorreto. O especificador `{nome}` é inválido para o método `string.Format()`.
```
Jogador João, coletou 013 moedas
```

```csharp
return String.Format("Jogador {1} coletou {2:D3} moedas.", nome, moedas);
```
Incorreto. 
* Os marcadores `{1}` `{2}` correspondem ao segundo e terceiro argumentos, respectivamente.
* O especificador `D3` força a exibição de zeros à esquerda.
