

namespace SimpleConnections.blueprints
{
    /// <summary>
    /// Defines how messages are encoded into byte arrays for transmission and decoded back into strings on receipt.
    /// Supports protocol flexibility (e.g., Base64, custom binary).
    /// </summary>
    public interface IMessageProtocol
    {
        /// <summary>
        /// Encodes a plain string into a byte array for sending.
        /// </summary>
        byte[] Encode(string plainText);
        /// <summary>
        /// Decodes a byte array back into a human-readable string.
        /// </summary>
        string Decode(byte[] rawData);
    }
}