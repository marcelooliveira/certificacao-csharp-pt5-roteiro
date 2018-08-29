```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
 
namespace StringWriter_Class
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "Hello, This is Line 1 \nHello, This is Line 2 \nHello, This is Line 3";
            //Writing string into StringBuilder
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            //Store Data on StringBuilder
            writer.WriteLine(text);
            writer.Flush();
            writer.Close();
 
            //Read Entry
            StringReader reader = new StringReader(sb.ToString());
            //Check to End of File
            while (reader.Peek() > -1)
            {
                Console.WriteLine(reader.ReadLine());
            }
        }        
    }
}
```

Result:

```
Hello, This is Line 1 
Hello, This is Line 2 
Hello, This is Line 3
```