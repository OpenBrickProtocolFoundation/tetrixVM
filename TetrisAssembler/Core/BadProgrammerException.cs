namespace TetrisAssembler.Core {
    /// <summary>
    /// An exeption to throw at places where values are not what is expected. And is thus
    /// most likely a bug.
    /// </summary>
    public class BadProgrammerException : Exception {
        public BadProgrammerException(string message, params object[] arguments)
            : base(string.Format(message, arguments)) {
        }
    }
}
