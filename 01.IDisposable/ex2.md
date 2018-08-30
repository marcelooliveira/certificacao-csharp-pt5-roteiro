# Para pensar: mudando de class para struct

Você está desenvolvendo uma aplicação que gerencia posicionamento de veícuos por GPS.

Para isso, existe uma classe que agrega os valores de `Latitude` e `Longitude` da posição global dos veículos.

	
```
public struct PosicaoGPS
{
	public double Latitude;
	public double Longitude;

	public bool EstaNoHemisferioNorte()
	{
		return Latitude > 0;
	}
}
```

Em um certo ponto da aplicação, utiliza uma variável para declarar uma posição de GPS:

``` 
var gpsVeiculo = new PosicaoGPS()
{
	Latitude = 15,
	Longitude = 17
};
```

Depois de um tempo, você então decide trocar a classe `PosicaoGPS` por uma estrutura que contém os mesmos dados:

```	
public class PosicaoGPS
{
	public double Latitude;
	public double Longitude;

	public bool EstaNoHemisferioNorte()
	{
		return Latitude > 0;
	}
}
```	

Com essa alteração, a variável `gpsVeiculo` vai deixar de ser coletada pelo coletor de lixo?

Resposta:
Sim. Os tipos de valor (incluindo `structs`) são normalmente armazenados na pilha (Stack).
Quando um programa sai de um bloco de código, as variáveis daquele bloco que estão na pilha (Stack) são automaticamente removidas.
