Você está desenvolvendo um aplicativo em C#.
O aplicativo exibirá a temperatura e a hora em que a temperatura foi gravado.

Você tem o seguinte método (os números de linha são incluídos apenas para referência):

```
01 public void MostraTemperatura(DataTime data, double temp)
02 {
03 	    string saida;
04 
05 	    string lblMensagem = saida;
06 }

```

Você precisa garantir que a mensagem exibida no objeto `lblMensagem` mostre a hora
formatada de acordo com os seguintes requisitos:

A hora deve ser formatada como hora:minuto AM/PM, por exemplo, 2:00 PM.
A data deve ser formatada como mês/dia/ano, por exemplo, 21/04/2019.
A temperatura deve ser formatada para ter duas casas decimais, por exemplo, "23,45".

Qual código você deve inserir na linha 04? (Para responder, selecione as opções apropriadas na área de resposta.)

```
saida = string.Format(
"A temperatura às [{0:t}|{1:t}|{0:hh:mm}|{1:hh:mm}]
 do dia 
 é: [{0:d}|{1:d}|{0:dd/mm/yy}|{1:mm/dd/yy}] celsius." 
[{0}|{1}|{0:N2}|{1:N2}]", date, temp)
```

Resposta: 

```
saida = string.Format(
"A temperatura às [{0:t}] do dia {0:dd/mm/yy} é: {1:N2} celsius.", date, temp)
```

