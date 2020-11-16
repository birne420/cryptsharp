using System.Runtime.InteropServices;
namespace CryptSharp.lib.common {
    /// <summary>
    /// Manages INI config files.
    /// </summary>
    public class IniFile {

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, System.Text.StringBuilder RetVal, int Size, string FilePath);

        /// <summary>
        /// Writes any value to an INI config file.
        /// </summary>
        /// <param name="inPath">INI path</param>
        /// <param name="inSection">INI section</param>
        /// <param name="inKey">INI key</param>
        /// <param name="inValue">Value to store</param>
        public void writeValue(string inPath, string inSection, string inKey, string inValue) {
            WritePrivateProfileString(inSection, inKey, inValue, inPath);
        }

        /// <summary>
        /// Ready any value from an INI config file.
        /// </summary>
        /// <param name="inPath">INI path</param>
        /// <param name="inSection">INI section</param>
        /// <param name="inKey">INI key</param>
        /// <param name="standardValue">Value to return if no value is found</param>
        /// <returns>Value as string</returns>
        public string readValue(string inPath, string inSection, string inKey, string standardValue = "") {
            System.Text.StringBuilder retVal = new System.Text.StringBuilder(255);
            GetPrivateProfileString(inSection, inKey, standardValue, retVal, 255, inPath);
            return retVal.ToString();
        }

        /// <summary>
        /// Deletes a section from an INI config file.
        /// </summary>
        /// <param name="inPath">INI path</param>
        /// <param name="inSection">INI section to remove</param>
        public void deleteSection(string inPath, string inSection = null) {
            WritePrivateProfileString(inSection, null, null, inPath);
        }

        /// <summary>
        /// Deletes a value from an INI config file.
        /// </summary>
        /// <param name="inPath">INI path</param>
        /// <param name="inSection">INI section</param>
        /// <param name="inKey">INI key to remove</param>
        public void deleteKey(string inPath, string inSection, string inKey) {
            WritePrivateProfileString(inSection, inKey, null, inPath);
        }

        /// <summary>
        /// Checks if an INI file contains a given key.
        /// </summary>
        /// <param name="inPath">INI path</param>
        /// <param name="inSection">INI section</param>
        /// <param name="inKey">INI key to check</param>
        /// <returns>'true', if key exists</returns>
        public bool keyExists(string inPath, string inSection, string inKey) {
            return readValue(inPath, inSection, inKey).Length > 0;
        }
    }
}
