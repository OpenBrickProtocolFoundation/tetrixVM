namespace TetrisVM;

public enum OpCode : byte
{
    Game = 0x01,
    Input = 0x02,
    Flow = 0x03,
    Data = 0x04
}