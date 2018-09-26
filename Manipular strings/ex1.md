Você está desenvolvendo um aplicativo usando C#. A aplicação irá produzir
a string de texto "Primeira linha" seguido da string "Segunda linha".
Você precisa garantir que uma linha vazia separe as strings de texto.

Quais quatro segmentos de código você deve usar em seqüência? (Para responder, mova o apropriado
segmentos de código para a área de resposta e organizá-los na ordem correta.

```
sb.Append("\1");
```
```
var sb = new StringBuilder();
```
```
sb.Append("Primeira Linha");
```
```
sb.Append("\t");
```
```
sb.AppendLine();
```
```
sb.Append(String.Empty);
```
```
sb.Append("Segunda Linha");
```

Resposta:

> Lacuna 1:
> 
```
var sb = new StringBuilder();
```
>
> Primeiro criamos a variável


> Lacuna 2:
```
sb.Append("Primeira Linha");
> 
```
>
>Criamos a primeira lina de texto


> Lacuna 3:
```
sb.AppendLine();
> 
```
>
> Adicionamos uma linha em branco.
> O método StringBuilder.AppendLine acrescenta o terminador de linha padrão ao final
> do objeto StringBuilder.



> Lacuna 4:
```
sb.Append("Segunda Linha");
> 
```
> E no final adicionamos a segunda linha.