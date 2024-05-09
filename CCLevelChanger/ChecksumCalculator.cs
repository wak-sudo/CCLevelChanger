namespace CCLevelChanger
{
    partial class ChecksumCalculator
    {
        /// <summary>
        /// Calculates checksum of the save file.
        /// 
        /// The algorithm is a standard CRC32 with a lookup table. However, there are two differences:
        /// 1. The initial value equals 0.
        /// 2. The bitwise NOT operation is applied on the final result.
        ///
        /// </summary>
        /// <param name="bytes">Bytes from which the CRC is calculated.</param>
        /// <returns>The CRC value.</returns>
        public static uint CalculateChecksum(byte[] bytes)
        {
            uint crc = 0;
            foreach (byte oneByte in bytes)
            {
                uint nLookupIndex = (crc & 0xFF) ^ oneByte;
                crc = (crc >> 8) ^ crcTable[nLookupIndex];
            }
            return ~crc;
        }
    }
}