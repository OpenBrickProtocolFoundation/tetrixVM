namespace TetrisVM;

public class AssemblyWriter
{
    private MemoryStream strm = new MemoryStream();
    private BinaryWriter writer;

    public AssemblyWriter()
    {
        this.writer = new BinaryWriter(strm);
    }
}