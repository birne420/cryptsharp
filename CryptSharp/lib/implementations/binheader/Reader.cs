namespace CryptSharp.lib.implementations.binheader {
    /// <summary>
    /// Removes binary signature.
    /// </summary>
    public class Reader {
        /// <summary>
        /// File content as byte array.
        /// </summary>
        private byte[] FileContent;

        /// <summary>
        /// Binary signature.
        /// </summary>
        private BinarySignature Signature;

        /// <summary>
        /// Output data as byte array.
        /// </summary>
        private byte[] Output;

        /// <summary>
        /// Header bytes.
        /// </summary>
        private byte[] SignatureHeader;
        
        /// <summary>
        /// Footer bytes.
        /// </summary>
        private byte[] SignatureFooter;

        /// <summary>
        /// Processes input data.
        /// </summary>
        /// <param name="FileContent">Signed data bytes</param>
        /// <param name="Signature">Signature to neutralize</param>
        public Reader(byte[] FileContent, BinarySignature Signature) {
            this.FileContent = FileContent;
            this.Signature = Signature;

            this.SignatureHeader = new byte[this.Signature.getHeader().Length];
            this.SignatureFooter = new byte[this.Signature.getFooter().Length];

            System.Array.Copy(this.FileContent, 0, this.SignatureHeader, 0, this.Signature.getHeader().Length);
            System.Array.Copy(this.FileContent, this.FileContent.Length - this.Signature.getFooter().Length, SignatureFooter, 0, this.Signature.getFooter().Length);

            if(System.Linq.Enumerable.SequenceEqual(this.Signature.getHeader(), this.SignatureHeader)) {
                if (System.Linq.Enumerable.SequenceEqual(this.Signature.getFooter(), this.SignatureFooter)) {
                    this.Output = new byte[this.FileContent.Length - this.Signature.getHeader().Length - this.Signature.getFooter().Length];
                    System.Array.Copy(this.FileContent, this.Signature.getHeader().Length, this.Output, 0, this.FileContent.Length - this.Signature.getHeader().Length - this.Signature.getFooter().Length);
                } else {
                    throw new System.ArgumentOutOfRangeException();
                }
            } else {
                throw new System.ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns neutralized binary signature.
        /// </summary>
        /// <returns>Neutralized binary data</returns>
        public byte[] getContentBytes() {
            return this.Output;
        }

        /// <summary>
        /// Returns neutralized binary signature.
        /// </summary>
        /// <returns>Neutralized string</returns>
        public string getContentString() {
            return System.Text.Encoding.ASCII.GetString(this.Output);
        }
    }
}