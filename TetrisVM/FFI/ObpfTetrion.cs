using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

[StructLayout(LayoutKind.Sequential)]
public struct ObpfTetrion() : IDisposable
{
    private readonly IntPtr _ptr = Interop.obpf_create_tetrion();

    public void Dispose()
    {
        Interop.obpf_destroy_tetrion(_ptr);
    }

    public readonly bool TryGetActiveTetromino(out ObpfTetromino out_tetromino)
    {
        return Interop.obpf_tetrion_try_get_active_tetromino(_ptr, out out_tetromino);
    }

    public void SimulateUpUntil(ulong frame)
    {
        Interop.obpf_tetrion_simulate_up_until(_ptr, frame);
    }

    public ObpfMatrix CreateMatrix()
    {
        return new(Interop.obpf_tetrion_matrix(_ptr));
    }

    public void EnqueueEvent(ObpfKey key, ObpfEventType type, ulong frame)
    {
        var ev = new ObpfEvent
        {
            key = key,
            type = type,
            frame = frame
        };

        Interop.obpf_tetrion_enqueue_event(_ptr, ev);
    }
}