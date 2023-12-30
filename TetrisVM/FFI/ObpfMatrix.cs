using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

[StructLayout(LayoutKind.Sequential)]
public struct ObpfMatrix(IntPtr ptr)
{
    public byte Width => Interop.obpf_tetrion_width();
    public byte Height => Interop.obpf_tetrion_height();

    public ObpfTetrominoType this[ObpfVec2 position] => Interop.obpf_matrix_get(ptr, position);
    public ObpfTetrominoType this[byte x, byte y] => Interop.obpf_matrix_get(ptr, new(x, y));

    public void Display()
    {
        Console.Clear();

        for (byte y = 0; y < Height; y++)
        {
            for (byte x = 0; x < Width; x++)
            {
                var el = this[x, y];
                if (el == ObpfTetrominoType.OBPF_TETROMINO_TYPE_EMPTY)
                    Console.Write("*");
                else
                    Console.Write("O");
            }

            Console.WriteLine();
        }
    }
}