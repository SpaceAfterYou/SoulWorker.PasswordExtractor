namespace SoulWorker.PasswordExtractor.Extensions;

internal static class ByteExtension
{
    internal static bool InRange(this byte value, byte min, byte max) => min <= value && value <= max;
}
