namespace CryptSharp.lib.common.utility {
    /// <summary>
    /// RNG functions.
    /// </summary>
    public class Randomizer {
        /// <summary>
        /// RNG CSP.
        /// </summary>
        System.Security.Cryptography.RNGCryptoServiceProvider rngcsp;

        /// <summary>
        /// System-RNG instance.
        /// </summary>
        System.Random rng;

        /// <summary>
        /// Initializes basic rng functions.
        /// </summary>
        public Randomizer() {
            rngcsp = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng = new System.Random();
        }

        /// <summary>
        /// Returns a random integer in a given range.
        /// </summary>
        /// <param name="inMin">Minimum range</param>
        /// <param name="inMax">Maximum range</param>
        /// <returns>Random Integer</returns>
        public int getRandomInteger(int inMin, int inMax) {
            return rng.Next(inMin, inMax);
        }

        /// <summary>
        /// Returns a random string with a given length.
        /// </summary>
        /// <param name="inStrLength">Length of random string</param>
        /// <param name="useLCOnly">Length of random string</param>
        /// <returns>Random string</returns>
        public string getRandomString(int inStrLength, bool useLCOnly = false) {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            if (useLCOnly) alpha = "abcdefghijklmnopqrstuvwxyz0123456789";
            string outStr = "";
            for (int i = 0; i < inStrLength; i++) {
                outStr += alpha[rng.Next(0, alpha.Length)];
            }
            return outStr;
        }

        /// <summary>
        /// Returns a random byte array.
        /// </summary>
        /// <param name="inByteArrayLength">Length of random bytes</param>
        /// <returns>Random byte array</returns>
        public byte[] getRandomBytes(int inByteArrayLength) {
            byte[] outBytes = new byte[inByteArrayLength];
            rngcsp.GetBytes(outBytes, 0, inByteArrayLength);
            return outBytes;
        }
    }
}