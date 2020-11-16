namespace CryptSharp.lib.implementations.psi.utility {
    /// <summary>
    /// Provides utility functions for PSI encryption.
    /// </summary>
    public class UsageHelper_Hash {
        /// <summary>
        /// Creates a hash of the string as byte array.
        /// This function can be used to convert a password into a byte array in order to perform encryption.
        /// </summary>
        /// <param name="Value">String to hash</param>
        /// <param name="Length">Length of output</param>
        /// <returns>Hash as byte array</returns>
        public byte[] getHashAsByteArray(string Value, int Length = 32) {
            return new utility.HashFunction(Length).createByteHash(Value);
        }

        /// <summary>
        /// Creates a hash of the string as string.
        /// </summary>
        /// <param name="Value">String to hash</param>
        /// <param name="Length">Length of output</param>
        /// <returns>Hash as string</returns>
        public string getHashAsString(string Value, int Length = 32) {
            utility.HashFunction tmp = new utility.HashFunction(Length);
            return tmp.convertByteHashToString(tmp.createByteHash(Value));
        }
    }
}