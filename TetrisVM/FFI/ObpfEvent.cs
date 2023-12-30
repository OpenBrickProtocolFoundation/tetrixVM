using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

[StructLayout(LayoutKind.Sequential)]
public struct ObpfEvent
{
    public ObpfKey key;
    public ObpfEventType type;
    public ulong frame;
}