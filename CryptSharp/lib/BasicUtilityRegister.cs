using CryptSharp.lib.common.utility;
namespace CryptSharp.lib {
    /// <summary>
    /// Provides instances for each utility class.
    /// </summary>
    public class BasicUtilityRegister {
        /// <summary>
        /// Base64 encoding/decoding.
        /// </summary>
        public Base64 base64;

        /// <summary>
        /// Basic IO utility.
        /// </summary>
        public BasicIO basic_io;

        /// <summary>
        /// Provides PBKDF2 and RSA key generation.
        /// </summary>
        public KeyGenerator key_generator;

        /// <summary>
        /// Some basic rng functions.
        /// </summary>
        public Randomizer randomizer;

        /// <summary>
        /// Initializes all required instances.
        /// </summary>
        public BasicUtilityRegister() {
            base64 = new Base64();
            basic_io = new BasicIO();
            key_generator = new KeyGenerator();
            randomizer = new Randomizer();
        }

        /// <summary>
        /// Converts a ByteArray into a HEX string.
        /// </summary>
        /// <param name="inBytes">Bytes to convert</param>
        /// <param name="outUC">Use Uppercase</param>
        /// <returns>HEX string</returns>
        public string convertBytesToHex(byte[] inBytes, bool outUC = false) {
            return GeneralUtility.toHex(inBytes, outUC);
        }

        /// <summary>
        /// Visualizes a ByteArray for console output.
        /// </summary>
        /// <param name="inBytes">Bytes to display</param>
        /// <param name="hexFormat">Use HEX format</param>
        /// <param name="outBytes">Maximum length of output</param>
        /// <returns>ByteArray string</returns>
        public string visualizeBytes(byte[] inBytes, bool hexFormat = true, int outBytes = -1) {
            return GeneralUtility.visualizeBytes(inBytes, hexFormat, outBytes);
        }

        /// <summary>
        /// Visualizes a StringArray for console output.
        /// </summary>
        /// <param name="inArray">Strings to display</param>
        /// <returns>All strings combined to one string</returns>
        public string visualizeStringArray(string[] inArray) {
            return GeneralUtility.visualizeStringArray(inArray);
        }
    }
}