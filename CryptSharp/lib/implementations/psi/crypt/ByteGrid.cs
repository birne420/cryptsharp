namespace CryptSharp.lib.implementations.psi.crypt {
    /// <summary>
    /// Byte grid structure and permutation functions.
    /// </summary>
    public class ByteGrid {
        /// <summary>
        /// Byte grid as multidimensional array.
        /// </summary>
        private byte[,] byteGrid;

        /// <summary>
        /// Initializes a ByteGrid.
        /// The transferred array must have a minimum length of 256.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        public ByteGrid(byte[] inputData) {
            byteGrid = new byte[16, 16];
            for(int y = 0; y < 16; y++) {
                for(int x = 0; x < 16; x++) {
                    byteGrid[y, x] = inputData[y * 16 + x];
                }
            }
        }

        /// <summary>
        /// Returns the byte grid as a two-dimensional array.
        /// </summary>
        /// <returns>Multidimensional byte array</returns>
        public byte[,] getByteGrid() {
            return byteGrid;
        }

        /// <summary>
        /// Returns the byte grid as a one-dimensional array.
        /// </summary>
        /// <returns>Output byte array</returns>
        public byte[] getGridBytes() {
            byte[] rtnArray = new byte[256];
            for (int y = 0; y < 16; y++) {
                for (int x = 0; x < 16; x++) {
                    rtnArray[y * 16 + x] = byteGrid[y, x];
                }
            }
            return rtnArray;
        }

        /// <summary>
        /// Rotates the specified line (between 0 and 15) to the left.
        /// </summary>
        /// <param name="tableRow">Target table row</param>
        /// <param name="objByte">Number of shifts</param>
        public void permutateHorizontal(int tableRow, byte objByte) {
            byte[] workArray = new byte[16];
            int bytesToShift = objByte % 16;
            for(int i = 0; i < 16; i++) {
                workArray[i] = byteGrid[tableRow, i];
            }
            for(int i = 0; i < bytesToShift; i++) {
                byte tmpByte = workArray[0];
                System.Array.Copy(workArray, 1, workArray, 0, workArray.Length - 1);
                workArray[workArray.Length - 1] = tmpByte;
            }
            for (int i = 0; i < 16; i++) {
                byteGrid[tableRow, i] = workArray[i];
            }
        }

        /// <summary>
        /// Rotates the specified line (between 0 and 15) to the bottom.
        /// </summary>
        /// <param name="tableColumn">Target table column</param>
        /// <param name="objByte">Number of shifts</param>
        public void permutateVertical(int tableColumn, byte objByte) {
            byte[] workArray = new byte[16];
            int bytesToShift = objByte % 16;
            for (int i = 0; i < 16; i++) {
                workArray[i] = byteGrid[i, tableColumn];
            }
            for (int i = 0; i < bytesToShift; i++) {
                byte tmpByte = workArray[0];
                System.Array.Copy(workArray, 1, workArray, 0, workArray.Length - 1);
                workArray[workArray.Length - 1] = tmpByte;
            }
            for (int i = 0; i < 16; i++) {
                byteGrid[i, tableColumn] = workArray[i];
            }
        }
    }
}