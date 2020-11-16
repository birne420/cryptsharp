using CryptSharp.lib.common.hashalgorithms;
namespace CryptSharp.lib {
    /// <summary>
    /// Provides instances for each hash algorithm.
    /// </summary>
    public class HashAlgorithmRegister {
        /// <summary>
        /// Provides PSI hash algorithm.
        /// </summary>
        public implementations.psi.utility.UsageHelper_Hash psi_128bit;

        /// <summary>
        /// Provides MD5 hash algorithm.
        /// </summary>
        public MD5 md5;

        /// <summary>
        /// Provides MD5 hash algorithm (hmac salt and pepper).
        /// </summary>
        public MD5HMAC md5hmac;

        /// <summary>
        /// Provides RIPEMD160 hash algorithm.
        /// </summary>
        public RIPEMD160 ripemd160;

        /// <summary>
        /// Provides RIPEMD160 hash algorithm (hmac salt and pepper).
        /// </summary>
        public RIPEMD160HMAC ripemd160hmac;

        /// <summary>
        /// Provides SHA1 hash algorithm.
        /// </summary>
        public SHA1 sha1;

        /// <summary>
        /// Provides SHA1 hash algorithm (hmac salt and pepper).
        /// </summary>
        public SHA1HMAC sha1hmac;

        /// <summary>
        /// Provides SHA256 hash algorithm.
        /// </summary>
        public SHA256 sha256;

        /// <summary>
        /// Provides SHA256 hash algorithm (hmac salt and pepper).
        /// </summary>
        public SHA256HMAC sha256hmac;

        /// <summary>
        /// Provides SHA384 hash algorithm.
        /// </summary>
        public SHA384 sha384;

        /// <summary>
        /// Provides SHA384 hash algorithm (hmac salt and pepper).
        /// </summary>
        public SHA384HMAC sha384hmac;

        /// <summary>
        /// Provides SHA512 hash algorithm.
        /// </summary>
        public SHA512 sha512;

        /// <summary>
        /// Provides SHA512 hash algorithm (hmac salt and pepper).
        /// </summary>
        public SHA512HMAC sha512hmac;

        /// <summary>
        /// Initializes all required instances.
        /// </summary>
        public HashAlgorithmRegister() {
            psi_128bit = new implementations.psi.utility.UsageHelper_Hash();
            md5 = new MD5();
            md5hmac = new MD5HMAC();
            ripemd160 = new RIPEMD160();
            ripemd160hmac = new RIPEMD160HMAC();
            sha1 = new SHA1();
            sha1hmac = new SHA1HMAC();
            sha256 = new SHA256();
            sha256hmac = new SHA256HMAC();
            sha384 = new SHA384();
            sha384hmac = new SHA384HMAC();
            sha512 = new SHA512();
            sha512hmac = new SHA512HMAC();
        }
    }
}
