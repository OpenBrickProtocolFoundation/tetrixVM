using TetrisVM.FFI;
using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class GetCurrentTetrominoFunction : Callable<ObpfTetromino>
{
    protected override ObpfTetromino Call()
    {
        return vm.Tetrion.TryGetActiveTetromino(out var tetromino) ? tetromino : default;
    }
}