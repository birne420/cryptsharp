namespace CryptSharp.lib.implementations.psi.crypt {
    /// <summary>
    /// Implementation of PSI encryption algorithm.
    /// </summary>
    public class Encryptor {
        /// <summary>
        /// Hash function with length of 32
        /// </summary>
        private utility.HashFunction HashFunction32;

        /// <summary>
        /// Hash function with length of 256 for s-box.
        /// </summary>
        private utility.HashFunction HashFunction256;

        /// <summary>
        /// Constructor initializes two instances of the hash algorithm in order to be able to supply multiple hash lengths.
        /// </summary>
        public Encryptor() {
            HashFunction32 = new utility.HashFunction(32);
            HashFunction256 = new utility.HashFunction(256);
        }

        /// <summary>
        /// Encryption of a byte array.
        /// The key data should be a hash of the PSI's hash function.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        /// <param name="keyData">Key data (should be 32 bytes in size)</param>
        /// <returns>Encrypted byte array</returns>
        public byte[] EncryptByteArray(byte[] inputData, byte[] keyData) {
            //Zerlegung in ByteGrids durch die ByteSplitter-Klasse.
            ByteSplitterEncrypt byteSplitter = new ByteSplitterEncrypt(inputData);

            //Reservierung des Arbeitsspeichers für die verschlüsselten Blöcke.
            //Ein Block hat eine Größe von 16x16 Bytes, d.h. ist 256 Bytes groß.
            byte[] outputBytes = new byte[256 * byteSplitter.getGridAmount()];

            //Die erste S-Box wird definiert. Sie wird aus dem keyData-Array über die Hash-Funktion errechnet.
            byte[] lastSBox = HashFunction256.createByteHash(System.Text.Encoding.ASCII.GetString(keyData));

            //Der Schlüssel für den ersten Block ist keyData.
            byte[] lastKey = keyData;

            //Verschlüsselung der Blöcke:
            for (int i = 0; i < byteSplitter.getGridAmount(); i++) {
                //Erstellung eines temporären ByteGrids zur weiteren Verarbeitung.
                ByteGrid tmpGrid = byteSplitter.getGridAt(i);

                //Speichern der Grids für den späteren Gebrauch.
                byte[] nextKey = HashFunction32.createByteHashFromGrid(tmpGrid);
                byte[] nextSBox = HashFunction256.createByteHashFromGrid(tmpGrid);

                //Horizontale Permutation: [SCHRITT 1 DER VERSCHLÜSSELUNG]
                for (int j = 0; j < 16; j++) {
                    //In Zeile j werden die Bytes um (lastKey[j] mod 16) nach links verschoben.
                    tmpGrid.permutateHorizontal(j, (byte)(lastKey[j] % 16));
                }

                //Vertikale Permutation: [SCHRITT 2 DER VERSCHLÜSSELUNG]
                for (int j = 0; j < 16; j++) {
                    //In Spalte j werden die Bytes um (lastKey[16 + j] mod 16) nach unten verschoben.
                    tmpGrid.permutateVertical(j, (byte)(lastKey[16 + j] % 16));
                }

                //Das ByteGrid wird als ByteArray dargestellt.
                byte[] shuffledBytes = tmpGrid.getGridBytes();

                //Die S-Box wird angewendet. [SCHRITT 3 DER VERSCHLÜSSELUNG]
                shuffledBytes = ApplySBox(shuffledBytes, lastSBox);

                //Der verschlüsselte Block wird in outputBytes an die richtige Stelle kopiert.
                for(int j = 0; j < shuffledBytes.Length; j++) {
                    outputBytes[i * 256 + j] = shuffledBytes[j];
                }

                //Die S-Box für den nächsten Block wird aus dem originalen aktuellen Block errechnet.
                lastSBox = nextSBox;

                //Der Key für den nächsten Block wird aus dem originalen aktuellen Block errechnet.
                lastKey = nextKey;
            }

            //Rückgabe und Invertierung des verschlüsselten Arrays. [SCHRITT 4 DER VERSCHLÜSSELUNG]
            return statics.ByteInverter.invertBytes(outputBytes);
        }

        /// <summary>
        /// Application of s-box for encryption.
        /// </summary>
        /// <param name="inputGridBytes">Input byte array</param>
        /// <param name="inputSBox">Input byte array s-box</param>
        /// <returns>Applied s-box bytes</returns>
        private byte[] ApplySBox(byte[] inputGridBytes, byte[] inputSBox) {
            //Die Eingabe wird in ein Integer-Array konvertiert.
            int[] finishedBox = statics.ArrayConverter.convertByteToInt(inputGridBytes);

            //Loop durch alle 256 Bytes:
            for(int i = 0; i < finishedBox.Length; i++) {
                if(finishedBox[i] != 255) {
                    //Auf das aktuelle Byte wird der aktuelle Wert der S-Box addiert.
                    finishedBox[i] += inputSBox[i];

                    //Wenn der Wert des Bytes größer als 255 ist, wird 255 subtrahiert.
                    if (finishedBox[i] >= 255) {
                        finishedBox[i] -= 255;
                    }
                }
            }

            //Das Array wird in ein Byte-Array konvertiert und zurückgegeben. 
            return statics.ArrayConverter.convertIntToByte(finishedBox);
        }
    }
}