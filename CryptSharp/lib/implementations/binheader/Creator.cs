namespace CryptSharp.lib.implementations.binheader {
    /// <summary>
    /// Applies binary signature.
    /// </summary>
    public class Creator {
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
        /// Processes input data.
        /// </summary>
        /// <param name="FileContent">Plain data bytes</param>
        /// <param name="Signature">Signature to apply</param>
        public Creator(byte[] FileContent, BinarySignature Signature) {
            this.FileContent = FileContent;
            this.Signature = Signature;

            this.Output = new byte[this.Signature.getHeader().Length + this.FileContent.Length + this.Signature.getFooter().Length];
            System.Array.Copy(this.Signature.getHeader(), 0, this.Output, 0, this.Signature.getHeader().Length);
            System.Array.Copy(this.FileContent, 0, this.Output, this.Signature.getHeader().Length, this.FileContent.Length);
            System.Array.Copy(this.Signature.getFooter(), 0, this.Output, this.Signature.getHeader().Length + this.FileContent.Length, this.Signature.getFooter().Length);
        }

        /// <summary>
        /// Processes input data.
        /// </summary>
        /// <param name="FileContent">Plain string</param>
        /// <param name="Signature">Signature to apply</param>
        public Creator(string FileContent, BinarySignature Signature) {
            this.FileContent = System.Text.Encoding.ASCII.GetBytes(FileContent);
            this.Signature = Signature;

            this.Output = new byte[this.Signature.getHeader().Length + this.FileContent.Length + this.Signature.getFooter().Length];
            System.Array.Copy(this.Signature.getHeader(), 0, this.Output, 0, this.Signature.getHeader().Length);
            System.Array.Copy(this.FileContent, 0, this.Output, this.Signature.getHeader().Length, this.FileContent.Length);
            System.Array.Copy(this.Signature.getFooter(), 0, this.Output, this.Signature.getHeader().Length + this.FileContent.Length, this.Signature.getFooter().Length);
        }

        /// <summary>
        /// Returns applied binary signature.
        /// </summary>
        /// <returns>Applied binary signature</returns>
        public byte[] getContent() {
            return this.Output;
        }
    }
}