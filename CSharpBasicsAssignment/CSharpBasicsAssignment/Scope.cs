class Scope
{
    private int x = 7; // private field

    public void ReadFieldFromMethodA() =>
        Console.WriteLine($"MethodA reading x: {x}"); 
    public void ReadFieldFromMethodB() =>
        Console.WriteLine($"MethodB reading x: {x}"); 
}