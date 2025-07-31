

using SimpleConnections.model;
using Terminal.Gui;

namespace SimpleConnections.blueprints
{
    public interface IBackground
    {
        Task BuildBackground(View container, PageModel page);
    }
}