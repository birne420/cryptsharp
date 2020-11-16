namespace CryptSharp.lib.common.utility {
    /// <summary>
    /// Provides general utility methods.
    /// </summary>
    public static class GeneralUtility {
        /// <summary>
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="inBytes">Bytes to process</param>
        /// <param name="outUc">Uppercase on/off</param>
        /// <returns>HEX string</returns>
        public static string toHex(byte[] inBytes, bool outUc = false) {
            System.Text.StringBuilder result = new System.Text.StringBuilder(inBytes.Length * 2);
            for (int i = 0; i < inBytes.Length; i++) {
                result.Append(inBytes[i].ToString(outUc ? "X2" : "x2"));
            }
            return result.ToString();
        }

        /// <summary>
        /// Visualizes a byte array.
        /// </summary>
        /// <param name="inBytes">Bytes to display</param>
        /// <param name="hexFormat">HEX format on/off</param>
        /// <param name="outBytes">Number of output bytes</param>
        /// <returns>String with bytes</returns>
        public static string visualizeBytes(byte[] inBytes, bool hexFormat = true, int outBytes = -1) {
            System.Text.StringBuilder result = new System.Text.StringBuilder("[");
            if (outBytes == -1) {
                if (hexFormat) {
                    for (int i = 0; i < inBytes.Length; i++) {
                        result.Append(inBytes[i].ToString("x2") + " ");
                    }
                } else {
                    for (int i = 0; i < inBytes.Length; i++) {
                        result.Append(inBytes[i].ToString() + " ");
                    }
                }
            } else {
                if (hexFormat) {
                    for (int i = 0; i < outBytes; i++) {
                        result.Append(inBytes[i].ToString("x2") + " ");
                    }
                } else {
                    for (int i = 0; i < outBytes; i++) {
                        result.Append(inBytes[i].ToString() + " ");
                    }
                }
                result.Append("...");
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString() + "]";
        }

        /// <summary>
        /// Visualizes a string array.
        /// </summary>
        /// <param name="inArray">Strings to display</param>
        /// <returns>String with strings</returns>
        public static string visualizeStringArray(string[] inArray) {
            System.Text.StringBuilder result = new System.Text.StringBuilder("[\n");
            for (int i = 0; i < inArray.Length; i++) {
                result.AppendLine("  [" + i + "] " + inArray[i]);
            }
            return result.ToString() + "]\n";
        }
    }
}