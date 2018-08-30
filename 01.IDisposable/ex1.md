Você está modificando um aplicativo existente que gerencia a folha de pagamento de funcionários.
A aplicação inclui uma classe chamada `ProcessadorFolhaDePagamento`.

A classe `ProcessadorFolhaDePagamento` se conecta a um banco de dados de 
folha de pagamento e processa lotes de cheques uma vez por semana.

Você precisa garantir que a classe `ProcessadorFolhaDePagamento` suporta iteração e 
libera as conexões de banco de dados após o processamento em lote ser concluído.

Quais são as duas interfaces que você deve implementar? (Cada resposta correta apresenta parte do
solução completa. Escolha duas.)


A.
IEquatable

B.
IEnumerable

C.
IDisposable

D.
IComparable

> Explicação:
> B: IEnumerable
> C: IDisposable
Exposes an enumerator, which supports a simple iteration over a non-generic collection.\
Defines a method to release allocated resources.\
The primary use of this interface is to release unmanaged resources.

`IEnumerable` expõe um enumerador, que suporta uma iteração simples sobre uma coleção não genérica.
`IDisposable` define um método para liberar recursos alocados.
O principal uso dessa interface é liberar recursos não gerenciados, tais como conexões com bancos de dados.