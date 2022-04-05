using SoulWorker.PasswordExtractor.Extensions;
using System.Reflection.PortableExecutable;
using System.Text;

namespace SoulWorker.PasswordExtractor;

internal sealed class StringExtractor
{
    #region Methods

    internal IEnumerable<string> GetStringsNames(int beginOffset, int endOffset) =>
        GetBytes(beginOffset, endOffset).Select(v =>  Encoding.ASCII.GetString(_memory[v].Span));

    internal IEnumerable<string> GetStringsPasswords(int beginOffset, int endOffset) =>
        GetBytes(beginOffset, endOffset).Select(GetString);

    #endregion

    #region Constructors

    internal StringExtractor(Configuration config, ReadOnlyMemory<byte> memory, PEHeaders headers)
    {
        _memory = memory;
        _headers = headers;
        _config = config;
    }

    #endregion Constructors

    #region Private Methods

    private IEnumerable<byte> DecodeBytes(Range range)
    {
        var span = _memory[range];
        for (int i = 0; i < span.Length; ++i)
            yield return DecodeByte(span.Span[i]);
    }

    private IEnumerable<Range> GetBytes(int beginOffset, int endOffset)
    {
        var addresses = Utility.Address
            // Get all addresses by PUSH assembly opcode
            .AllFrom(_memory[beginOffset..endOffset])
            .ToArray();

        // Skip first and last result.
        // First - SEH initialization function address.
        // Last - VString destructor function pointer passed to atext() function.
        addresses = addresses[1..^1];

        // Get all file offsets by memory address
        var offsets = addresses
            .Select(_headers.OffsetFromAddress)
            .Where(v => v != -1)
            .ToArray();

        return offsets.Select(v =>
        {
            var span = _memory.Span[v..];
            var distance = span.DistanceTo(0x0);
            return new Range(v, v + distance);
        });
    }

    #endregion Private Methods

    #region Private Static Methods

    private static byte DecodeByte(byte value) => (byte)(value ^ 5);

    private string GetString(Range v) => Encoding.ASCII.GetString(_config.NeedDecode ? DecodeBytes(v).ToArray() : _memory[v].Span);

    #endregion Private Static Methods

    #region Private Fields

    private readonly ReadOnlyMemory<byte> _memory;
    private readonly PEHeaders _headers;
    private readonly Configuration _config;

    #endregion Private Fields
}