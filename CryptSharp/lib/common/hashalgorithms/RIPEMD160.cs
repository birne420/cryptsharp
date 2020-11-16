namespace CryptSharp.lib.common.hashalgorithms {
    /// <summary>
    /// RIPEMD160 CryptoServiceProvider Interface.
    /// </summary>
    public class RIPEMD160 {
        /// <summary>
        /// CSP.
        /// </summary>
        private System.Security.Cryptography.RIPEMD160 csp;


        /// <summary>
        /// RIPEMD160 hash algorithm.
        /// </summary>
        public RIPEMD160() {
            csp = System.Security.Cryptography.RIPEMD160Managed.Create();
        }

        /// <summary>
        /// Hash of string as byte array.
        /// </summary>
        /// <param name="inString">Input string</param>
        /// <returns>Output bytes</returns>
        public byte[] hashString(string inString) {
            byte[] toHash = System.Text.Encoding.ASCII.GetBytes(inString);
            return csp.ComputeHash(toHash);
        }

        /// <summary>
        /// Hash of byte array as byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <returns>Output bytes</returns>
        public byte[] hashBytes(byte[] inBytes) {
            return csp.ComputeHash(inBytes);
        }

        /// <summary>
        /// Hash of stream as byte array.
        /// </summary>
        /// <param name="inStream">Input stream</param>
        /// <returns>Output bytes</returns>
        public byte[] hashStream(System.IO.Stream inStream) {
            return csp.ComputeHash(inStream);
        }

        /// <summary>
        /// Hash of file as byte array.
        /// </summary>
        /// <param name="inPath">Input path</param>
        /// <returns>Output bytes</returns>
        public byte[] hashFile(string inPath) {
            System.IO.Stream inStream = System.IO.File.Open(inPath, System.IO.FileMode.Open);
            return csp.ComputeHash(inStream);
        }
    }
}