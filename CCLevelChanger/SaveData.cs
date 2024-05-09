namespace CCLevelChanger
{
    /// <summary>
    /// Stores info about the game save data.
    /// </summary>
    class SaveData
    {
        public uint FileSize { get; set; } = 0;

        public uint CRCchecksum { get; set; } = 0;

        public uint Level { get; set; } = 0;
    }
}