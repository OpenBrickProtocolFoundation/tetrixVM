namespace TetrisAssembler.Core {
    public class AssemblerException : Exception {
        public Trace Trace { get; }

        public AssemblerException(string message, Trace trace, params object[] arguments)
            : base(string.Format(message, arguments)) {
            Trace = trace;
        }
    }
}
