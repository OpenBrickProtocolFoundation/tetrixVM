namespace TetrisAssembler.Core {
    /// <summary>
    /// A reference to a point in a source file
    /// </summary>
    public interface ISourcePointer {
        /// <summary>
        /// The the source file this line is from
        /// </summary>
        ISource Source { get;  }

        /// <summary>
        /// The line number in the source file this assembly line was found
        /// </summary>
        int LineNumber { get; }
    }
}
