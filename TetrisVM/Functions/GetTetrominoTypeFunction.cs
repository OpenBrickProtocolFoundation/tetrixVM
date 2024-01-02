using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class GetTetrominoTypeFunction : ICallable
{
    public void Call(VirtualMaschine vm)
    {
        var x = (byte)vm.Stack.Pop();
        var y = (byte)vm.Stack.Pop();

        var tetrominoType = vm.Matrix[x, y];
        vm.Stack.Push(tetrominoType);
    }
}