using TetrisAssembler;
using TetrisAssembler.Core;

namespace TetrisVM;

public static class Program
{
    public static void Main()
    {
        var document = new AssemblyDocument(new StringSource("test.asm", """
                                                                         game start
                                                                         input left
                                                                         input drop
                                                                         game stop
                                                                         """));

        using var program = document.Assemble();

        var vm = new VirtualMaschine(program);
        vm.Execute();
    }
}