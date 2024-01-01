namespace TetrisVM.Instructions;

public class PushCurrentTetromino : IInstruction
{
    public override OpCode OpCode => OpCode.PushCurrentTetromino;
    public override IInstruction Read(BinaryReader reader)
    {
        return new PushCurrentTetromino();
    }

    public override void Execute(VirtualMaschine vm)
    {
        if (vm.Tetrion.TryGetActiveTetromino(out var tetromino))
        {
            vm.Stack.Push(tetromino);
        }
    }
}