namespace CryptSharp.lib.common {
    /// <summary>
    /// Interface for file compression/extraction.
    /// </summary>
    public class FileCompression {
        /// <summary>
        /// Compresses a directory to a ZIP archive.
        /// </summary>
        /// <param name="inPathDirectory">Directory to compress</param>
        /// <param name="outPathFile">ZIP archive path</param>
        /// <returns>'true', if done</returns>
        public bool compressDirectory(string inPathDirectory, string outPathFile) {
            System.IO.Compression.ZipFile.CreateFromDirectory(inPathDirectory, outPathFile);
            return true;
        }

        /// <summary>
        /// Extracts a ZIP archive to a directory.
        /// </summary>
        /// <param name="inPathFile">ZIP archive to extract</param>
        /// <param name="outPathDirectory">Directory path</param>
        /// <returns>'true', if done</returns>
        public bool extractArchive(string inPathFile, string outPathDirectory) {
            System.IO.Compression.ZipFile.ExtractToDirectory(inPathFile, outPathDirectory);
            return true;
        }
    }
}