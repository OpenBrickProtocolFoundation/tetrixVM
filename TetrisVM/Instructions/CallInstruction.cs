using TetrisVM.Functions;

namespace TetrisVM.Instructions;

public class CallInstruction(byte functionIndex) : IInstruction
{
    public static List<ICallable> Functions = new();

    public byte FunctionIndex { get; set; } = functionIndex;

    public override OpCode OpCode => OpCode.Call;
    public override IInstruction Read(BinaryReader reader)
    {
        return new CallInstruction(reader.ReadByte());
    }

    public CallInstruction() : this(0)
    {

    }

    static CallInstruction()
    {
        Functions.Add(new GetCurrentTetrominoFunction());
        Functions.Add(new GetTetrominoTypeFunction());
        Functions.Add(new SleepFunction());
    }

    public override void Execute(VirtualMaschine vm)
    {
        if (FunctionIndex > Functions.Count)
        {
            return;
        }

        Functions[functionIndex].Call(vm);
    }
}