namespace CryptSharp.lib.common {
    /// <summary>
    /// Manages binary signatures (header/footer).
    /// </summary>
    public class BinHeader {
        /// <summary>
        /// Applies a binary header/footer to a byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="inHeader">Header bytes</param>
        /// <param name="inFooter">Footer bytes</param>
        /// <returns>Byte array with applied header/footer</returns>
        public byte[] createBinHeaderFromBytes(byte[] inBytes, byte[] inHeader, byte[] inFooter) {
            implementations.binheader.BinarySignature signature = new implementations.binheader.BinarySignature(inHeader, inFooter);
            implementations.binheader.Creator creator = new implementations.binheader.Creator(inBytes, signature);

            return creator.getContent();
        }

        /// <summary>
        /// Applies a binary header/footer to a string.
        /// </summary>
        /// <param name="InputString">Input string</param>
        /// <param name="inHeader">Header bytes</param>
        /// <param name="inFooter">Footer bytes</param>
        /// <returns>Byte array with applied header/footer</returns>
        public byte[] createBinHeaderFromString(string InputString, byte[] inHeader, byte[] inFooter) {
            implementations.binheader.BinarySignature signature = new implementations.binheader.BinarySignature(inHeader, inFooter);
            implementations.binheader.Creator creator = new implementations.binheader.Creator(InputString, signature);

            return creator.getContent();
        }

        /// <summary>
        /// Removes the applied binary header/footer from given byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="inHeader">Header bytes</param>
        /// <param name="inFooter">Footer bytes</param>
        /// <returns>Original byte array with neutralized header/footer</returns>
        public byte[] loadBinHeaderFromBytes(byte[] inBytes, byte[] inHeader, byte[] inFooter) {
            implementations.binheader.BinarySignature signature = new implementations.binheader.BinarySignature(inHeader, inFooter);
            implementations.binheader.Reader loader = new implementations.binheader.Reader(inBytes, signature);

            return loader.getContentBytes();
        }

        /// <summary>
        /// Removes the applied binary header/footer from given byte array.
        /// </summary>
        /// <param name="inBytes">Input bytes</param>
        /// <param name="inHeader">Header bytes</param>
        /// <param name="inFooter">Footer bytes</param>
        /// <returns>Original string with neutralized header/footer</returns>
        public string loadBinHeaderFromString(byte[] inBytes, byte[] inHeader, byte[] inFooter) {
            implementations.binheader.BinarySignature signature = new implementations.binheader.BinarySignature(inHeader, inFooter);
            implementations.binheader.Reader loader = new implementations.binheader.Reader(inBytes, signature);

            return loader.getContentString();
        }
    }
}