namespace CryptSharp.lib.implementations.psi.crypt {
    /// <summary>
    /// Implementation of PSI decryption algorithm.
    /// </summary>
    public class Decryptor {
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
        public Decryptor() {
            HashFunction32 = new utility.HashFunction(32);
            HashFunction256 = new utility.HashFunction(256);
        }

        /// <summary>
        /// Decryption of a byte array.
        /// The key data should be a hash of the PSI's hash function.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        /// <param name="keyData">Key data</param>
        /// <returns>Decrypted byte array</returns>
        public byte[] DecryptByteArray(byte[] inputData, byte[] keyData) {
            //Input Bytes werden invertiert und in ByteGrids aufgeteilt. [SCHRITT 1 DER ENTSCHLÜSSELUNG]
            ByteSplitterDecrypt byteSplitter = new ByteSplitterDecrypt(statics.ByteInverter.invertBytes(inputData));

            //Speicherreservierung für die Entschlüsselungsdaten.
            byte[] outputAllocArray = new byte[byteSplitter.getGridAmount() * 256];

            //Die erste S-Box wird definiert. Sie wird aus dem keyData-Array über die Hash-Funktion errechnet.
            byte[] lastSBox = HashFunction256.createByteHash(System.Text.Encoding.ASCII.GetString(keyData));

            //Der Schlüssel für den ersten Block ist keyData.
            byte[] lastKey = keyData;

            //Entschlüsselung der Blöcke:
            for (int i = 0; i < byteSplitter.getGridAmount(); i++) {
                //Erstellung eines temporären ByteArrays zur weiteren Verarbeitung.
                byte[] tmpBytes = byteSplitter.getGridAt(i).getGridBytes();

                //S-Box wird aufgelöst. [SCHRITT 2 DER ENTSCHLÜSSELUNG]
                tmpBytes = NeutralizeSBox(tmpBytes, lastSBox);

                //ByteArray wird zurück in ByteGrid geschrieben.
                ByteGrid tmpGrid = new ByteGrid(tmpBytes);

                //Vertikale Permutation: [SCHRITT 3 DER ENTSCHLÜSSELUNG]
                for (int j = 0; j < 16; j++) {
                    tmpGrid.permutateVertical(j, (byte)(16 - (lastKey[16 + j] % 16)));
                }

                //Horizontale Permutation: [SCHRITT 4 DER ENTSCHLÜSSELUNG]
                for (int j = 0; j < 16; j++) {
                    tmpGrid.permutateHorizontal(j, (byte)(16 - (lastKey[j] % 16)));
                }

                //Speichern der Grids für den späteren Gebrauch.
                byte[] nextKey = HashFunction32.createByteHashFromGrid(tmpGrid);
                byte[] nextSBox = HashFunction256.createByteHashFromGrid(tmpGrid);

                //Bytes werden umgewandelt zu ByteArray.
                tmpBytes = tmpGrid.getGridBytes();

                //Der entschlüsselte Block wird in outputAllocArray an die richtige Stelle kopiert.
                for (int j = 0; j < tmpBytes.Length; j++) {
                    outputAllocArray[i * 256 + j] = tmpBytes[j];
                }

                //Die S-Box für den nächsten Block wird aus dem originalen aktuellen Block errechnet.
                lastSBox = nextSBox;

                //Der Key für den nächsten Block wird aus dem originalen aktuellen Block errechnet.
                lastKey = nextKey;
            }

            //EndOfFile Token wird erstellt.
            byte[] EOFToken = new byte[statics.Definitions.dataFinishingToken.Length];
            System.Array.Copy(statics.Definitions.dataFinishingToken, EOFToken, statics.Definitions.dataFinishingToken.Length);
            System.Array.Reverse(EOFToken);
            int followingEquals = 0;
            int arrayCutoffPosition = 0;
            for(int i = outputAllocArray.Length - 1; i > (outputAllocArray.Length - 288); i--) {
                if (outputAllocArray[i] == EOFToken[followingEquals]) {
                    followingEquals++;
                    if (followingEquals == EOFToken.Length - 1) {
                        arrayCutoffPosition = i;
                        break;
                    }
                } 
            }

            //Abschneiden der überschüssigen Bytes.
            byte[] outputData = new byte[arrayCutoffPosition - 1];
            System.Array.Copy(outputAllocArray, outputData, arrayCutoffPosition - 1);

            //Zurückgeben der entschlüsselten Daten.
            return outputData;
        }

        /// <summary>
        /// Neutralization of s-box for decryption.
        /// </summary>
        /// <param name="inputGridBytes">Input byte array</param>
        /// <param name="inputSBox">Input byte array s-box</param>
        /// <returns>Neutralized s-box bytes</returns>
        private byte[] NeutralizeSBox(byte[] inputGridBytes, byte[] inputSBox) {
            //Die Eingabe wird in ein Integer-Array konvertiert.
            int[] finishedBox = statics.ArrayConverter.convertByteToInt(inputGridBytes);

            //Loop durch alle 256 Bytes:
            for (int i = 0; i < finishedBox.Length; i++) {
                if (finishedBox[i] != 255) {
                    //Vom aktuellen Byte wird der aktuelle Wert der S-Box subtrahiert.
                    finishedBox[i] -= inputSBox[i];

                    //Wenn der Wert des Bytes kleiner als 0 ist, wird 255 addiert.
                    if (finishedBox[i] < 0) {
                        finishedBox[i] += 255;
                    }
                } 
            }

            //Das Array wird in ein Byte-Array konvertiert und zurückgegeben. 
            return statics.ArrayConverter.convertIntToByte(finishedBox);
        }
    }
}