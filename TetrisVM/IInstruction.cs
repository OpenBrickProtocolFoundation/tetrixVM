namespace TetrisVM;

public abstract class IInstruction
{
    public abstract OpCode OpCode { get; }

    public abstract IInstruction Read(BinaryReader reader);

    public void WriteOpcode(BinaryWriter writer)
    {
        writer.Write((byte)OpCode);
    }

    public abstract void Execute(VirtualMaschine vm);
}