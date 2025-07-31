
using SimpleConnections.blueprints;

namespace SimpleConnections.tools
{
    public class MessageProtocol_v1 : IMessageProtocol
    {
        /// <summary>
        /// Sample implementation of IMessageProtocol. Provides stubs for encoding and decoding.
        /// </summary>
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