namespace CryptSharp.lib.common {
    /// <summary>
    /// Represents a registry value in ram.
    /// </summary>
    public class RegistryValue {
        /// <summary>
        /// Name of the registry value.
        /// </summary>
        public string valueName {
            get; set;
        }

        /// <summary>
        /// Type of the registry value.
        /// </summary>
        public Microsoft.Win32.RegistryValueKind valueKind {
            get; set;
        }

        /// <summary>
        /// Data of the registry value.
        /// </summary>
        public object valueData {
            get; set;
        }

        /// <summary>
        /// ToString override.
        /// </summary>
        /// <returns>String representation of the reg value</returns>
        public override string ToString() {
            return this.valueName + " = '" + this.valueData.ToString() + "', type = '" + this.valueKind.ToString() + "'";
        }

        /// <summary>
        /// Initializes the reg value with zero.
        /// </summary>
        public RegistryValue() {
            setRegValue(null, 0, null);
        }

        /// <summary>
        /// Manuel initialization.
        /// </summary>
        /// <param name="valueName">Name of the registry value</param>
        /// <param name="valueKind">Type of the registry value</param>
        /// <param name="valueData">Data of the registry value</param>
        public RegistryValue(string valueName, Microsoft.Win32.RegistryValueKind valueKind, object valueData) {
            setRegValue(valueName, valueKind, valueData);
        }

        /// <summary>
        /// Automatic initialization from registry by key and name.
        /// </summary>
        /// <param name="inKey">Registry key</param>
        /// <param name="valueName">Name to read</param>
        public RegistryValue(Microsoft.Win32.RegistryKey inKey, string valueName) {
            loadRegValue(inKey, valueName);
        }

        /// <summary>
        /// Sets all properties of the registry value.
        /// </summary>
        /// <param name="valueName">Name of the registry value</param>
        /// <param name="valueKind">Type of the registry value</param>
        /// <param name="valueData">Data of the registry value</param>
        public void setRegValue(string valueName, Microsoft.Win32.RegistryValueKind valueKind, object valueData) {
            this.valueName = valueName;
            this.valueKind = valueKind;
            this.valueData = valueData;
        }

        /// <summary>
        /// Automatic reading from registry by key and name.
        /// </summary>
        /// <param name="inKey">Registry key</param>
        /// <param name="valueName">Name to read</param>
        public void loadRegValue(Microsoft.Win32.RegistryKey inKey, string valueName) {
            this.valueName = valueName;
            this.valueKind = inKey.GetValueKind(valueName);
            this.valueData = inKey.GetValue(valueName);
        }

        /// <summary>
        /// Finally writes the registry value from ram to registry.
        /// </summary>
        /// <param name="inKey">Key to write value into</param>
        public void writeValue(Microsoft.Win32.RegistryKey inKey) {
            Microsoft.Win32.Registry.SetValue(inKey.ToString(), this.valueName, this.valueData, this.valueKind);
        }
    }

    /// <summary>
    /// Provides basic registry read and write functions.
    /// </summary>
    public class RegistryManager {
        /// <summary>
        /// Registry base key
        /// </summary>
        public readonly Microsoft.Win32.RegistryKey _HKEY_CLASSES_ROOT = Microsoft.Win32.Registry.ClassesRoot;

        /// <summary>
        /// Registry base key
        /// </summary>
        public readonly Microsoft.Win32.RegistryKey _HKEY_CURRENT_USER = Microsoft.Win32.Registry.CurrentUser;

        /// <summary>
        /// Registry base key
        /// </summary>
        public readonly Microsoft.Win32.RegistryKey _HKEY_LOCAL_MACHINE = Microsoft.Win32.Registry.LocalMachine;

        /// <summary>
        /// Registry base key
        /// </summary>
        public readonly Microsoft.Win32.RegistryKey _HKEY_USERS = Microsoft.Win32.Registry.Users;

        /// <summary>
        /// Registry base key
        /// </summary>
        public readonly Microsoft.Win32.RegistryKey _HKEY_CURRENT_CONFIG = Microsoft.Win32.Registry.ClassesRoot;

        /// <summary>
        /// Returns path of the given registry key as string.
        /// </summary>
        /// <param name="inKey">Key to convert</param>
        /// <returns>Registry path as string</returns>
        public string convert_RegistryKeyToString(Microsoft.Win32.RegistryKey inKey) {
            return inKey.ToString();
        }

        /// <summary>
        /// Returns registry key object from given string.
        /// </summary>
        /// <param name="inPath">Registry key path</param>
        /// <returns>RegistryKey object</returns>
        public Microsoft.Win32.RegistryKey convert_StringToRegistryKey(string inPath) {
            string[] splittedPath = inPath.Split('\\');
            Microsoft.Win32.RegistryKey matureKey;
            switch (splittedPath[0]) {
                case "HKEY_CLASSES_ROOT":
                    matureKey = Microsoft.Win32.Registry.ClassesRoot;
                    break;
                case "HKEY_CURRENT_USER":
                    matureKey = Microsoft.Win32.Registry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    matureKey = Microsoft.Win32.Registry.LocalMachine;
                    break;
                case "HKEY_USERS":
                    matureKey = Microsoft.Win32.Registry.Users;
                    break;
                case "HKEY_CURRENT_CONFIG":
                    matureKey = Microsoft.Win32.Registry.CurrentConfig;
                    break;
                default:
                    return null;
            }
            return matureKey.OpenSubKey(string.Join("\\", splittedPath, 1, splittedPath.Length - 1));
        }

        /// <summary>
        /// Creates a new key in registry.
        /// </summary>
        /// <param name="inMatureKey">Mature registry key</param>
        /// <param name="keyPath">Key path to create</param>
        /// <returns>RegistryKey object of the new key</returns>
        public Microsoft.Win32.RegistryKey key_create(Microsoft.Win32.RegistryKey inMatureKey, string keyPath) {
            return inMatureKey.CreateSubKey(keyPath, true);
        }

        /// <summary>
        /// Deletes a sub key.
        /// </summary>
        /// <param name="inMatureKey">Mature registry key</param>
        /// <param name="keyPath">Key path to delete</param>
        public void key_delete(Microsoft.Win32.RegistryKey inMatureKey, string keyPath) {
            inMatureKey.DeleteSubKeyTree(keyPath, false);
        }

        /// <summary>
        /// Returns a list of all sub key names.
        /// </summary>
        /// <param name="inParentKey">Registry key to read</param>
        /// <returns>List of strings</returns>
        public string[] key_list(Microsoft.Win32.RegistryKey inParentKey) {
            return inParentKey.GetSubKeyNames();
        }

        /// <summary>
        /// Combines a parent key and a relative path to a new registry object.
        /// </summary>
        /// <param name="inParentKey">Parent key</param>
        /// <param name="inKeyPath">Relative path</param>
        /// <returns>RegistryKey object</returns>
        public Microsoft.Win32.RegistryKey key_load(Microsoft.Win32.RegistryKey inParentKey, string inKeyPath) {
            return inParentKey.OpenSubKey(inKeyPath);
        }

        /// <summary>
        /// Creates a registry value in ram.
        /// </summary>
        /// <param name="valueName">Name of the registry value</param>
        /// <param name="valueData">Data of the registry value</param>
        /// <param name="valueKind">Kind of the registry value</param>
        /// <returns>RegistryValue key object</returns>
        public RegistryValue value_create(string valueName, object valueData = null, Microsoft.Win32.RegistryValueKind valueKind = 0) {
            return new RegistryValue(valueName, valueKind, valueData);
        }

        /// <summary>
        /// Deletes a registry value from registry.
        /// </summary>
        /// <param name="inMatureKey">Mature registry key</param>
        /// <param name="inKeyPath">Registry key path</param>
        /// <param name="valueName">Value to delete</param>
        public void value_delete(Microsoft.Win32.RegistryKey inMatureKey, string inKeyPath, string valueName) {
            inMatureKey.OpenSubKey(inKeyPath, true).DeleteValue(valueName);
        }

        /// <summary>
        /// Returns a list of all value names.
        /// </summary>
        /// <param name="inKey">Target key</param>
        /// <returns>String list</returns>
        public string[] value_list(Microsoft.Win32.RegistryKey inKey) {
            return inKey.GetValueNames();
        }

        /// <summary>
        /// Converts a registry entry to a class in ram.
        /// </summary>
        /// <param name="inKey">Target key</param>
        /// <param name="valueName">Target value name</param>
        /// <returns>RegistryValue object</returns>
        public RegistryValue value_load(Microsoft.Win32.RegistryKey inKey, string valueName) {
            return new RegistryValue(inKey, valueName);
        }

        /// <summary>
        /// Writes a registry value to registry.
        /// </summary>
        /// <param name="inKey">Target key</param>
        /// <param name="valueToWrite">Registry value to save</param>
        public void value_save(Microsoft.Win32.RegistryKey inKey, RegistryValue valueToWrite) {
            valueToWrite.writeValue(inKey);
        }
    }
}