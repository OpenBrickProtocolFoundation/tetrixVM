using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

[StructLayout(LayoutKind.Sequential)]
public struct ObpfTetromino
{
    public unsafe ObpfVec2 mino_positions;
    public ObpfTetrominoType type;
}