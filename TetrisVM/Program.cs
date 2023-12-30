using TetrisAssembler;
using TetrisAssembler.Core;

namespace TetrisVM;

public static class Program
{
    public static void Main()
    {
        var document = new AssemblyDocument(new StringSource("test.asm", """
                                                                         start
                                                                         input left
                                                                         input drop
                                                                         display
                                                                         stop
                                                                         """));

        using var program = document.Assemble();

        var vm = new VirtualMaschine(program);
        vm.Execute();
    }
}