using System;
using System.IO;

namespace CCLevelChanger
{
    class FileEditor
    {
        readonly string filePath;
        readonly FileInfo infoFile;

        /// <summary>
        /// The first 4 bytes is the file length (excluding 8 bytes), the remaining 4 is checksum.
        /// </summary>
        const int reservedBytes = 8;

        // Offsets:
        const int checksumValueStartOffset = 4;
        const int levelValueStartOffset = 52;
        const int levelValueEndOffset = 55;

        public SaveData SaveInfo { get; private set; }

        public FileEditor(string filePath)
        {
            this.filePath = filePath;
            infoFile = new FileInfo(filePath);
            SaveInfo = ReadSaveFile();
        }

        /// <summary>
        /// Collects info about the save file.
        /// </summary>
        /// <returns>Info about the save file as a SaveData object.</returns>
        private SaveData ReadSaveFile()
        {
            // In fact, the file must be longer than levelValueEndOffset to be valid, but for now, we do not need to check this.
            if (infoFile.Length <= levelValueEndOffset)
                throw new Exception();

            SaveData saveFile = new SaveData();
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    saveFile.FileSize = reader.ReadUInt32();
                    saveFile.CRCchecksum = reader.ReadUInt32();
                    stream.Seek(levelValueStartOffset, SeekOrigin.Begin);
                    saveFile.Level = reader.ReadUInt32();
                }
            }
            return saveFile;
        }

        /// <summary>
        /// Get all bytes from the file except the first (reserved) 8. With these bytes, the checksum can be calculated.
        /// </summary>
        /// <returns>All bytes from the file except the first 8.</returns>
        private byte[] GetDataBytes()
        {
            if (infoFile.Length < reservedBytes)
                throw new Exception();

            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                stream.Seek(reservedBytes, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    return reader.ReadBytes((int)(infoFile.Length - reservedBytes));
                }
            }
        }

        /// <summary>
        /// Change the game level in the save file.
        /// </summary>
        /// <param name="levelNumber">New value of the level.</param>
        public void ChangeLevel(uint levelNumber)
        {
            // Checks whether the internal file length matches the actual.
            if (SaveInfo.FileSize + reservedBytes != infoFile.Length)
                throw new Exception();

            // Checks whether the file can be written to.
            if (infoFile.Length <= levelValueEndOffset)
                throw new Exception();

            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                file.Seek(levelValueStartOffset, SeekOrigin.Begin);
                file.Write(BitConverter.GetBytes(levelNumber), 0, sizeof(uint));
            }

            uint newChecksum = ChecksumCalculator.CalculateChecksum(GetDataBytes());
            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                file.Seek(checksumValueStartOffset, SeekOrigin.Begin);
                file.Write(BitConverter.GetBytes(newChecksum), 0, sizeof(uint));
            }

            // Update the save info:
            SaveInfo.Level = levelNumber;
            SaveInfo.CRCchecksum = newChecksum;
        }
    }
}