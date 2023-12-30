using TetrisAssembler.Core;
using TetrisAssembler.Core.Interpreters;

namespace TetrisAssembler;

public class AssemblyDocument(ISource source)
{
    public readonly Router Router = new();
    public readonly ISource Source = source;

    public Stream Assemble()
    {
        var stream = new MemoryStream();
        var document = new Document(stream);

        Program.Assemble(document, Router, new StreamSource("prelude.asm", Program.GetPrelude(), true));
        Program.Assemble(document, Router, Source);

        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}