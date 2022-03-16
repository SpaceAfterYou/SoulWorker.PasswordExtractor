namespace SoulWorker.PasswordExtractor;

internal sealed class Search
{
    internal ReadOnlyMemory<byte> One(in ReadOnlySpan<byte> pattern)
    {
        if (Utility.StartsWith(_buffer, pattern))
            return GetResult(pattern.Length);

        return Array.Empty<byte>();
    }

    internal ReadOnlyMemory<byte> AllAnyOf(in ReadOnlySpan<byte[]> patterns)
    {
        var length = 0;

        for (ReadOnlySpan<byte> value; (value = Utility.FirstOfAny(_buffer[length..], patterns)).Length > 0;)
            length += value.Length;

        return GetResult(length);
    }

    internal Search(in ReadOnlyMemory<byte> buffer) => _buffer = buffer;

    private ReadOnlyMemory<byte> GetResult(int length)
    {
        var result = _buffer[..length];
        _buffer = _buffer[length..];

        return result;
    }

    private ReadOnlyMemory<byte> _buffer;
}
