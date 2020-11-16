namespace CryptSharp.lib.common.utility {
    /// <summary>
    /// System io interface.
    /// </summary>
    public class BasicIO {
        /// <summary>
        /// Creates a new directory.
        /// </summary>
        /// <param name="inPath">Directory path</param>
        /// <returns>'true', if directory already exists</returns>
        public bool mkDir(string inPath) {
            if (System.IO.Directory.Exists(inPath)) {
                return true;
            } else {
                System.IO.Directory.CreateDirectory(inPath);
                return false;
            }
        }

        /// <summary>
        /// Check if directory exists.
        /// </summary>
        /// <param name="inPath">Path to check</param>
        /// <returns>'true', if directory exists</returns>
        public bool dirExists(string inPath) {
            return System.IO.Directory.Exists(inPath);
        }

        /// <summary>
        /// Check if file exists.
        /// </summary>
        /// <param name="inPath">File to check</param>
        /// <returns>'true', if file exists</returns>
        public bool fileExists(string inPath) {
            return System.IO.File.Exists(inPath);
        }
    }
}
