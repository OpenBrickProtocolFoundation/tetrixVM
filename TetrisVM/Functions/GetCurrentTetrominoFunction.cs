using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class GetCurrentTetrominoFunction: ICallable
{
    public void Call(VirtualMaschine vm)
    {
        if (vm.Tetrion.TryGetActiveTetromino(out var tetromino))
        {
            vm.Stack.Push(tetromino);
        }
    }
}