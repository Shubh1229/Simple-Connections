
using SimpleConnections.blueprints;

namespace SimpleConnections.tools
{
    public class MessageProtocol_v1 : IMessageProtocol
    {
        public string Decode(byte[] rawData)
        {
            throw new NotImplementedException();
        }

        public byte[] Encode(string plainText)
        {
            throw new NotImplementedException();
        }
    }
}