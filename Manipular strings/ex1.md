Which four code segments should you use in sequence?
====================================================


You are developing an application by using C#. The application will output the text string\
"First Line" followed by the text string "Second Line".\
You need to ensure that an empty line separates the text strings.\
Which four code segments should you use in sequence? (To answer, move the appropriate\
code segments to the answer area and arrange them in the correct order.)\

```
sb.Append("\1");
var sb = new StringBuilder();
sb.Append("First Line");
sb.Append("\t");
sb.AppendLine();
sb.Append(String.Empty);
sb.Append("Second Line");
```

Answer: See the explanation.

> Explanation:\
> Box 1:\
> 
```
var sb = new StringBuilder();
```
>
> First we create the variable.\
> Box 2:\
```
sb.Append("First Line");
> 
```
>
> We create the first text line.\
> Box 3:\
```
sb.AppendLine();
> 
```
>
> We add a blank line.\
> The StringBuilder.AppendLine method appends the default line terminator to the end of the\
> current StringBuilder object.\
> Box 4:\
```
sb.Append("Second Line");
> 
```
> Finally we add the second line.