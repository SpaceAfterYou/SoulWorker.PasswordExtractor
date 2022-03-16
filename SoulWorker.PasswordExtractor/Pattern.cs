namespace SoulWorker.PasswordExtractor;

internal sealed record Pattern
{
    internal static byte[] Header { get; } = new byte[]
    {
        0x55, 0x8B, 0xEC, 0x6A, 0xFF, 0x68, UndO, UndO,
        UndO, UndO, 0x64, 0xA1, 0x00, 0x00, 0x00, 0x00,
        0x50,
    };

    internal static byte[][] BodyVariant { get; } = new byte[][]
    {
        new byte[]
        {
            0x64, 0x89, 0x25, 0x00, 0x00, 0x00, 0x00, 0x68,
            UndO, UndO, UndO, UndO, 0xB9, UndO, UndO, UndO,
            UndO, 0xE8, UndO, UndO, UndO, UndO, 0x90,
        },
        new byte[]
        {
            0xC7, 0x45, 0xFC, 0x00, 0x00, 0x00, 0x00, 0x68,
            UndO, UndO, UndO, UndO, 0xB9, UndO, UndO, UndO,
            UndO, 0xE8, UndO, UndO, UndO, UndO, 0x90,
        },
        new byte[]
        {
            0xC6, 0x45, 0xFC, UndO, 0x68, UndO, UndO, UndO,
            UndO, 0xB9, UndO, UndO, UndO, UndO, 0xE8, UndO,
            UndO, UndO, UndO, 0x90,
        },
    };

    internal static byte[] Footer { get; } = new byte[]
    {
        0xC7, 0x45, 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0x68,
        UndO, UndO, UndO, UndO, 0xE8, UndO, UndO, UndO,
        UndO, 0x83, 0xC4, 0x04, 0x8B, 0x4D, 0xF4, 0x64,
        0x89, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x8B, 0xE5,
        0x5D, 0xC3
    };

    public const byte UndO = byte.MinValue;
}
