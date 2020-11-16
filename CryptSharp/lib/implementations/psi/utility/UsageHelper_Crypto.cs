namespace CryptSharp.lib.implementations.psi.utility {
    /// <summary>
    /// Provides crypto functions for PSI functions.
    /// </summary>
    public class UsageHelper_Crypto {
        /// <summary>
        /// Encrypts the byte array with the specified key.
        /// </summary>
        /// <param name="inBytes">Bytes to encrypt</param>
        /// <param name="inKey">Key to encrypt, should be 32 bytes long</param>
        /// <returns>Encrypted bytes</returns>
        public byte[] encryptBytes(byte[] inBytes, byte[] inKey) {
            return new crypt.Encryptor().EncryptByteArray(inBytes, inKey);
        }

        /// <summary>
        /// Decrypts the byte array with the specified key.
        /// </summary>
        /// <param name="inBytes">Bytes to decrypt</param>
        /// <param name="inKey">Key to decrypt</param>
        /// <returns>Decrypted bytes</returns>
        public byte[] decryptBytes(byte[] inBytes, byte[] inKey) {
            return new crypt.Decryptor().DecryptByteArray(inBytes, inKey);
        }

        /// <summary>
        /// Encrypts the file with a key and saves the result.
        /// </summary>
        /// <param name="inPath">File to process</param>
        /// <param name="outPath">Location to save processed data</param>
        /// <param name="inKey">Key to encrypt, should be 32 bytes long</param>
        public void encryptFile(string inPath, string outPath, byte[] inKey) {
            crypt.Encryptor tmp = new crypt.Encryptor();
            System.IO.File.WriteAllBytes(outPath, tmp.EncryptByteArray(System.IO.File.ReadAllBytes(inPath), inKey));
        }

        /// <summary>
        /// Decrypts the file with the a and saves the result.
        /// </summary>
        /// <param name="inPath">File to process</param>
        /// <param name="outPath">Location to save processed data</param>
        /// <param name="inKey">Key to decrypt</param>
        public void decryptFile(string inPath, string outPath, byte[] inKey) {
            crypt.Decryptor tmp = new crypt.Decryptor();
            System.IO.File.WriteAllBytes(outPath, tmp.DecryptByteArray(System.IO.File.ReadAllBytes(inPath), inKey));
        }

        /// <summary>
        /// Encrypts a string with a key.
        /// </summary>
        /// <param name="inString">Input string</param>
        /// <param name="inKey">Key to encrypt, should be 32 bytes long</param>
        /// <returns>Encrypted string as base64</returns>
        public string encryptString(string inString, byte[] inKey) {
            return System.Convert.ToBase64String(new crypt.Encryptor().EncryptByteArray(System.Text.Encoding.ASCII.GetBytes(inString), inKey));
        }

        /// <summary>
        /// Decrypts a base64 string with a key.
        /// </summary>
        /// <param name="inString">Input string</param>
        /// <param name="inKey">Key to decrypt</param>
        /// <returns>Decrypted string</returns>
        public string decryptString(string inString, byte[] inKey) {
            return System.Text.Encoding.ASCII.GetString(new crypt.Decryptor().DecryptByteArray(System.Convert.FromBase64String(inString), inKey));
        }
    }
}