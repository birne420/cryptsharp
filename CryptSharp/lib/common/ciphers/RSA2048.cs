namespace CryptSharp.lib.common.ciphers {
    /// <summary>
    /// Interface working with RSA CryptoServiceProvider class.
    /// </summary>
    public class RSA2048 {
        /// <summary>
        /// Specified CryptoServiceProvider.
        /// </summary>
        private System.Security.Cryptography.RSACryptoServiceProvider csp;


        /// <summary>
        /// RSA-Encryption.
        /// </summary>
        public RSA2048() {
            csp = new System.Security.Cryptography.RSACryptoServiceProvider();
        }

        /// <summary>
        /// Creates a new CSP to generate a new RSA key pair.
        /// </summary>
        public void shuffle() {
            csp = new System.Security.Cryptography.RSACryptoServiceProvider();
        }

        /// <summary>
        /// Imports key information.
        /// </summary>
        /// <param name="inKeyInformation">new key information</param>
        public void setNewKeyInformation(System.Security.Cryptography.RSAParameters inKeyInformation) {
            csp.ImportParameters(inKeyInformation);
        }

        /// <summary>
        /// Imports key information via xml.
        /// </summary>
        /// <param name="inKeyXML">new key information as xml string</param>
        public void setNewKeyInformationXML(string inKeyXML) {
            csp.FromXmlString(inKeyXML);
        }

        /// <summary>
        /// Exports private key information.
        /// </summary>
        /// <returns>private key information</returns>
        public System.Security.Cryptography.RSAParameters getPrivateKeyInformation() {
            return csp.ExportParameters(true);
        }

        /// <summary>
        /// Exports private key information as xml.
        /// </summary>
        /// <returns>private key information as xml string</returns>
        public string getPrivateKeyInformationXML() {
            return csp.ToXmlString(true);
        }

        /// <summary>
        /// Exports public key information.
        /// </summary>
        /// <returns>public key information</returns>
        public System.Security.Cryptography.RSAParameters getPublicKeyInformation() {
            return csp.ExportParameters(false);
        }

        /// <summary>
        /// Exports public key information as xml.
        /// </summary>
        /// <returns>public key information as xml string</returns>
        public string getPublicKeyInformationXML() {
            return csp.ToXmlString(false);
        }

        /// <summary>
        /// Encrypts a byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="fOAEP">'true' to perform direct RSA encryption using OAEP padding, 'false' to use PKCS#1 v1.5 padding</param>
        /// <returns>Encrypted byte array</returns>
        public byte[] encryptBytes(byte[] inBytes, bool fOAEP = true) {
            return csp.Encrypt(inBytes, fOAEP);
        }

        /// <summary>
        /// Decrypts a byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="fOAEP">'true' to perform direct RSA decryption using OAEP padding, 'false' to use PKCS#1 v1.5 padding</param>
        /// <returns>Decrypted byte array</returns>
        public byte[] decryptBytes(byte[] inBytes, bool fOAEP = true) {
            return csp.Decrypt(inBytes, fOAEP);
        }
    }
}