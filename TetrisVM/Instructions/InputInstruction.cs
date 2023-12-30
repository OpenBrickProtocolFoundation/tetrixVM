using TetrisVM.FFI;

namespace TetrisVM.Instructions;

public class InputInstruction : IInstruction
{
    private ObpfKey _direction;

    public override OpCode OpCode => OpCode.Input;
    public override IInstruction Read(BinaryReader reader)
    {
        return new InputInstruction() { _direction = (ObpfKey)reader.ReadByte() };
    }

    public override void Execute(VirtualMaschine vm)
    {
       vm.Tetrion.EnqueueEvent(_direction, ObpfEventType.OBPF_PRESSED, vm.GetSimulationFrame());

       vm.IncrementSimulationFrame();
    }
}