namespace TetrisVM.Instructions;

public class SleepInstruction : IInstruction
{
    private short ms;
    public override OpCode OpCode => OpCode.Sleep;
    public override IInstruction Read(BinaryReader reader)
    {
        return new SleepInstruction() { ms = reader.ReadInt16() };
    }

    public override void Execute(VirtualMaschine vm)
    {
        Thread.Sleep(ms);
    }
}