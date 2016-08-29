namespace CodeAnalyzer.FSharp.Library

open Microsoft.CodeAnalysis
open Microsoft.CodeAnalysis.Diagnostics
open System.Collections.Immutable
open System.Linq
open System

[<DiagnosticAnalyzer(Microsoft.CodeAnalysis.LanguageNames.CSharp)>]
type public MyFirstFSAnalyzer() = 
    inherit DiagnosticAnalyzer()
    let descriptor = DiagnosticDescriptor("FSharpIsLowerCase", 
                            "Types cannot contain lowercase letters", 
                            "{0} contains lowercase letters" , 
                            "Naming", 
                            DiagnosticSeverity.Warning, 
                            true, 
                            "User declared types should not contain lowercase letters.", 
                            null)


    override this.SupportedDiagnostics with get() = ImmutableArray.Create(descriptor)

    override this.Initialize (context: AnalysisContext) =
        let isLower = System.Func<_,_>(fun l -> Char.IsLower(l))
        let analyze (ctx: SymbolAnalysisContext) = 
            match ctx.Symbol with
                | z when z.Name.ToCharArray().Any(isLower) -> 
                    let d = Diagnostic.Create(descriptor, z.Locations.First(), z.Name)
                    ctx.ReportDiagnostic(d)
                | _->()

        context.RegisterSymbolAction(analyze, SymbolKind.NamedType)