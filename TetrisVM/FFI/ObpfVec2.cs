using System.Runtime.InteropServices;

namespace TetrisVM.FFI;

[StructLayout(LayoutKind.Sequential)]
public struct ObpfVec2(byte x, byte y)
{
    public byte x = x;
    public byte y = y;
}