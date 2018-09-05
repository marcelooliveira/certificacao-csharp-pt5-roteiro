# Markdown file


É possível que um finalizador seja chamado antes do método `Dispose` em um objeto?

Sim. É de responsabilidade do desenvolvedor do aplicativo
se certificar de que o método `Dispose` seja chamado para solicitar 
a liberação  de quaisquer recursos que o objeto
esteja usando. Se isso não
acontecer, e o objeto for excluído da memória,
o método finalize será chamado primeiro. O
"padrão de dispose" foi projetado para garantir que
um objeto libere recursos de uma forma adequada.

Para saber mais:
> ### Padrão de Dispose
> https://docs.microsoft.com/pt-br/dotnet/standard/design-guidelines/dispose-pattern
