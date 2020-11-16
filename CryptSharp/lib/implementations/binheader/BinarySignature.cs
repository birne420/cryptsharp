namespace CryptSharp.lib.implementations.binheader {
    /// <summary>
    /// Content management of signature.
    /// </summary>
    public class BinarySignature {
        /// <summary>
        /// Signature header.
        /// </summary>
        private byte[] ByteHeader;

        /// <summary>
        /// Signature footer.
        /// </summary>
        private byte[] ByteFooter;

        /// <summary>
        /// Binary header/footer signature class.
        /// </summary>
        /// <param name="Header">Specified header</param>
        /// <param name="Footer">Specified footer</param>
        public BinarySignature(byte[] Header, byte[] Footer) {
            this.ByteHeader = Header;
            this.ByteFooter = Footer;
        }

        /// <summary>
        /// Returns header.
        /// </summary>
        /// <returns>Output byte array</returns>
        public byte[] getHeader() {
            return this.ByteHeader;
        }

        /// <summary>
        /// Returns footer.
        /// </summary>
        /// <returns>Output byte array</returns>
        public byte[] getFooter() {
            return this.ByteFooter;
        }
    }
}