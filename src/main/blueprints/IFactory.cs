

namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Generic factory interface for building instances of type T.
    /// Useful for creating pages, services, or components on demand.
    /// <typeparam name="T">Where <c>T</c> is the type of object to build.</typeparam>
    /// </summary>
    /// <typeparam name="T">The type of object to build.</typeparam>
    public interface IFactory<T>
    {
        /// <summary>
        /// Builds and returns an instance of type T.
        /// </summary>
        T Build();
    }
}