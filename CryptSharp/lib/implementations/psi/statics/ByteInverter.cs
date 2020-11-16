namespace CryptSharp.lib.implementations.psi.statics {
    /// <summary>
    /// ByteInverter class.
    /// </summary>
    public static class ByteInverter {
        /// <summary>
        /// Inverts all bytes of the entered byte array.
        /// </summary>
        /// <param name="inputData">Input bytes</param>
        /// <returns>Output bytes</returns>
        public static byte[] invertBytes(byte[] inputData) {
            byte minuend = 255;
            byte[] outputData = new byte[inputData.Length];
            for(int i = 0; i < inputData.Length; i++) {
                outputData[i] = (byte)(minuend - inputData[i]);
            }
            return outputData;
        }
    }
}