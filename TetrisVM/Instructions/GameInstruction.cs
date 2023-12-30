using System.Threading.Channels;

namespace TetrisVM.Instructions;

public class GameInstruction(GameMode mode) : IInstruction
{
    public override OpCode OpCode => OpCode.Game;
    public GameMode Mode { get; set; } = mode;

    public override IInstruction Read(BinaryReader reader)
    {
        return new GameInstruction((GameMode)reader.ReadByte());
    }

    public override void Write(BinaryWriter writer)
    {
        this.WriteOpcode(writer);
        writer.Write((byte)Mode);
    }

    public override void Execute(VirtualMaschine vm)
    {
        switch (mode)
        {
            case GameMode.Start:
            case GameMode.Restart:
                vm.HasStarted = true;
                break;
            case GameMode.Stop:
                vm.HasStarted = false;
                vm.IsStopped = true;
                break;
        }

        Console.WriteLine(mode);
    }
}