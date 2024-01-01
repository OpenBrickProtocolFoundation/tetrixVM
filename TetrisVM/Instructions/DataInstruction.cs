namespace TetrisVM.Instructions;

public enum DataOperation
{
    Push = 0x01,
    Pop = 0x02,
    DUP = 0x03
}

public class DataInstruction : IInstruction
{
    public DataOperation Operation { get; }
    public byte Arg { get; set; }

    private DataInstruction(DataOperation operation)
    {
        Operation = operation;
    }

    public DataInstruction()
    {

    }

    public override OpCode OpCode => OpCode.Data;
    public override IInstruction Read(BinaryReader reader)
    {
        var instr = new DataInstruction((DataOperation)reader.ReadByte());

        if (instr is {Operation: DataOperation.Pop} || instr.Operation == DataOperation.Push)
        {
            instr.Arg = reader.ReadByte();
        }

        return instr;
    }

    public override void Execute(VirtualMaschine vm)
    {
        switch (Operation)
        {
            case DataOperation.Pop:
            {
                var item = vm.Stack.Pop();
                vm.Storage[Arg] = item;
                break;
            }
            case DataOperation.Push:
            {
                vm.Stack.Push(Arg);
                break;
            }
            case DataOperation.DUP:
            {
                var item = vm.Stack.Pop();

                vm.Stack.Push(item);
                vm.Stack.Push(item);
                break;
            }
        }
    }
}