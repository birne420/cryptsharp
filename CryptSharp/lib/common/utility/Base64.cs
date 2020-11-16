namespace CryptSharp.lib.common.utility {
    /// <summary>
    /// Base64 encoding/decoding with ascii and utf-8 support.
    /// </summary>
    public class Base64 {
        /// <summary>
        /// Converts a byte array to a base64 string.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <returns>Output base64 string</returns>
        public string encodeBytes(byte[] inBytes) {
            return System.Convert.ToBase64String(inBytes);
        }

        /// <summary>
        /// Converts a base64 string to a byte array.
        /// </summary>
        /// <param name="inString">Input base64 string</param>
        /// <returns>Output bytes</returns>
        public byte[] decodeBytes(string inString) {
            return System.Convert.FromBase64String(inString);
        }

        /// <summary>
        /// Converts a plain string to a base64 string (ASCII).
        /// </summary>
        /// <param name="inString">Plain input string</param>
        /// <returns>Base64 string</returns>
        public string encodeStringASCII(string inString) {
            return System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(inString));
        }

        /// <summary>
        /// Converts a base64 string to a plain string (ASCII).
        /// </summary>
        /// <param name="inString">Base64 input string</param>
        /// <returns>Plain string</returns>
        public string decodeStringASCII(string inString) {
            return System.Text.Encoding.ASCII.GetString(System.Convert.FromBase64String(inString));
        }

        /// <summary>
        /// Converts a plain string to a base64 string (UTF-8).
        /// </summary>
        /// <param name="inString">Plain input string</param>
        /// <returns>Base64 string</returns>
        public string encodeStringUTF8(string inString) {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(inString));
        }

        /// <summary>
        /// Converts a base64 string to a plain string (UTF-8).
        /// </summary>
        /// <param name="inString">Base64 input string</param>
        /// <returns>Plain string</returns>
        public string decodeStringUTF8(string inString) {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(inString));
        }
    }
}