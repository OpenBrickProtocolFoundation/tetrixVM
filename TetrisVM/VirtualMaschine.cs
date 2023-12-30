using TetrisVM.FFI;

namespace TetrisVM;

public class VirtualMaschine
{
    public readonly ObpfMatrix Matrix;
    private readonly AssemblyReader reader;
    public readonly ObpfTetrion Tetrion;

    public bool HasStarted = false;
    public Stack<object> Stack = new(100);

    public Storage Storage = new();


    public VirtualMaschine(Stream strm)
    {
        reader = new(strm);

        Tetrion = new();
        Matrix = Tetrion.CreateMatrix();
    }

    public bool IsStopped { get; set; }


    public void ExecuteInstruction()
    {
        var instruction = reader.ReadInstruction();

        instruction.Execute(this);
    }

    public void Execute()
    {
        while (reader.Position < reader.Length && !IsStopped)
            ExecuteInstruction();
    }

    public ulong GetSimulationFrame()
    {
        return (ulong) Storage[0];
    }

    public void IncrementSimulationFrame()
    {
        Storage[0] = (ulong) Storage[0] + 1;
    }
}