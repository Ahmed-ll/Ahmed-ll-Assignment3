void ProjectStructureDemo()
{
    Console.WriteLine("=== PART A: Project & Structure ===");

    // --------------------------------------- First Requirement ------------------------------------------------

    // .csproj ==>  This is the project configuration file; it specifies the target framework version, the NuGet packages used, and the project's build information.

    // Program.cs ==> This is the application's main file, containing the program's entry point — the first code executed when the program runs.

    // obj ==> This folder contains intermediate files generated during the build process — files used by.NET / MSBuild to build the project.

    // bin ==> This folder contains the final output(the compiled application) and any other files necessary to run the program.

    // --------------------------------------- Second Requirement ------------------------------------------------

    // < OutputType > Exe </ OutputType >
    // < TargetFramework > net10.0 </ TargetFramework >
    // < ImplicitUsings > enable </ ImplicitUsings >
    // < Nullable > enable </ Nullable >

    // --------------------------------------- Third Requirement ------------------------------------------------

    // file-scoped namespace: no need for braces {} to wrap the namespace's content
    // everything below this line shifts one indentation level to the left
    // namespace CSharpBasicsAssignment;

    // The reason for removing the indentation level:
    // The old approach required braces { } around the entire namespace:
    //
    // namespace CSharpBasicsAssignment
    // {
    //     // All code here had to be indented one level to the right to make it clear that it belongs to the namespace
    // }
    //
    // With a file-scoped ==> namespace CSharpBasicsAssignment; instead of opening with a brace {},
    // which means "all code following this line in the file is automatically part of this namespace"
    // shift one level to the left (eliminating extra nesting), resulting in cleaner, more readable code.


    // --------------------------------------- Fourth Requirement ------------------------------------------------

    // My project uses the newer .slnx format.
    // Advantage of .sln (the one not chosen): it's the classic format supported by:
    // ALL versions of Visual Studio and .NET tooling (including older ones), so it guarantees compatibility with any teammate, or third-party tool that hasn't been updated to support .slnx yet.
}

void RunTypesDemo()
{
    Console.WriteLine("Part B — Variables, Types & Casting \n");

    #region Declare a variable of every type

    int myInt = 10;
    long myLong = 10000000000L;
    double myDouble = 3.14;
    decimal myDecimal = 100.50m;
    bool myBool = true;
    char myChar = 'A';
    string myString = "Hello";
    var myVar = 25;  // Type inferred as int in compile time

    Console.WriteLine("===== 1. Declaring Variables =====");
    Console.WriteLine($"int: {myInt}, Type: {myInt.GetType()}");
    Console.WriteLine($"long: {myLong}, Type: {myLong.GetType()}");
    Console.WriteLine($"double: {myDouble}, Type: {myDouble.GetType()}");
    Console.WriteLine($"decimal: {myDecimal}, Type: {myDecimal.GetType()}");
    Console.WriteLine($"bool: {myBool}, Type: {myBool.GetType()}");
    Console.WriteLine($"char: {myChar}, Type: {myChar.GetType()}");
    Console.WriteLine($"string: {myString}, Type: {myString.GetType()}");
    Console.WriteLine($"var (inferred): {myVar}, Type: {myVar.GetType()}");

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Implicit conversion

    long intToLong = myInt;    // int -> long: no cast needed because long can hold all int values
    int charToInt = myChar;    // char -> int: no cast needed because char can be represented as an integer (Unicode value)

    Console.WriteLine("\n===== 2. Implicit Conversion =====");
    Console.WriteLine($"int to long: {intToLong}");
    Console.WriteLine($"char to int: {charToInt}"); // will print the Unicode value of 'A' ==> 65

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Explicit conversion

    double numberDouble = 9.75;
    int castResult = (int)numberDouble;                // (int) cast: trancate the decimal part with no rounding ==>  9
    int convertResult = Convert.ToInt32(numberDouble); // Convert.ToInt32: converts to the nearest integer with rounding ==> 10

    Console.WriteLine("\n===== 3. Explicit Conversion =====");
    Console.WriteLine($"(int) cast (truncation): {castResult}");
    Console.WriteLine($"Convert.ToInt32 (rounding): {convertResult}");

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Integer division trap

    int intDivision = 5 / 2;         // int / int = int (integer division) ==> 2
    double doubleDivision = 5.0 / 2; // any operand is double, so the result is double ==> 2.5

    Console.WriteLine("\n===== 4. Integer Division Trap =====");
    Console.WriteLine($"5 / 2 (int): {intDivision}");
    Console.WriteLine($"5.0 / 2 (double): {doubleDivision}");

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Boxing / Unboxing

    int originalInt = 10;
    object boxedObject = originalInt;  // Boxing: copies the value type and puts it on the heap as an object
    int unboxedInt = (int)boxedObject; // Unboxing: converts it back to a value type on the stack (requires explicit cast)

    Console.WriteLine("\n===== 5. Boxing / Unboxing =====");
    Console.WriteLine($"Original int: {originalInt}");
    Console.WriteLine($"Boxed object: {boxedObject}");
    Console.WriteLine($"Unboxed int: {unboxedInt}");

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Parsing

    string goodString = "50";
    string badString = "abc";

    int parsedValue = int.Parse(goodString); // int.parse : will throw an exception if the string is not a valid integer
    bool success = int.TryParse(badString, out int tryParseResult); // TryParse does not throw an exception, it returns a bool indicating success or failure

    Console.WriteLine("\n===== 6. Parsing =====");
    Console.WriteLine($"int.Parse(\"50\"): {parsedValue}");
    if (success)
        Console.WriteLine($"TryParse succeeded: {tryParseResult}");
    else
        Console.WriteLine($"TryParse failed for \"{badString}\" ");

    #endregion

    Console.WriteLine("____________________________________________________");

    #region float -> decimal

    float myFloat = 5.5f;

    // decimal wrong = myFloat; 
    // The compiler rejects this line because float and decimal represent decimal numbers in different ways internally
    // float uses binary floating-point, while decimal uses base-10

    decimal correct = (decimal)myFloat;
    // this line use explicit cast to tell the compiler, "I know there's a difference in precision, and I accept it."

    Console.WriteLine("\n===== 7. float -> decimal =====");
    Console.WriteLine($"float value: {myFloat}");
    Console.WriteLine($"decimal (explicit cast): {correct}");

    #endregion

    Console.WriteLine("____________________________________________________");
}