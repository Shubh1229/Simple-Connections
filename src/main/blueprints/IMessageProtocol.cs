

namespace SimpleConnections.blueprints
{
    public interface IMessageProtocol
    {
        byte[] Encode(string plainText);
        string Decode(byte[] rawData);
    }
}