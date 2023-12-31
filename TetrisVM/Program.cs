using TetrisAssembler;
using TetrisAssembler.Core;

namespace TetrisVM;

public static class Program
{
    public static void Main()
    {
        var document = new AssemblyDocument(new StringSource("test.asm", """
                                                                         start
                                                                         push 0
                                                                         push 42
                                                                         sleep 200
                                                                         store 42 1
                                                                         stop
                                                                         """));

        using var program = document.Assemble();

        var vm = new VirtualMaschine(program);
        vm.Execute();
    }
}