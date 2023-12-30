using TetrisAssembler;
using TetrisAssembler.Core;

namespace TetrisVM;

public static class Program
{
    public static void Main()
    {
        using var tetrion = Simulator.CreateTetrion();

        tetrion.EnqueueEvent(ObpfKey.OBPF_KEY_LEFT, ObpfEventType.OBPF_PRESSED, 1);
        var matrix = tetrion.CreateMatrix();
        tetrion.SimulateUpUntil(2);

        Console.Clear();
        matrix.Display();
        tetrion.EnqueueEvent(ObpfKey.OBPF_KEY_DROP, ObpfEventType.OBPF_PRESSED, 4);
        tetrion.SimulateUpUntil(5);
        Console.Clear();
        matrix.Display();


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