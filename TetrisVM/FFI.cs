namespace TetrisVM;

using System;
using System.Runtime.InteropServices;

public enum ObpfTetrominoType
{
    OBPF_TETROMINO_TYPE_EMPTY = 0,
    OBPF_TETROMINO_TYPE_I,
    OBPF_TETROMINO_TYPE_J,
    OBPF_TETROMINO_TYPE_L,
    OBPF_TETROMINO_TYPE_O,
    OBPF_TETROMINO_TYPE_S,
    OBPF_TETROMINO_TYPE_T,
    OBPF_TETROMINO_TYPE_Z,
    OBPF_TETROMINO_TYPE_LAST = OBPF_TETROMINO_TYPE_Z,
}

[StructLayout(LayoutKind.Sequential)]
public struct ObpfVec2(byte x, byte y)
{
    public byte x = x;
    public byte y = y;
}

[StructLayout(LayoutKind.Sequential)]
public struct ObpfTetromino {
    public unsafe ObpfVec2* mino_positions;
    public ObpfTetrominoType type;
}

[StructLayout(LayoutKind.Sequential)]
public struct ObpfMatrix(IntPtr ptr)
{
    public byte Width => Interop.obpf_tetrion_width();
    public byte Height => Interop.obpf_tetrion_height();

    public ObpfTetrominoType this[ObpfVec2 position] => Interop.obpf_matrix_get(ptr, position);
    public ObpfTetrominoType this[byte x, byte y] => Interop.obpf_matrix_get(ptr, new ObpfVec2(x, y));

    public void Display()
    {
        for (byte x = 0; x < Width; x++)
        {
            for (byte y = 0; y < Height; y++)
            {
                var el = this[x, y];
                if (el == ObpfTetrominoType.OBPF_TETROMINO_TYPE_EMPTY)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("O");
                }
            }

            Console.WriteLine();
        }
    }
}

public enum ObpfKey
{
    OBPF_KEY_LEFT,
    OBPF_KEY_RIGHT,
    OBPF_KEY_DROP,
}

public enum ObpfEventType
{
    OBPF_PRESSED,
    OBPF_RELEASED,
}

[StructLayout(LayoutKind.Sequential)]
public struct ObpfEvent
{
    public ObpfKey key;
    public ObpfEventType type;
    public ulong frame;
}

[StructLayout(LayoutKind.Sequential)]
public struct Tetrion(IntPtr ptr) : IDisposable
{
    public void Dispose()
    {
        Interop.obpf_destroy_tetrion(ptr);
    }

    public bool TryGetActiveTetromino(out ObpfTetromino out_tetromino)
    {
        return Interop.obpf_tetrion_try_get_active_tetromino(ptr, out out_tetromino);
    }

    public void SimulateUpUntil(ulong frame)
    {
        Interop.obpf_tetrion_simulate_up_until(ptr, frame);
    }

    public ObpfMatrix CreateMatrix()
    {
        return new(Interop.obpf_tetrion_matrix(ptr));
    }

    public void EnqueueEvent(ObpfKey key, ObpfEventType type, ulong frame)
    {
        var ev = new ObpfEvent
        {
            key = key,
            type = type,
            frame = frame
        };

        Interop.obpf_tetrion_enqueue_event(ptr, ev);
    }
}

public static class Interop
{
    private const string ObpfLibrary = "libsimulator_dynamic.so"; // Replace with the actual C++ library name

    [DllImport(ObpfLibrary)]
    public static extern IntPtr obpf_create_tetrion();

    [DllImport(ObpfLibrary)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool obpf_tetrion_try_get_active_tetromino(IntPtr tetrion, out ObpfTetromino out_tetromino);

    [DllImport(ObpfLibrary)]
    public static extern void obpf_tetrion_simulate_up_until(IntPtr tetrion, ulong frame);

    [DllImport(ObpfLibrary)]
    public static extern void obpf_destroy_tetrion(IntPtr tetrion);

    [DllImport(ObpfLibrary)]
    public static extern IntPtr obpf_tetrion_matrix(IntPtr tetrion);

    [DllImport(ObpfLibrary)]
    public static extern ObpfTetrominoType obpf_matrix_get(IntPtr matrix, ObpfVec2 position);

    [DllImport(ObpfLibrary)]
    public static extern void obpf_tetrion_enqueue_event(IntPtr tetrion, ObpfEvent obpfEvent);

    [DllImport(ObpfLibrary)]
    public static extern byte obpf_tetrion_width();

    [DllImport(ObpfLibrary)]
    public static extern byte obpf_tetrion_height();
}

public static class Simulator
{
    public static Tetrion CreateTetrion()
    {
        return new Tetrion(Interop.obpf_create_tetrion());
    }
}