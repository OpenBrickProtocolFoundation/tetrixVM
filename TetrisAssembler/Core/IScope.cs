using TetrisAssembler.Core.Values;

namespace TetrisAssembler.Core {
    public interface IScope {
        IValue Get(string name);
    }
}
