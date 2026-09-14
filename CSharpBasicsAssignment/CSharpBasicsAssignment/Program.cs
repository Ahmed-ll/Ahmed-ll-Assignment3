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