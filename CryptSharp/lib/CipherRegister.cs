using CryptSharp.lib.common.ciphers;
namespace CryptSharp.lib {
    /// <summary>
    /// Provides instances for each cipher.
    /// </summary>
    public class CipherRegister {
        /// <summary>
        /// Provides AES encryption.
        /// </summary>
        public AES256 aes256;

        /// <summary>
        /// Provides DES encryption.
        /// </summary>
        public DES des;

        /// <summary>
        /// Provides PSI encryption.
        /// </summary>
        public implementations.psi.utility.UsageHelper_Crypto psi_128bit;

        /// <summary>
        /// Provides RSA encryption.
        /// </summary>
        public RSA2048 rsa2048;

        /// <summary>
        /// Provides TripleDES encryption.
        /// </summary>
        public TripleDES tripledes;

        /// <summary>
        /// Initializes all required instances.
        /// </summary>
        public CipherRegister() {
            aes256 = new AES256();
            des = new DES();
            psi_128bit = new implementations.psi.utility.UsageHelper_Crypto();
            rsa2048 = new RSA2048();
            tripledes = new TripleDES();
        }
    }
}