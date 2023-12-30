using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

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