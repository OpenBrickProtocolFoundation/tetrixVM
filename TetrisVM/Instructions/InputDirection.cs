namespace TetrisVM.Instructions;

public enum InputDirection : byte
{
    Invalid = 0x00,
    Left = 0x01,
    Right = 0x02,
    Drop = 0x03,
    Down = 0x04
}