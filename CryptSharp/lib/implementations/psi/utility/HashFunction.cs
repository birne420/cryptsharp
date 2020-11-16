namespace CryptSharp.lib.implementations.psi.utility {
    /// <summary>
    /// Provides PSI hash function.
    /// </summary>
    public class HashFunction {
        /// <summary>
        /// Represents current hash length.
        /// </summary>
        private int hashLength;

        /// <summary>
        /// Creates an instance with the corresponding hash length.
        /// </summary>
        /// <param name="newHashLength">Hash length</param>
        public HashFunction(int newHashLength) {
            hashLength = newHashLength;
        }

        /// <summary>
        /// Converts a ByteGrid into a byte array and returns the hash.
        /// </summary>
        /// <param name="inputGrid">Input grid</param>
        /// <returns>Hash as byte array</returns>
        public byte[] createByteHashFromGrid(crypt.ByteGrid inputGrid) {
            return createByteHash(System.Text.Encoding.ASCII.GetString(inputGrid.getGridBytes()));
        }

        /// <summary>
        /// Creates a hash of the inputString string.
        /// </summary>
        /// <param name="inputString">Input string</param>
        /// <returns>Hash as byte array</returns>
        public byte[] createByteHash(string inputString) {
            //Wenn die Eingabe null ist, wird ein leeres ByteArray zurückgegeben.
            if(inputString.Length <= 0) {
                return new byte[] { };
            }

            //Länge des InputStrings.
            int baseLength = inputString.Length;

            //Verlängert den InputString.
            int count = 0;
            while (inputString.Length < (hashLength * 16)) {
                count += hashLength;
                inputString += inputString + count;
            }

            //Verlängerte Daten werden in eine Byte Liste umgewandelt.
            byte[] inputData = System.Text.Encoding.ASCII.GetBytes(inputString);

            //Bytes werden invertiert.
            inputData = statics.ByteInverter.invertBytes(inputData);

            //Jeder Wert des Byte Arrays wird potenziert und mod 255 gerechnet.
            for (int i = 0; i < inputData.Length; i++) {
                inputData[i] = (byte)(System.Math.Pow(inputData[i], 5.12) % 255);
            }

            //Länge des Original Strings wird potenziert, um kleine Abweichungen merkbar zu machen.
            long currentByte = (long)System.Math.Pow(baseLength, 5.12);

            //Werte des ByteArrays werden mit der Potenz des Originallänge addiert und anschließend mod 255 gerechnet,
            //um wieder in den Datenbereich eines Bytes zu passen.
            for (int i = 0; i < inputData.Length; i++) {
                currentByte += inputData[i];
                inputData[i] = (byte)(currentByte % 255);
            }

            //Speicherreservierung für die Output Daten.
            byte[] outputData = new byte[hashLength];

            //Letzte Schleife durch die Input Daten.
            for(int i = 0; i < inputData.Length; i++) {
                //cIndex ist i mod Länge des zu generierenden Hashes.
                //Dadurch werden die Daten nahezu gleichmäßig auf die
                //Output-Daten aufgeteilt.
                int cIndex = i % outputData.Length;

                //Temporäre Variable wird initialisiert.
                int cData = 0;

                //Auf die temporäre Variable wird addiert:
                cData += outputData[cIndex]; //Bereits vorhandene Daten des letzten Durchlaufs (beim ersten mal 0)
                cData += inputData[i];       //Aktueller Wert der InputDaten

                //temporäre Variable wird auf den Speicherbereich eines Bytes runtergerechnet (mod 255).
                cData = cData % 255;

                //Schreiben und konvertieren der Output-Daten.
                outputData[cIndex] = (byte)cData;
            }
            return outputData;
        }

        /// <summary>
        /// Converts a byte array to 0-9 a-f notation.
        /// </summary>
        /// <param name="inputHash">Hash to convert</param>
        /// <returns>Hash as string</returns>
        public string convertByteHashToString(byte[] inputHash) {
            return common.utility.GeneralUtility.toHex(inputHash);
        }
    }
}