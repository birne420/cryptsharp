namespace CryptSharp.lib.implementations.psi.statics {
    /// <summary>
    /// Contains dataFinishingToken as readonly constant.
    /// </summary>
    public static class Definitions {
        /// <summary>
        /// The DataFinishingToken is attached to the entered data before encryption.
        /// This ensures that all bytes up to this token are decrypted during decryption or/and that the decryption was successful. Length: 32.
        /// </summary>
        public static readonly byte[] dataFinishingToken = new byte[] { 0x5B, 0x45, 0x4E, 0x44, 0x5F, 0x4F, 0x46, 0x5F, 0x44, 0x41, 0x54, 0x41, 0x5F, 0x52, 0x45, 0x41, 0x43, 0x48, 0x45, 0x44, 0x3A, 0x28, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x29, 0x5D };
    }
}