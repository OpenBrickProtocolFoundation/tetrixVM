namespace TetrisVM.Instructions;

public class DispayInstruction : IInstruction
{
    public override OpCode OpCode => OpCode.Display;
    public override IInstruction Read(BinaryReader reader)
    {
        return new DispayInstruction();
    }

    public override void Execute(VirtualMaschine vm)
    {
        vm.Tetrion.SimulateUpUntil(vm.GetSimulationFrame());
        vm.Matrix.Display();
    }
}