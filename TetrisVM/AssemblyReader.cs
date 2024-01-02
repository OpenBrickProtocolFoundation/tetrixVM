using TetrisVM.Instructions;

namespace TetrisVM;

public class AssemblyReader(Stream raw)
{
    private readonly Dictionary<OpCode, IInstruction> _instructions = new()
    {
        [OpCode.Game] = new GameInstruction(GameMode.Invalid),
        [OpCode.Input] = new InputInstruction(),
        [OpCode.Display] = new DispayInstruction(),
        [OpCode.Data] = new DataInstruction(),
        [OpCode.Call] = new CallInstruction(),
    };

    private readonly BinaryReader _reader = new(raw);
    public long Position => _reader.BaseStream.Position;
    public long Length => _reader.BaseStream.Length;

    public IInstruction ReadInstruction()
    {
        var opcode = (OpCode)_reader.ReadByte();

        return _instructions.GetValueOrDefault(opcode)!.Read(_reader);
    }
}