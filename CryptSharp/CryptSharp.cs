namespace CryptSharp {
    /// <summary>
    /// Create an instance of this class to access the library.
    /// </summary>
    public class CryptSharp {
        /// <summary>
        /// Available ciphers: AES, DES, RSA, TripleDES, PSI.
        /// </summary>
        public lib.CipherRegister ciphers;

        /// <summary>
        /// Available hash algorithms: MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512, PSI.
        /// </summary>
        public lib.HashAlgorithmRegister hash_algorithms;

        /// <summary>
        /// Available utility: Base64, some io, Binary headers, file compression, ini config management, key generation, wmi interface, randomizer, registry access.
        /// </summary>
        public lib.BasicUtilityRegister utils;

        /// <summary>
        /// Binary header.
        /// </summary>
        public lib.common.BinHeader binary_header;

        /// <summary>
        /// ZIP archive compression and extraction.
        /// </summary>
        public lib.common.FileCompression file_compression;

        /// <summary>
        /// INI config file management.
        /// </summary>
        public lib.common.IniFile ini_file;

        /// <summary>
        /// Registry access.
        /// </summary>
        public lib.common.RegistryManager registry;

        /// <summary>
        /// PC information based on WMI.
        /// </summary>
        public lib.common.WmiInterface wmi_interface;

        /// <summary>
        /// Current version string.
        /// </summary>
        private readonly string _version = "beta_19";

        /// <summary>
        /// Author alias.
        /// </summary>
        private readonly string _author = "pappeBOAH";

        /// <summary>
        /// Create an instance of this class to access the library.
        /// </summary>
        public CryptSharp() {
            ciphers = new lib.CipherRegister();
            hash_algorithms = new lib.HashAlgorithmRegister();
            utils = new lib.BasicUtilityRegister();
            binary_header = new lib.common.BinHeader();
            file_compression = new lib.common.FileCompression();
            ini_file = new lib.common.IniFile();
            registry = new lib.common.RegistryManager();
            wmi_interface = new lib.common.WmiInterface();
        }

        /// <summary>
        /// Returns the current version of the library.
        /// </summary>
        /// <returns>String contains current version</returns>
        public string libVersion() {
            return this._version;
        }

        /// <summary>
        /// Information and features of the library.
        /// </summary>
        /// <returns>String contains library info</returns>
        public string libInfo() {
            System.Text.StringBuilder infoStream = new System.Text.StringBuilder();
            infoStream.AppendLine("===== ===== ===== ===== ===== ===== =====");
            infoStream.AppendLine("  CryptSharp (version " + this._version + ", developed by " + this._author + ")");
            infoStream.AppendLine("===== ===== ===== ===== ===== ===== =====");
            infoStream.AppendLine("  * Supported ciphers:");
            infoStream.AppendLine("    - AES 256");
            infoStream.AppendLine("    - DES");
            infoStream.AppendLine("    - PSI 128");
            infoStream.AppendLine("    - RSA 2048");
            infoStream.AppendLine("    - Triple DES");
            infoStream.AppendLine("  * Supported hash algorithms (plus hmac):");
            infoStream.AppendLine("    - MD5");
            infoStream.AppendLine("    - RIPEMD 160");
            infoStream.AppendLine("    - SHA1");
            infoStream.AppendLine("    - SHA 256");
            infoStream.AppendLine("    - SHA 384");
            infoStream.AppendLine("    - SHA 512");
            infoStream.AppendLine("  * Utility functions:");
            infoStream.AppendLine("    - Base64");
            infoStream.AppendLine("    - Basic IO functions");
            infoStream.AppendLine("    - Binary headers");
            infoStream.AppendLine("    - File compression");
            infoStream.AppendLine("    - INI file management");
            infoStream.AppendLine("    - Key generation");
            infoStream.AppendLine("    - PC information/WMI support");
            infoStream.AppendLine("    - Randomizer**");
            infoStream.AppendLine("    - Registry access**");
            infoStream.AppendLine("  ** Rework planned");
            infoStream.Append("===== ===== ===== ===== ===== ===== =====");
            return infoStream.ToString();
        }
    }
}

/*
 * TODO:
 * FileEncryption + Streams
 */
