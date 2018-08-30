# Como implementar um método Dispose

https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

Você implementa um método [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) para liberar recursos não gerenciados usados pelo seu aplicativo. O coletor de lixo .NET não alocar nem libera memória não gerenciada.

O padrão para o descarte um objeto, conhecido como [padrão Dispose](https://docs.microsoft.com/pt-br/dotnet/standard/design-guidelines/dispose-pattern), impõe ordem no tempo de vida de um objeto. O padrão de descarte é usado somente para os objetos que acessam recursos não gerenciados, como identificadores de arquivo e pipe, identificadores de Registro, identificadores de espera ou ponteiros para blocos de memória não gerenciada. Isso ocorre porque o coletor de lixo é muito eficiente para recuperar objetos gerenciados não usados, mas não é capaz de recuperar objetos não gerenciados.

O padrão de descarte tem duas variações:

-   Você envolve cada recurso não gerenciado usado por um tipo em um identificador seguro (ou seja, em uma classe derivada de [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle)). Nesse caso, você implementa a interface [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable) e um método `Dispose(Boolean)` adicional. Essa é a variação recomendada e não requer a substituição do método [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize).

    Observação

    O namespace [Microsoft.Win32.SafeHandles](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles) fornece um conjunto de classes derivadas de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle), que são listadas na seção [Usando identificadores seguros](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#SafeHandles). Se não conseguir encontrar uma classe adequada para liberar seu recurso não gerenciado, você poderá implementar sua própria subclasse de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle).

-   Você implementa a interface [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable) e um método `Dispose(Boolean)` adicional, além de substituir o método [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize). Você deve substituir [Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize) para garantir que os recursos não gerenciados sejam descartados se sua implementação de [IDisposable.Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) não for chamada por um consumidor do seu tipo. Se você usar a técnica recomendada discutida no item anterior, a classe [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) fará isso em seu nome.

Para ajudar a garantir que os recursos sejam sempre limpos corretamente, um método [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) deve poder ser chamado várias vezes sem gerar uma exceção.

O exemplo de código fornecido para o método [GC.KeepAlive](https://docs.microsoft.com/pt-br/dotnet/api/system.gc.keepalive) mostra a agressividade com a qual uma coleta de lixo pode fazer com que um finalizador seja executado enquanto um membro do objeto recuperado ainda está em execução. É uma boa ideia chamar o método [KeepAlive](https://docs.microsoft.com/pt-br/dotnet/api/system.gc.keepalive) no final de um método [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) longo.

Dispose() e Dispose(Booliano)[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#dispose-and-disposeboolean)
----------------------------------------------------------------------------------------------------------------------------------------------------

A interface [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable) requer a implementação de um único método sem parâmetros, [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose). No entanto, o padrão de descarte requer que dois métodos `Dispose` sejam implementados:

-   Uma implementação pública não virtual (`NonInheritable` no Visual Basic) de [IDisposable.Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) que não possua parâmetros.

-   Um método `Overridable` virtual protegido (`Dispose` no Visual Basic) cuja assinatura é:

    C#Copiar

    ```
    protected virtual void Dispose(bool disposing)

    ```

### A sobrecarga Dispose()[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#the-dispose-overload)

Como o método público, não virtual (`NonInheritable` no Visual Basic) e sem parâmetro `Dispose` é chamado por um consumidor do tipo, sua finalidade é liberar recursos não gerenciados e indicar que o finalizador, se houver um, não precisa ser executado. Por isso, ele tem uma implementação padrão:

C#Copiar

```
public void Dispose()
{
   // Dispose of unmanaged resources.
   Dispose(true);
   // Suppress finalization.
   GC.SuppressFinalize(this);
}

```

O método `Dispose` executa toda a limpeza do objeto, de modo que o coletor de lixo não precisa mais chamar a substituição dos objetos [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize). Assim, a chamada para o método [SuppressFinalize](https://docs.microsoft.com/pt-br/dotnet/api/system.gc.suppressfinalize) impede que o coletor de lixo execute o finalizador. Se o tipo não possuir um finalizador, a chamada para [GC.SuppressFinalize](https://docs.microsoft.com/pt-br/dotnet/api/system.gc.suppressfinalize) não terá efeito. Observe que o trabalho real de liberar recursos não gerenciado é executado pela segunda sobrecarga do método `Dispose`.

### A sobrecarga Dispose(Boolean)[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#the-disposeboolean-overload)

Na segunda sobrecarga, o parâmetro *disposing* é um [Boolean](https://docs.microsoft.com/pt-br/dotnet/api/system.boolean) que indica se a chamada do método é proveniente de um método [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) (seu valor é `true`) ou de um finalizador (seu valor é `false`).

O corpo do método consiste em dois blocos de código:

-   Um bloco que libera recursos não gerenciados. Este bloco é executado independentemente do valor do parâmetro `disposing`.

-   Um bloco condicional que libera recursos gerenciados. Este bloco será executado se o valor de `disposing` for `true`. Os recursos gerenciados que ele libera podem incluir:

    Objetos gerenciados que implementam [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable). O bloco condicional pode ser usado para chamar sua implementação de [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose). Se você usou um indicador seguro para encapsular o recurso não gerenciado, é necessário chamar a implementação de [SafeHandle.Dispose(Boolean)](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle.dispose#System_Runtime_InteropServices_SafeHandle_Dispose_System_Boolean_) aqui.

    Objetos gerenciados que consomem muita memória ou consomem recursos escassos.Liberar esses objetos explicitamente no método `Dispose` libera-os mais rápido do que se eles fossem recuperados de forma não determinística pelo coletor de lixo.

Se a chamada do método vier de um finalizador (isto é, se *disposing* for `false`), somente o código que libera os recursos não gerenciados é executado. Como a ordem em que o coletor de lixo destrói objetos gerenciados durante a finalização não é definida, chamar essa sobrecarga `Dispose`com um valor de `false` impede que o finalizador tente liberar os recursos gerenciados que já podem ter sido recuperados.

Implementando o padrão de descarte para uma classe base[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#implementing-the-dispose-pattern-for-a-base-class)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Se você implementar o padrão de descarte para uma classe base, deverá fornecer o seguinte:

Importante

É preciso implementar esse padrão para todas as classes de base que implementam [Dispose()](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose#System_IDisposable_Dispose) e não são `sealed` (`NotInheritable` no Visual Basic).

-   Uma implementação de [Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) que chame o método `Dispose(Boolean)`.

-   Um método `Dispose(Boolean)` que execute o trabalho real de liberar recursos.

-   Uma classe derivada de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) que envolva o recurso não gerenciado (recomendado) ou uma substituição para o método [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize). A classe [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) fornece um finalizador que o libera de ter que codificar um.

Aqui está o padrão geral para implementar o padrão de descarte para uma classe base que usa um identificador seguro.

C#Copiar

```
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class BaseClass : IDisposable
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   // Instantiate a SafeHandle instance.
   SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

   // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   // Protected implementation of Dispose pattern.
   protected virtual void Dispose(bool disposing)
   {
      if (disposed)
         return;

      if (disposing) {
         handle.Dispose();
         // Free any other managed objects here.
         //
      }

      disposed = true;
   }
}

```

Observação

O exemplo anterior usa um objeto [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle) para ilustrar o padrão; qualquer objeto derivado de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) poderia ser usado em vez disso. Observe que o exemplo não cria corretamente uma instância de seu objeto [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle).

Aqui está o padrão geral para implementar o padrão de descarte para uma classe base que substitui [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize).

C#Copiar

```
using System;

class BaseClass : IDisposable
{
   // Flag: Has Dispose already been called?
   bool disposed = false;

   // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   // Protected implementation of Dispose pattern.
   protected virtual void Dispose(bool disposing)
   {
      if (disposed)
         return;

      if (disposing) {
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //
      disposed = true;
   }

   ~BaseClass()
   {
      Dispose(false);
   }
}

```

Observação

No C#, você deve substituir [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize) definindo um [destruidor](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/destructors).

Implementando o padrão de descarte para uma classe derivada[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#implementing-the-dispose-pattern-for-a-derived-class)
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Uma classe derivada de uma classe que implementa a interface [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable) não deve implementar [IDisposable](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable) porque a implementação da classe base [IDisposable.Dispose](https://docs.microsoft.com/pt-br/dotnet/api/system.idisposable.dispose) é herdada pelas classes derivadas. Em vez disso, para implementar o padrão de descarte para uma classe derivada, você deverá fornecer o seguinte:

-   Um método `protected Dispose(Boolean)` que substitua o método da classe base e execute o trabalho real de liberar os recursos da classe derivada. Esse método também deve chamar o método `Dispose(Boolean)` da classe base e passar para ele um valor de `true` para o argumento *disposing*.

-   Uma classe derivada de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) que envolva o recurso não gerenciado (recomendado) ou uma substituição para o método [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize). A classe [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) fornece um finalizador que o libera de ter que codificar um. Se você fornecer um finalizador, ele deverá chamar a sobrecarga de `Dispose(Boolean)` com um argumento *disposing* de `false`.

Aqui está o padrão geral para implementar o padrão de descarte para uma classe derivada que usa um identificador seguro:

C#Copiar

```
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClass : BaseClass
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   // Instantiate a SafeHandle instance.
   SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

   // Protected implementation of Dispose pattern.
   protected override void Dispose(bool disposing)
   {
      if (disposed)
         return;

      if (disposing) {
         handle.Dispose();
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //

      disposed = true;
      // Call base class implementation.
      base.Dispose(disposing);
   }
}

```

Observação

O exemplo anterior usa um objeto [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle) para ilustrar o padrão; qualquer objeto derivado de [SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) poderia ser usado em vez disso. Observe que o exemplo não cria corretamente uma instância de seu objeto [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle).

Aqui está o padrão geral para implementar o padrão de descarte para uma classe derivada que substitui [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize):

C#Copiar

```
using System;

class DerivedClass : BaseClass
{
   // Flag: Has Dispose already been called?
   bool disposed = false;

   // Protected implementation of Dispose pattern.
   protected override void Dispose(bool disposing)
   {
      if (disposed)
         return;

      if (disposing) {
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //
      disposed = true;

      // Call the base class implementation.
      base.Dispose(disposing);
   }

   ~DerivedClass()
   {
      Dispose(false);
   }
}

```

Observação

No C#, você deve substituir [Object.Finalize](https://docs.microsoft.com/pt-br/dotnet/api/system.object.finalize) definindo um [destruidor](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/destructors).

Usando identificadores seguros[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#using-safe-handles)
---------------------------------------------------------------------------------------------------------------------------------------------

Escrever código para o finalizador de um objeto é uma tarefa complexa que poderá causar problemas se não for feito corretamente. Assim, recomendamos que você construa objetos [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle), em vez de implementar um finalizador.

As classes derivadas da classe [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle) simplificam problemas de vida útil de objetos ao atribuir e liberar identificadores sem interrupção. Elas contêm um finalizador crítico que certamente será executado enquanto um domínio de aplicativo estiver descarregando.Para obter mais informações sobre as vantagens de usar um identificador seguro, consulte [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/pt-br/dotnet/api/system.runtime.interopservices.safehandle). As seguintes classes derivadas no namespace [Microsoft.Win32.SafeHandles](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles) fornecem os identificadores seguros:

-   As classes [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle), [SafeMemoryMappedFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safememorymappedfilehandle) e [SafePipeHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safepipehandle) para arquivos, arquivos mapeados na memória e pipes.

-   A classe [SafeMemoryMappedViewHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safememorymappedviewhandle) para exibições de memória.

-   As classes [SafeNCryptKeyHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safencryptkeyhandle), [SafeNCryptProviderHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safencryptproviderhandle) e [SafeNCryptSecretHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safencryptsecrethandle) para construtores de criptografia.

-   A classe [SafeRegistryHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.saferegistryhandle) para chaves do registro.

-   A classe [SafeWaitHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safewaithandle) para identificadores de espera.

Usando um identificador seguro para implementar o padrão de descarte para uma classe base[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#using-a-safe-handle-to-implement-the-dispose-pattern-for-a-base-class)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

O exemplo a seguir ilustra o padrão de descarte para uma classe base, `DisposableStreamResource`, a qual usa um identificador seguro para encapsular recursos não gerenciados. Define uma classe `DisposableResource` que usa [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle) para encapsular um objeto [Stream](https://docs.microsoft.com/pt-br/dotnet/api/system.io.stream) que representa um arquivo aberto. O método `DisposableResource` também inclui uma única propriedade, `Size`, a qual retorna o número total de bytes no fluxo de arquivos.

C#Copiar

```
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

public class DisposableStreamResource : IDisposable
{
   // Define constants.
   protected const uint GENERIC_READ = 0x80000000;
   protected const uint FILE_SHARE_READ = 0x00000001;
   protected const uint OPEN_EXISTING = 3;
   protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
   protected IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
   private const int INVALID_FILE_SIZE = unchecked((int) 0xFFFFFFFF);

   // Define Windows APIs.
   [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
   protected static extern IntPtr CreateFile (
                                  string lpFileName, uint dwDesiredAccess,
                                  uint dwShareMode, IntPtr lpSecurityAttributes,
                                  uint dwCreationDisposition, uint dwFlagsAndAttributes,
                                  IntPtr hTemplateFile);

   [DllImport("kernel32.dll")]
   private static extern int GetFileSize(SafeFileHandle hFile, out int lpFileSizeHigh);

   // Define locals.
   private bool disposed = false;
   private SafeFileHandle safeHandle;
   private long bufferSize;
   private int upperWord;

   public DisposableStreamResource(string filename)
   {
      if (filename == null)
         throw new ArgumentNullException("The filename cannot be null.");
      else if (filename == "")
         throw new ArgumentException("The filename cannot be an empty string.");

      IntPtr handle = CreateFile(filename, GENERIC_READ, FILE_SHARE_READ,
                                 IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
                                 IntPtr.Zero);
      if (handle != INVALID_HANDLE_VALUE)
         safeHandle = new SafeFileHandle(handle, true);
      else
         throw new FileNotFoundException(String.Format("Cannot open '{0}'", filename));

      // Get file size.
      bufferSize = GetFileSize(safeHandle, out upperWord);
      if (bufferSize == INVALID_FILE_SIZE)
         bufferSize = -1;
      else if (upperWord > 0)
         bufferSize = (((long)upperWord) << 32) + bufferSize;
   }

   public long Size
   { get { return bufferSize; } }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }

   protected virtual void Dispose(bool disposing)
   {
      if (disposed) return;

      // Dispose of managed resources here.
      if (disposing)
         safeHandle.Dispose();

      // Dispose of any unmanaged resources not wrapped in safe handles.

      disposed = true;
   }
}

```

Usando um identificador seguro para implementar o padrão de descarte para uma classe derivada[](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose#using-a-safe-handle-to-implement-the-dispose-pattern-for-a-derived-class)
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

O exemplo a seguir ilustra o padrão de descarte para uma classe derivada, `DisposableStreamResource2`, que herda da classe `DisposableStreamResource` apresentada no exemplo anterior. A classe acrescenta um método adicional, `WriteFileInfo`, e usa um objeto [SafeFileHandle](https://docs.microsoft.com/pt-br/dotnet/api/microsoft.win32.safehandles.safefilehandle)para encapsular o identificador do arquivo gravável.

C#Copiar

```
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public class DisposableStreamResource2 : DisposableStreamResource
{
   // Define additional constants.
   protected const uint GENERIC_WRITE = 0x40000000;
   protected const uint OPEN_ALWAYS = 4;

   // Define additional APIs.
   [DllImport("kernel32.dll")]
   protected static extern bool WriteFile(
                                SafeFileHandle safeHandle, string lpBuffer,
                                int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
                                IntPtr lpOverlapped);

   // Define locals.
   private bool disposed = false;
   private string filename;
   private bool created = false;
   private SafeFileHandle safeHandle;

   public DisposableStreamResource2(string filename) : base(filename)
   {
      this.filename = filename;
   }

   public void WriteFileInfo()
   {
      if (! created) {
         IntPtr hFile = CreateFile(@".\FileInfo.txt", GENERIC_WRITE, 0,
                                   IntPtr.Zero, OPEN_ALWAYS,
                                   FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
         if (hFile != INVALID_HANDLE_VALUE)
            safeHandle = new SafeFileHandle(hFile, true);
         else
            throw new IOException("Unable to create output file.");

         created = true;
      }

      string output = String.Format("{0}: {1:N0} bytes\n", filename, Size);
      int bytesWritten;
      bool result = WriteFile(safeHandle, output, output.Length, out bytesWritten, IntPtr.Zero);
   }

   protected new virtual void Dispose(bool disposing)
   {
      if (disposed) return;

      // Release any managed resources here.
      if (disposing)
         safeHandle.Dispose();

      disposed = true;

      // Release any unmanaged resources not wrapped by safe handles here.

      // Call the base class implementation.
      base.Dispose(true);
   }
}
```