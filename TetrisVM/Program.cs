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
                                                                         push 0
                                                                         sleep 200
                                                                         stop
                                                                         """));

        using var program = document.Assemble();

        var vm = new VirtualMaschine(program);
        vm.Execute();
    }
}