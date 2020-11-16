namespace CryptSharp.lib.common.hashalgorithms {
    /// <summary>
    /// SHA1 CryptoServiceProvider Interface.
    /// </summary>
    public class SHA1 {
        /// <summary>
        /// CSP.
        /// </summary>
        private System.Security.Cryptography.SHA1CryptoServiceProvider csp;

        /// <summary>
        /// SHA1 hash algorithm.
        /// </summary>
        public SHA1() {
            csp = new System.Security.Cryptography.SHA1CryptoServiceProvider();
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