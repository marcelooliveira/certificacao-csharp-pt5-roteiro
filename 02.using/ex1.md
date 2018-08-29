# Açúcar sintático using

Nesta aula, enfrentamos alguns desafios para lidar com a leitura de um arquivo e seu fechamento. Escrevemos bastante código para nos certificar de que o método `Fechar`será sempre invocado. Nestas situações, podemos usar o bloco `using`.

Sobre o bloco `using`, marque as alternativas corretas:

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-   Alternativa incorreta

    [ ]

    Para usarmos o bloco `using` com o código `using (RecursoDoSistema recurso = new RecursoDoSistema()) { ... }`, é necessário que o RecursoDoSistema tenha o método Dispose, sem implementar a interfaces.

    Quase lá! O método `Dispose` é necessário, mas é necessário implementar a interface `IDisposable`.

    -   Alternativa incorreta

    [ ]

    O `using` é um açúcar sintático para o código:

    ```
    RecursoDoSistema recurso = new RecursoDoSistema();
    try
    {
        recurso.Usar();
    }
    finally
    {
        recurso.Dispose();
    }
    ```

    Quase lá! Mas, o bloco using verifica se a referência é nula e se ocorrem exceções na instanciação do objeto de recurso.

    -   Alternativa incorreta

    [ ]

    Para usarmos o bloco `using` com o código `using (RecursoDoSistema recurso = new RecursoDoSistema()) { ... }`, é necessário que o RecursoDoSistema implemente a interface IDisposable.

    Correta! Desta forma, temos a segurança de que o método `Dispose` existe.

    -   Alternativa incorreta

    [ ]

    O `using` é um açúcar sintático para o código:

    ```
    RecursoDoSistema recurso = null;
    try
    {
        recurso = new RecursoDoSistema();
        recurso.Usar();
    }
    finally
    {
        if(recurso != null)
        {
            recurso.Dispose();
        }
    }
    ```

    Correta! Com o bloco `using`, a instanciação do objeto acontece em um bloco try e no bloco finally o método `Dispose` é invocado após a verificação de referência nula.

