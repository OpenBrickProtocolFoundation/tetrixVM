using TetrisAssembler.Core.Values;

namespace TetrisAssembler.Core.Interpreters {
    /// <summary>
    /// An interpreter can be fed AssemblyLine's to process, and translate
    /// it to the appropriate action to undertale
    /// </summary>
    public interface IInterpreter {
        /// <summary>
        /// Translates a value to the point thats it's resolvable
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IValue Translate(IValue value);

        /// <summary>
        /// Will translate the given line into a action
        /// </summary>
        /// <param name="line"></param>
        void Process(AssemblyLine line);
    }
}
