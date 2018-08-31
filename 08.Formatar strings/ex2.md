Você está desenvolvendo um jogo que permite aos jogadores coletar de 0 a 1000 moedas. Você está
criando um método que será usado no jogo. O método inclui o seguinte código.
(Os números de linha são incluídos apenas para referência.)

```
01 public string Formatmoedas(string nome, int moedas)
02 {
03
04 }
```

O método deve atender aos seguintes requisitos:
Devolve uma string que inclui o nome do jogador e o número de moedas.
Exibe o número de moedas sem zeros à esquerda se o número for 1 ou maior.
Exibe o número de moedas como um único 0 se o número for 0.
Você precisa garantir que o método atenda aos requisitos.

Qual segmento de código você deve inserir na linha 03?


```
A return String.Format("Jogador {0}, coletou {1} moedas", nome, moedas.ToString("###0"));
B. return String.Format("Jogador {0} coletou {1:000#} moedas.", nome, moedas);
C. return String.Format("Jogador {nome} coletou {moedas.ToString('000')} moedas");
D. return String.Format("Jogador {1} coletou {2:D3} moedas.", nome, moedas);
5. 
```

A.
Opção A

B.
Opção B

C.
Opção C

D.
Opção D

Resposta: Opção A