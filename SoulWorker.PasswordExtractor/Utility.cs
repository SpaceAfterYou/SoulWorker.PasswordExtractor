using System.Reflection.PortableExecutable;

namespace SoulWorker.PasswordExtractor;

internal static class Utility
{
    internal static Tuple<string[], string[]> NormalizeNamePasswordOrder(IEnumerable<IEnumerable<string>> raws)
    {
        var values = raws.Select(e => e.ToArray()).ToArray();
        return values[0].All(v => v.StartsWith("data")) ? Tuple.Create(values[0], values[1]) : Tuple.Create(values[1], values[0]);
    }

    internal static class Address
    {
        internal static IEnumerable<int> AllFrom(ReadOnlyMemory<byte> buffer) => Enumerable
            .Range(0, buffer.Length)
            .Where((v) => buffer.Span[v].Equals((byte)AssemblyOpcode.Push))
            .Select(v => BitConverter.ToInt32(buffer.Span[(v + 1)..]));

        internal static IEnumerable<IEnumerable<int>> AllFrom(params ReadOnlyMemory<byte>[] buffers) => buffers.Select(AllFrom);
    }

    internal static long GetFileOffset(int address, PEHeaders headers)
    {
        if (headers.PEHeader is null) throw new ArgumentNullException("Header not found", nameof(headers.PEHeader));
        var sectionAlignment = headers.PEHeader.SectionAlignment;

        if (headers.SectionHeaders.Length < 1) throw new ApplicationException("Too few section headers");
        var pointerToRawData = headers.SectionHeaders[0].PointerToRawData;

        if (headers.PEHeader.ImageBase > ulong.MaxValue) throw new ApplicationException("ImageBase value too big");
        return address - ((long)headers.PEHeader.ImageBase + sectionAlignment - pointerToRawData);
    }



    internal static ReadOnlySpan<byte> FirstOfAny(in ReadOnlyMemory<byte> value, in ReadOnlySpan<byte[]> pattern)
    {
        foreach (var p in pattern)
            if (StartsWith(value, p))
                return p;

        return Array.Empty<byte>();
    }

    internal static bool StartsWith(in ReadOnlyMemory<byte> value, in ReadOnlySpan<byte> pattern)
    {
        if (value.Length < pattern.Length) return false;

        var p = pattern.GetEnumerator();
        var v = value.Span.GetEnumerator();

        while (p.MoveNext() && v.MoveNext())
        {
            if (p.Current == Pattern.UndO) continue;
            if (p.Current != v.Current) return false;
        }

        return true;
    }
}
