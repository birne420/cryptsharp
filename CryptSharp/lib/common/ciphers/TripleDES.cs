namespace CryptSharp.lib.common.ciphers {
    /// <summary>
    /// Interface working with TripleDES CryptoServiceProvider class.
    /// </summary>
    public class TripleDES {
        /// <summary>
        /// Specified CryptoServiceProvider.
        /// </summary>
        private System.Security.Cryptography.TripleDESCryptoServiceProvider csp;

        /// <summary>
        /// CipherMode.
        /// </summary>
        private System.Security.Cryptography.CipherMode cipherMode;

        /// <summary>
        /// PaddingMode.
        /// </summary>
        private System.Security.Cryptography.PaddingMode paddingMode;

        /// <summary>
        /// TripleDES-Encryption.
        /// </summary>
        public TripleDES() {
            updateCipherMode();
            updatePadding();
        }

        /// <summary>
        /// Sets the CipherMode.
        /// </summary>
        /// <param name="cipherMode">new CipherMode</param>
        public void updateCipherMode(System.Security.Cryptography.CipherMode cipherMode = System.Security.Cryptography.CipherMode.CBC) {
            this.cipherMode = cipherMode;
        }

        /// <summary>
        /// Sets the PaddingMode.
        /// </summary>
        /// <param name="paddingMode">new PaddingMode</param>
        public void updatePadding(System.Security.Cryptography.PaddingMode paddingMode = System.Security.Cryptography.PaddingMode.PKCS7) {
            this.paddingMode = paddingMode;
        }

        /// <summary>
        /// Creates the CryptoServiceProvider based on the PBKDF2.
        /// </summary>
        /// <param name="inPBKDF2">Input PBKDF2</param>
        /// <returns>CSP</returns>
        private System.Security.Cryptography.TripleDESCryptoServiceProvider createCSP(System.Security.Cryptography.Rfc2898DeriveBytes inPBKDF2) {
            inPBKDF2.Reset();
            csp = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            csp.Mode = this.cipherMode;
            csp.Padding = this.paddingMode;
            csp.Key = inPBKDF2.GetBytes(csp.KeySize / 8);
            csp.IV = inPBKDF2.GetBytes(csp.BlockSize / 8);
            return csp;
        }

        /// <summary>
        /// ByteEncryption based on the PBKDF2.
        /// </summary>
        /// <param name="inBytes">Bytes to encrypt</param>
        /// <param name="inPBKDF2">Input PBKDF2</param>
        /// <returns>Encrypted bytes</returns>
        public byte[] encryptBytes(byte[] inBytes, System.Security.Cryptography.Rfc2898DeriveBytes inPBKDF2) {
            byte[] outBytes = null;
            System.Security.Cryptography.ICryptoTransform cryptoTransform = createCSP(inPBKDF2).CreateEncryptor();
            using (System.IO.MemoryStream mStream = new System.IO.MemoryStream()) {
                using (System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(mStream, cryptoTransform, System.Security.Cryptography.CryptoStreamMode.Write)) {
                    cStream.Write(inBytes, 0, inBytes.Length);
                    cStream.FlushFinalBlock();
                    cStream.Close();
                }
                outBytes = mStream.ToArray();
            }
            return outBytes;
        }

        /// <summary>
        /// ByteDecryption based on the PBKDF2.
        /// </summary>
        /// <param name="inBytes">Bytes to decrypt</param>
        /// <param name="inPBKDF2">Input PBKDF2</param>
        /// <returns>Decrypted bytes</returns>
        public byte[] decryptBytes(byte[] inBytes, System.Security.Cryptography.Rfc2898DeriveBytes inPBKDF2) {
            byte[] outBytes = null;
            System.Security.Cryptography.ICryptoTransform cryptoTransform = createCSP(inPBKDF2).CreateDecryptor();
            using (System.IO.MemoryStream mStream = new System.IO.MemoryStream()) {
                using (System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(mStream, cryptoTransform, System.Security.Cryptography.CryptoStreamMode.Write)) {
                    cStream.Write(inBytes, 0, inBytes.Length);
                    cStream.FlushFinalBlock();
                    cStream.Close();
                }
                outBytes = mStream.ToArray();
            }
            return outBytes;
        }
    }
}