namespace TetrisVM.Instructions;

public class PushTetrominoType : IInstruction
{
    public override OpCode OpCode => OpCode.PushTetrominoType;
    public override IInstruction Read(BinaryReader reader)
    {
        return new PushTetrominoType();
    }

    public override void Execute(VirtualMaschine vm)
    {
        var x = (byte)vm.Stack.Pop();
        var y = (byte)vm.Stack.Pop();

        var tetrominoType = vm.Matrix[x, y];
        vm.Stack.Push(tetrominoType);
    }
}