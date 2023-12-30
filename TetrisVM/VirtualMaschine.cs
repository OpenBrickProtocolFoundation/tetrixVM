namespace TetrisVM;

public class VirtualMaschine
{
    private readonly AssemblyReader reader;

    public bool HasStarted = false;
    public bool IsStopped { get; set; }

    public object[] Storage = new object[100];
    public Stack<object> Stack = new(100);

    public VirtualMaschine(Stream strm)
    {
        reader = new(strm);
    }


    public void ExecuteInstruction()
    {
        var instruction = reader.ReadInstruction();

        instruction.Execute(this);
    }

    public void Execute()
    {
        while (reader.Position < reader.Length && !IsStopped)
        {
            ExecuteInstruction();
        }
    }
}