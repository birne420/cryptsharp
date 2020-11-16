using System;

namespace CryptSharp.lib.common {
    /// <summary>
    /// WMI Interface.
    /// </summary>
    public class WmiInterface {
        /// <summary>
        /// List of most important WMI-tables.
        /// </summary>
        private string[] itemList = { "Win32_BIOS", "Win32_BootConfiguration", "Win32_ComputerSystem", "Win32_OperatingSystem", "Win32_PhysicalMemory", "Win32_Processor", "Win32_SystemDevices", "Win32_StartupCommand", "Win32_UserAccount", "Win32_VideoController" };
        
        /// <summary>
        /// Get a list of important WMI tables plus all names and values.
        /// </summary>
        /// <returns>String</returns>
        public string listImportantCompounds() {
            System.Text.StringBuilder sbOut = new System.Text.StringBuilder();
            for (int i = 0; i < itemList.Length; i++) {
                sbOut.AppendLine("===== ===== ===== ===== ===== ===== ===== ===== ===== =====");
                sbOut.AppendLine(itemList[i].ToUpper() + ":\n");
                System.Management.ManagementObjectSearcher mbs = new System.Management.ManagementObjectSearcher("SELECT * FROM " + itemList[i]);
                try {
                    foreach (System.Management.ManagementObject mo in mbs.Get()) {
                        System.Management.PropertyDataCollection searcherProperties = mo.Properties;
                        foreach (System.Management.PropertyData sp in searcherProperties) {
                            sbOut.AppendLine(sp.Name + " = '" + sp.Value + "'");
                        }
                    }
                } catch(Exception ex) {
                    sbOut.AppendLine("Error: " + ex.Message);
                }
            }
            return sbOut.ToString();
        }

        /// <summary>
        /// Returns a CSV-formatted string containing the requested WMI table.
        /// </summary>
        /// <param name="inKey">WMI target table</param>
        /// <returns>CSV string</returns>
        public string readWMIKeyAsCSV(string inKey) {
            System.Text.StringBuilder sbOut = new System.Text.StringBuilder();
            System.Management.ManagementObjectSearcher mbs = new System.Management.ManagementObjectSearcher("SELECT * FROM " + inKey);
            try {
                foreach (System.Management.ManagementObject mo in mbs.Get()) {
                    System.Management.PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (System.Management.PropertyData sp in searcherProperties) {
                        sbOut.AppendLine(sp.Name + ";" + sp.Value);
                    }
                }
            } catch (Exception ex) {
                sbOut.AppendLine("Error;" + ex.Message);
            }
            return sbOut.ToString();
        }

        /// <summary>
        /// Reads a specified value from any WMI table.
        /// </summary>
        /// <param name="inKey">WMI target table</param>
        /// <param name="inAttribute">WMI attribute to read</param>
        /// <returns>Value as object</returns>
        public object readWMICompound(string inKey, string inAttribute) {
            System.Management.ManagementObjectSearcher mbs = new System.Management.ManagementObjectSearcher("SELECT * FROM " + inKey);
            try {
                foreach (System.Management.ManagementObject mo in mbs.Get()) {
                    System.Management.PropertyDataCollection searcherProperties = mo.Properties;
                    foreach (System.Management.PropertyData sp in searcherProperties) {
                        if (sp.Name.ToLower() == inAttribute.ToLower()) {
                            return sp.Value;
                        }
                    }
                }
                return null;
            } catch (Exception ex) {
                return "Error: " + ex.Message;
            }
        }
    }
}