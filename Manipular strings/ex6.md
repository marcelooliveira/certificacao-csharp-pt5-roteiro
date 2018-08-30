# Para pensar: strings imutáveis

Se um objeto string é _imutável_, isso significa que não podemos
atribuir a um novo valor a uma variável string depois da sua inicialização?

Resposta:

O conteúdo de um objeto string não pode ser alterado.
Porém, sempre que modificamos o conteúdo de uma variável string, 
na verdade o .NET está _criando um novo objeto_, com uma cópia da string original e com a alteração desejada,
e depois disso a variável string passa a fazer referência (ponteiro) a esse novo objeto. 
O que temos, então, são novas _cópias modificadas_ a cada alteração.
