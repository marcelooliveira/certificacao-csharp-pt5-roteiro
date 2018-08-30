Você está criando uma classe chamada `Data`, que inclui um dicionário chamado `data`. 
Você precisa permitir que o coletor de lixo colete as referências do objeto `data`.
Como você completaria as lacunas abaixo? 


**Opções disponíveis:**

```
static Dictionary<int, WeakReference> _data = new Dictionary<int, WeakReference>();
static Dictionary<int, int> _data = new Dictionary<int, int>();
_data.Add(i, new WeakReference(new Class(i * 2), false));
_data.Add(i, (Int32)(i * 2));
```

**código incompleto:**

```
public class Data
{
	[LACUNA 1]
	public Data(int count)
	{
		for (int i = 0; i < count; i++)
		{
			[LACUNA 2]
		}
	}
}
	
public class MinhaClasse
{
	private readonly int numero;
	public MinhaClasse(int numero)
	{
		this.numero = numero;
	}
}
```

**Resposta:**

```
public class Data
{
	static Dictionary<int, WeakReference> _data = new Dictionary<int, WeakReference>();
	public Data(int count)
	{
		for (int i = 0; i < count; i++)
		{
			_data.Add(i, new WeakReference(new MinhaClasse(i * 2), false));
		}
	}
}
```
