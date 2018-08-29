```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
 
namespace StringReader_Class
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            string text = @"You are reading
this article at
this site";
 
            using (StringReader reader = new StringReader(text))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    Console.WriteLine("Line {0}: {1}", count, line);
                }
            }
        }
    }
}
```

Result:

```
Line 1: You are reading
Line 2: this article at
Line 3: this site

```