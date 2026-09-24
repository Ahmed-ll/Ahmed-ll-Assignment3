using CSharpBasicsAssignment;

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

void RunValueVsReferenceDemo()
{
    #region Experiment 1: struct copy semantics

    // When p1 is assigned to p2, the values of p1 are copied into p2 => p1 and p2 are two independent copies.
    Point p1 = new Point { X = 1, Y = 1 };
    Point p2 = p1;

    p2.X = 5; // Changing p2 but not affect p1 because p2 has its own copy of the data.

    Console.WriteLine($"p1.X = {p1.X}"); // will print 1, because p1 is unchanged.
    Console.WriteLine($"p2.X = {p2.X}"); // will print 5, because p2 was modified independently.

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Experiment 2: class reference semantics (Order)

    Order o1 = new Order
    {
        OrderId = 1001,
        CustomerName = "Ahmed",
        Quantity = 3,
        UnitPrice = 150.0m,
        TotalPrice = 0m, 
        IsPaid = false,
        DiscountPercent = 10.0,
        ShippingCity = "Giza",
        Priority = 'H',
        ItemCode = 5551234567L
    };

    o1.CalculateTotal();
    Order o2 = o1;

    o2.IsPaid = true;

    Console.WriteLine($"o1.IsPaid = {o1.IsPaid}"); // will print true, because o1 and o2 refer to the same object in memory.
    Console.WriteLine($"o2.IsPaid = {o2.IsPaid}"); // will print true

    Console.WriteLine("____________________________________________________");

    object boxedOrder = o1; // Boxing: the reference to the Order object is stored in an object variable (on the heap).    

    Order o3 = (Order)boxedOrder; // explicit cast 

    Console.WriteLine($"{object.ReferenceEquals(o1, o3)}"); // True — Same Reference.

    o2.PrintSummary();

    #endregion

    Console.WriteLine("____________________________________________________");

    #region Part C Summary

    // Value types (like struct and primitives such as int, bool, double) are stored on the Stack, their data lives right there in the variable itself.
    // Reference types (like class , interface) have their actual data stored on the Heap, while the variable on the Stack only holds a reference (an address) pointing to that heap location.


    // Assigning a value type ("p2 = p1"), the actual data is copied, creating two fully independent variables that can change without affecting each other.
    // Assigning a reference type ("o2 = o1"), only the reference is copied — both variables is pointing at the exact same object on the heap, so changing one through either variable changes what both of them see.    

    // Storing a reference type inside an "object" variable does not create a new object because Order is already a reference type
    // the object variable just holds a copy of the same address, not a new copy of the data

    #endregion
}

void RunScopeAndOperatorsDemo()
{
    #region  D1: Scope

    Scope demo = new Scope();
    demo.ReadFieldFromMethodA(); 
    demo.ReadFieldFromMethodB(); 

    void LocalScope()
    {
        int y = 20; // local variable
        Console.WriteLine($"y = {y}"); 
    }
    // Console.WriteLine($"y = {y}"); // not allowed, will give compile error because y is out of scope.

    Console.WriteLine("____________________________________________________");

    for (int i = 0; i < 3; i++)
    {
        int result = i * 10;
        Console.WriteLine($"i = {i}, result = {result}"); // allowed
    }

    // Console.WriteLine($"i = {i}, result = {result}"); // not allowed, will give compile error because i and result are out of scope
    // Reason: Both 'i'  and 'result' are defined within the for loop's braces { }
    // Once the loop finishes, and all variables defined within it are automatically destroyed.

    #endregion

    Console.WriteLine("____________________________________________________");

    #region D2: Compound Assignment Operators

    int total = 100;

    total += 20;
    Console.WriteLine($"total = {total}"); // 120

    total -= 30;
    Console.WriteLine($"total = {total}"); // 90

    total *= 2;
    Console.WriteLine($"total = {total}"); // 180

    total /= 4;
    Console.WriteLine($"total = {total}"); // 45

    total %= 9;
    Console.WriteLine($"total = {total}"); // 0

    // total += 20;   equivalent to   total = total + 20;

    #endregion

    Console.WriteLine("____________________________________________________");

    #region D3: Bitwise operators

    int a = 12; // binary: 1100
    int b = 10; // binary: 1010

    int andResult = a & b; // AND: 1100 & 1010 = 1000 = 8
    int orResult = a | b; // OR:  1100 | 1010 = 1110 = 14
    int xorResult = a ^ b; // XOR: 1100 ^ 1010 = 0110 = 6

    Console.WriteLine($"a & b = {andResult}"); 
    Console.WriteLine($"a | b = {orResult}");
    Console.WriteLine($"a ^ b = {xorResult}");

    // The difference between & (bitwise) and && (logical) in an if-condition:
    // When using && in a condition, if the left side evaluates to false, the compiler does not evaluate the right side (short-circuit)
    // When using & always evaluates both sides, even if the left side is false.

    #endregion
}

int FindSingleNumber(int[] nums)
{
    int result = 0;
    foreach (int num in nums)
        result ^= num;

    return result;

    // Basic operation of XOR:
    // 1. a ^ 0 = a
    // 2. a ^ a = 0

    // Explanation:
    // 4 ^ 1 ^ 2 ^ 1 ^ 2 = 4 ^ (1 ^ 1) ^ (2 ^ 2) = 4 ^ 0 ^ 0 = 4
    // 7 ^ 3 ^ 5 ^ 4 ^ 5 ^ 3 ^ 4 = 7 ^ (3 ^ 3) ^ (4 ^ 4) ^  (5 ^ 5)  = 7 ^ 0 ^ 0 ^ 0 = 7
}