## Write `C#` code analyzer with `F#`

https://johnkoerner.com/code-analysis/creating-a-code-analyzer-using-f

Still not working ...

## Issues

- System.Collection.Immutable was not included in VSIX - http://blog.comealive.io/Forcing-DLLs-To-Vsix
- get_SupportedDiagnostics does not have an implementation.

> An exception of type 'System.TypeLoadException' occurred in mscorlib.dll and wasn't handled before a managed/native boundary
> Additional information: Method 'get_SupportedDiagnostics' in type 'CodeAnalyzer.FSharp.Library.MyFirstFSAnalyzer' from assembly 'CodeAnalyzer.FSharp.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' does not have an implementation.
