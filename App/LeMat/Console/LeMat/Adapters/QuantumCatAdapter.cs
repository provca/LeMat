using LeMat.Interfaces;

namespace LeMat.Adapters
{
    /// <summary>
    /// Adapter class that integrates the <see cref="IUserInterface"/> from the LeMat project 
    /// with the <see cref="QuantumCat.Interfaces.IUserInterface"/> for compatibility.
    /// </summary>
    internal class QuantumCatAdapter : QuantumCat.Interfaces.IUserInterface
    {
        /// <summary>
        /// The instance of the LeMat <see cref="IUserInterface"/> being adapted.
        /// </summary>
        private readonly IUserInterface _leMatUi;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantumCatAdapter"/> class.
        /// </summary>
        /// <param name="leMatUi">The LeMat <see cref="IUserInterface"/> to adapt.</param>
        public QuantumCatAdapter(IUserInterface leMatUi)
        {
            _leMatUi = leMatUi;
        }

        /// <inheritdoc />
        public void Write(string message) => _leMatUi.Write(message);

        /// <inheritdoc />
        public void WriteLine(string message) => _leMatUi.WriteLine(message);

        /// <inheritdoc />
        public string ReadLine() => _leMatUi.ReadLine();

        /// <inheritdoc />
        public void Clear() => _leMatUi.Clear();
    }
}
