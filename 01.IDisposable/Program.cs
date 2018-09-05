using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _01.idisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceHolder r = new ResourceHolder();
            r.Dispose();
        }
    }

    //IDisposable: Fornece um mecanismo para liberar recursos não gerenciados.
    class ResourceHolder : IDisposable
    {
        // Indica quando um objeto foi descartado
        bool disposed = false;

        /// <summary>
        /// Executa tarefas definidas pelo aplicativo associadas à liberação,
        /// liberação ou redefinição de recursos não gerenciados.
        /// </summary>
        public void Dispose()
        {
            // Chama Dispose() e informa que a chamada
            //foi feita durante o descarte do objeto
            Dispose(true);

            //Já estamos finalizando manualmente, portanto
            //solicita que o common language runtime não chame o 
            //finalizador para o objeto especificado
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            // Abandona se o objeto já foi descartado
            if (disposed)
                return;
            if (disposing)
            {
                // libera objetos gerenciados
            }
            // libera objetos não-gerenciados
            disposed = true;
        }

        ~ResourceHolder()
        {
            // descarta somente objetos não-gerenciados
            Dispose(false);
        }
    }

}
