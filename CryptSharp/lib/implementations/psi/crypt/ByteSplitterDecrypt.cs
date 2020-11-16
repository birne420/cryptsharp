namespace CryptSharp.lib.implementations.psi.crypt {
    /// <summary>
    /// Interface of Decryptor and ByteGrid class.
    /// </summary>
    class ByteSplitterDecrypt {
        /// <summary>
        /// List of byte grids.
        /// </summary>
        private System.Collections.Generic.List<ByteGrid> byteGrids;

        /// <summary>
        /// Byte grid array.
        /// </summary>
        private ByteGrid[] byteGridArray;

        /// <summary>
        /// Initialization with input data creates as many byte grids as are required.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        public ByteSplitterDecrypt(byte[] inputData) {
            byte[] dataToDecrypt = inputData;
            
            byteGrids = new System.Collections.Generic.List<ByteGrid>();
            int gridAmount = (int)System.Math.Floor((double)dataToDecrypt.Length / 256d);
            for (int i = 0; i < gridAmount; i++) {
                byte[] gridBytes = new byte[256];
                System.Array.Copy(dataToDecrypt, i * 256, gridBytes, 0, 256);
                ByteGrid newGrid = new ByteGrid(gridBytes);
                byteGrids.Add(newGrid);
            }

            byteGridArray = byteGrids.ToArray();
        }

        /// <summary>
        /// Returns the byte grid at requested position.
        /// </summary>
        /// <param name="index">Requested index</param>
        /// <returns>Requested byte grid</returns>
        public ByteGrid getGridAt(int index) {
            return byteGridArray[index];
        }

        /// <summary>
        /// Re-Sets a grid at requested position.
        /// </summary>
        /// <param name="index">Requested index</param>
        /// <param name="inputGrid">New byte grid data</param>
        public void setGridAt(int index, ByteGrid inputGrid) {
            byteGridArray[index] = inputGrid;
        }

        /// <summary>
        /// Returns the amount of byte grids.
        /// </summary>
        /// <returns>Byte grid amount</returns>
        public int getGridAmount() {
            return byteGridArray.Length;
        }
    }
}