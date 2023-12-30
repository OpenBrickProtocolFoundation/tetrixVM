namespace TetrisVM.Instructions;

public class DataInstruction : IInstruction
{
    public byte Arg { get; }

    private DataInstruction(byte arg)
    {
        Arg = arg;
    }

    public override OpCode OpCode => OpCode.Data;
    public override IInstruction Read(BinaryReader reader)
    {
        return new DataInstruction(reader.ReadByte());
    }

    public override void Execute(VirtualMaschine vm)
    {
        throw new NotImplementedException();
    }
}