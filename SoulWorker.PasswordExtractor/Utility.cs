using System.Reflection.PortableExecutable;

namespace SoulWorker.PasswordExtractor;

internal static class Utility
{
    internal static class Address
    {
        internal static IEnumerable<int> AllFrom(ReadOnlyMemory<byte> buffer) => Enumerable
            .Range(0, buffer.Length)
            .Where((v) => buffer.Span[v].Equals((byte)AssemblyOpcode.Push))
            .Select(v => BitConverter.ToInt32(buffer.Span[(v + 1)..]));

        internal static IEnumerable<IEnumerable<int>> AllFrom(params ReadOnlyMemory<byte>[] buffers) => buffers.Select(AllFrom);
    }
}
