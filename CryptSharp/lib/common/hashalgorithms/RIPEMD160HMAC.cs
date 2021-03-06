﻿namespace CryptSharp.lib.common.hashalgorithms {
    /// <summary>
    /// RIPEMD160 HMAC CryptoServiceProvider Interface.
    /// </summary>
    public class RIPEMD160HMAC {
        /// <summary>
        /// CSP.
        /// </summary>
        private System.Security.Cryptography.HMACRIPEMD160 hmac;

        /// <summary>
        /// RIPEMD160 hash algorithm plus hmac.
        /// </summary>
        public RIPEMD160HMAC() {
            hmac = new System.Security.Cryptography.HMACRIPEMD160();
        }

        /// <summary>
        /// Hash of string as byte array.
        /// </summary>
        /// <param name="inString">Input string</param>
        /// <param name="inKey">Input salt</param>
        /// <returns>Output bytes</returns>
        public byte[] hashString(string inString, byte[] inKey) {
            byte[] toHash = System.Text.Encoding.ASCII.GetBytes(inString);
            hmac.Key = inKey;
            return hmac.ComputeHash(toHash);
        }

        /// <summary>
        /// Hash of byte array as byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="inKey">Input salt</param>
        /// <returns>Output bytes</returns>
        public byte[] hashBytes(byte[] inBytes, byte[] inKey) {
            hmac.Key = inKey;
            return hmac.ComputeHash(inBytes);
        }

        /// <summary>
        /// Hash of stream as byte array.
        /// </summary>
        /// <param name="inStream">Input stream</param>
        /// <param name="inKey">Input salt</param>
        /// <returns>Output bytes</returns>
        public byte[] hashStream(System.IO.Stream inStream, byte[] inKey) {
            hmac.Key = inKey;
            return hmac.ComputeHash(inStream);
        }

        /// <summary>
        /// Hash of file as byte array.
        /// </summary>
        /// <param name="inPath">Input path</param>
        /// <param name="inKey">Input salt</param>
        /// <returns>Output bytes</returns>
        public byte[] hashFile(string inPath, byte[] inKey) {
            System.IO.Stream inStream = System.IO.File.Open(inPath, System.IO.FileMode.Open);
            hmac.Key = inKey;
            return hmac.ComputeHash(inStream);
        }
    }
}