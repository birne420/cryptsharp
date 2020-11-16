using System;
namespace Debugger {
    class Program {
        static void Main(string[] args) {
            CryptSharp.CryptSharp cs = new CryptSharp.CryptSharp();

            String rsa_xml = cs.ciphers.rsa2048.getPrivateKeyInformationXML();

            System.IO.File.WriteAllText(".\\rsa_key.xml", rsa_xml);

            cs.ciphers.rsa2048.setNewKeyInformationXML(rsa_xml);

            Console.WriteLine("RSA key information: \n" + rsa_xml);

            Console.Write("Enter text to encrypt: ");

            String plain = Console.ReadLine();

            byte[] plainBytes = System.Text.Encoding.ASCII.GetBytes(plain);

            byte[] encBytes = cs.ciphers.rsa2048.encryptBytes(plainBytes);

            Console.WriteLine("Encrypted text: " + cs.utils.convertBytesToHex(encBytes));

            Console.ReadLine();
        }
    }
}