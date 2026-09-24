< OutputType > Exe </ OutputType >
< TargetFramework > net10.0 </ TargetFramework >
< ImplicitUsings > enable </ ImplicitUsings >
< Nullable > enable </ Nullable >

_____________________________________________________________________________________________________

#region Any Thing
// code....
#endregion

No. #region - #endregion don't change the compiled output.
They are only used to organize and collapse code in VS.
They make large files easier to read and navigate.

_____________________________________________________________________________________________________

/// XML documentation comments when you want to document a method, class, or property for other developers that will use your code.
/// ==> document public APIs/members.

// for normal code comments.
//  ==>  explain the code.

// Normal comment
string FirstName = "Ahmed";

/// <summary>
/// Calculating sum of two numbers.
/// </summary>
int Sum(int a, int b) => a + b;

_____________________________________________________________________________________________________

 C# has no true global variables because it uses classes and namespaces to keep data organized and avoid naming conflicts.

 The closest equivalent is a static field inside a class:

class AppSettings { public static string AppName = "Simulation"; }
Console.WriteLine(AppSettings.AppName);