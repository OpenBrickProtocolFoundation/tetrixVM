namespace TetrisVM.Instructions;

public class InputInstruction(InputDirection direction) : IInstruction
{
    public override OpCode OpCode => OpCode.Input;
    public override IInstruction Read(BinaryReader reader)
    {
        return new InputInstruction((InputDirection)reader.ReadByte());
    }

    public override void Write(BinaryWriter writer)
    {
        this.WriteOpcode(writer);
        writer.Write((byte)direction);
    }

    public override void Execute(VirtualMaschine vm)
    {
        Console.WriteLine(direction);
    }
}