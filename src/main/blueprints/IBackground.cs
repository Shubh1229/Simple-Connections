

using SimpleConnections.model;
using Terminal.Gui;

namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Defines a contract for setting up a page's background, including layout and decorations.
    /// Implementations should populate the provided container View with visual elements.
    /// </summary>
    public interface IBackground
    {
        /// <summary>
        /// Mandates the Method BuildBackground be implemented for all children of IBackground
        /// </summary>
        /// <param name="container">The parent view to which background elements are added.</param>
        /// <param name="page">The current PageModel to associate background setup with.</param>
        Task BuildBackground(View container, PageModel page);
    }
}