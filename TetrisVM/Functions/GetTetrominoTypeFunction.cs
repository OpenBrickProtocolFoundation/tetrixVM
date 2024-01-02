using TetrisVM.FFI;
using TetrisVM.Instructions;

namespace TetrisVM.Functions;

public class GetTetrominoTypeFunction : Callable<ObpfTetrominoType, byte, byte>
{
    protected override ObpfTetrominoType Call(byte x, byte y)
    {
        var tetrominoType = vm.Matrix[x, y];

        return tetrominoType;
    }
}