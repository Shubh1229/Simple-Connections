

namespace SimpleConnections.blueprints
{
    public interface IFactory<T>
    {
        T Build();
    }
}