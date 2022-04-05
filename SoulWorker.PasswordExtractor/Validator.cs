using SoulWorker.PasswordExtractor.Extensions;
using System.Text;

namespace SoulWorker.PasswordExtractor;

internal static class Validator
{
    #region Static Methods

    internal static bool Check(in ReadOnlySpan<byte> buffer) =>
        CheckName(buffer) && CheckId(buffer) && CheckEnding(buffer);

    internal static bool CheckId(in ReadOnlySpan<byte> buffer)
    {
        foreach (var index in Enumerable.Range(_data.Length, 2))
            if (!buffer[index].InRange(_zero, _nine))
                return false;

        return true;
    }

    internal static bool CheckName(in ReadOnlySpan<byte> buffer) =>
        buffer.StartsWith(_data);

    internal static bool CheckEnding(in ReadOnlySpan<byte> buffer) =>
        buffer[_end].Equals(_null);

    internal static string GetFullName(in ReadOnlySpan<byte> buffer) =>
        Encoding.ASCII.GetString(buffer[0.._end]);

    #endregion Static Methods

    #region Private Fields

    private const byte _null = 0x0;

    private const byte _zero = 0x30;
    private const byte _nine = 0x39;

    private const byte _firstDigitIndex = 4;
    private const byte _secondDigitIndex = _firstDigitIndex + 1;

    private const byte _end = _secondDigitIndex + 1;

    private static readonly byte[] _data = new byte[] { 0x64, 0x61, 0x74, 0x61 };

    #endregion Private Fields
}
