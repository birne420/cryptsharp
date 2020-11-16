namespace CryptSharp.lib.implementations.psi.crypt {
    /// <summary>
    /// Interface of Encryptor and ByteGrid class.
    /// </summary>
    public class ByteSplitterEncrypt {
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
        /// If the data cannot be divided by 256 without a remainder, the bytes required in the last grid of the managed list are filled with 0x00.
        /// </summary>
        /// <param name="inputData">Input byte array</param>
        public ByteSplitterEncrypt(byte[] inputData) {
            byte[] dataFinishToken = statics.Definitions.dataFinishingToken;
            byte[] dataToEncrypt;
            dataToEncrypt = new byte[inputData.Length + dataFinishToken.Length];
            System.Array.Copy(inputData, 0, dataToEncrypt, 0, inputData.Length);
            System.Array.Copy(dataFinishToken, 0, dataToEncrypt, inputData.Length, dataFinishToken.Length);
            byteGrids = new System.Collections.Generic.List<ByteGrid>();
            int gridAmount = (int)System.Math.Floor((double)dataToEncrypt.Length / 256d);
            for (int i = 0; i < gridAmount; i++) {
                byte[] gridBytes = new byte[256];
                System.Array.Copy(dataToEncrypt, i * 256, gridBytes, 0, 256);
                ByteGrid newGrid = new ByteGrid(gridBytes);
                byteGrids.Add(newGrid);
            }
            byte[] lastGridBytes = new byte[256];
            System.Array.Copy(dataToEncrypt, gridAmount * 256, lastGridBytes, 0, dataToEncrypt.Length % 256);
            ByteGrid lastNewGrid = new ByteGrid(lastGridBytes);
            byteGrids.Add(lastNewGrid);
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