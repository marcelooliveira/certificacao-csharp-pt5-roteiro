# Para pensar: um array de inteiros e o coletor de lixo

Você está desenvolvendo uma aplicação que, num dado momento, precisa montar um calendário de eventos. Para isso, você
cria o método `GeraCalendario()` abaixo:

```	
public void GeraCalendario()
{
	// ...
	// ... algum código 
	// ...
	int[] diasDeCadaMes = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
	// ...
	// ... algum código 
	// ...
}
```	

Depois que o programa termina de executar o método `GeraCalendario()`, a variável `diasDeCadaMes` 
será coletada pelo coletor de lixo?

Resposta:
Arrays de tipos de valor são implementados como objetos.
Assim, a variável `diasDeCadaMes` será gerenciada como um objeto que contém:

1. 12 inteiros e
2. uma referência de array para esse objeto.

Isso significa que esse array `diasDeCadaMes` será implementado na pilha e sua remoção da memória precisará do coletor de lixo.
