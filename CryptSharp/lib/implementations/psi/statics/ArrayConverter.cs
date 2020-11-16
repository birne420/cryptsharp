namespace CryptSharp.lib.implementations.psi.statics {
    /// <summary>
    /// Provides array converter methods.
    /// </summary>
    public static class ArrayConverter {
        /// <summary>
        /// Converts an entered integer array to a byte array.
        /// </summary>
        /// <param name="inputData">Input integer array</param>
        /// <returns>Output byte array</returns>
        public static byte[] convertIntToByte(int[] inputData) {
            byte[] outputData = new byte[inputData.Length];
            for (int i = 0; i < inputData.Length; i++) {
                outputData[i] = (byte)inputData[i];
            }
            return outputData;
        }

        /// <summary>
        /// Converts an entered byte array to an integer array.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        /// <returns>Output integer array</returns>
        public static int[] convertByteToInt(byte[] inputData) {
            int[] outputData = new int[inputData.Length];
            for (int i = 0; i < inputData.Length; i++) {
                outputData[i] = (int)inputData[i];
            }
            return outputData;
        }
    }
}