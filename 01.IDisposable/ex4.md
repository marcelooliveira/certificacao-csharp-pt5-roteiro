# A pilha e o coletor de lixo

Uma certa aplicação declara diversas variáveis do tipo `int`, `bool` e `double`.
Conforme a aplicação executa, seus métodos chamam outros métodos secundários, que por sua vez chamam ainda outros métodos da aplicação.
Com isso, a pilha cresce de tamanho. Conforme a aplicação roda, o programa vai saindo dos blocos da aplicação e diversas variáveis deixam de ser necessárias.

Pense e responda: o coletor de lixo também coleta esse lixo da pilha?


Reposta:

Não. A pilha cresce e se "contrai" conforme o programa é executado: Esse "lixo" gerado pela pilha é destruído assim que cada bloco termina de ser executado.