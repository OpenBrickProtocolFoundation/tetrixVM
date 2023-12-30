using TetrisAssembler.Core;
using TetrisAssembler.Core.Interpreters;

namespace TetrisVM;

public static class Program
{
    public static void Main()
    {
        var program = new MemoryStream();
        var writer = new BinaryWriter(program);

        //new GameInstruction(GameMode.Start).Write(writer);
        //new InputInstruction(InputDirection.Drop).Write(writer);
        //new GameInstruction(GameMode.Stop).Write(writer);

        Router router = new();
        using Document document = new Document(program);

        TetrisAssembler.Program.Assemble(document, router, new StreamSource("prelude.asm", TetrisAssembler.Program.GetPrelude(), true));
        TetrisAssembler.Program.Assemble(document, router, new StringSource("test.asm", @"
game start
input left
input drop
game stop
"));
        program.Seek(0, SeekOrigin.Begin);

        var vm = new VirtualMaschine(program);
        vm.Execute();
    }
}