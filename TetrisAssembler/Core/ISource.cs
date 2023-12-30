namespace TetrisAssembler.Core {
    /// <summary>
    /// A instance able to supply the parser code to parse
    /// </summary>
    public interface ISource {
        /// <summary>
        /// Reference name used in debugging output
        /// </summary>
        string Reference { get; }

        /// <summary>
        /// Creates text reader to be used by the parser
        /// </summary>
        /// <returns></returns>
        TextReader Open();
    }
}
