(Line numbers are included for reference only.) 01 publ…

You are developing an application that will convert data into multiple output formats. The application includes
the following code. (Line numbers are included for reference only.)
```
01 public class TabDelimitedFormatter : IOutputFormatter<string>
02 {
03 readonly Func<int, char> suffix = col => col % 2 == 0 ? ‘\\n’ : ‘\\t’;
04 public string GetOutput(IEnumerator<string> iterator, int recordSize)
05 {
06
07 }
08 }
You are developing a code segment that will produce tab-delimited output. All output routines implement the
```
following interface:
You need to minimize the completion time of the GetOutput() method. Which code segment should youinsert at line 06?

PrepAway - Latest Free Exam Questions & Answers
A.
```
string output = null; 
for (int i = 1; iterator.MoveNext(); i++) 
{ 
output = string.Concat(output, iterator.Current, suffix(i)); 
} 
return output;
```

B.
```
var output = new StringBuilder(); 
for (int i = 1; iterator.MoveNext(); i++) 
{ 
output.Append(iterator.Current); 
output.Append(suffix(i)); 
} 
return output.ToString();
```

C.
```
string output = null; 
for (int i = 1; iterator.MoveNext(); i++) 
{ 
output = output + iterator.Current + suffix(i); 
} 
return output;
```

D.
```
string output = null; 
for (int i = 1; iterator.MoveNext(); i++) 
{ 
output += iterator.Current + suffix(i); 
} 
return output;
```

> Explanation:
> A String object concatenation operation always creates a new object from the existing string and the new data.
> A StringBuilder object maintains a buffer to accommodate the concatenation of new data. New data is
> appended to the buffer if room is available; otherwise, a new, larger buffer is allocated, data from the original
> buffer is copied to the new buffer, and the new data is then appended to the new buffer.
> The performance of a concatenation operation for a String or StringBuilder object depends on the frequency of
> memory allocations. A String concatenation operation always allocates memory, whereas a StringBuilder
> concatenation operation allocates memory only if the StringBuilder object buffer is too small to accommodate
> the new data. Use the String class if you are concatenating a fixed number of String objects. In that case, the
> compiler may even combine individual concatenation operations into a single operation. Use a StringBuilder
> object if you are concatenating an arbitrary number of strings; for example, if you’re using a loop to concatenate
> a random number of strings of user input.
> http://msdn.microsoft.com/en-us/library/system.text.stringbuilder(v=vs.110).aspx