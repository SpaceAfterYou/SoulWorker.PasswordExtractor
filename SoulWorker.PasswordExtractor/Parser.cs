using System.Reflection.PortableExecutable;
using System.Text;

namespace SoulWorker.PasswordExtractor;

internal static class Parser
{
    internal static IDictionary<string, string> Parse(IEnumerable<IEnumerable<string>> raws)
    {
        var (names, passwords) = Utility.NormalizeNamePasswordOrder(raws);
        return names.Zip(passwords).ToDictionary(e => e.First, e => e.Second);
    }

    internal static IEnumerable<string> GetValueByOffsets(IEnumerable<long> offsets, Stream stream) => offsets
        .Select(offset => GetValueByOffset(offset, stream));

    internal static string GetValueByOffset(long offset, Stream stream)
    {
        stream.Position = offset;

        var buffer = new List<byte>(10);

        for (int b; (b = stream.ReadByte()) != (byte)'\0' && b != -1;)
        {
            buffer.Add((byte)b);
        }

        return Encoding.ASCII.GetString(buffer.ToArray());
    }

    internal static IEnumerable<IEnumerable<long>> GetOffsets(IEnumerable<IEnumerable<int>> addresses, Stream stream)
    {
        var headers = new PEHeaders(stream);
        if (headers.PEHeader is null) throw new ArgumentNullException(null, nameof(headers.PEHeader));

        return addresses.Select(e => e.Select(a => Utility.GetFileOffset(a, headers)));
    }

    internal static async ValueTask<IEnumerable<IEnumerable<int>>> AddressesFrom(string path)
    {
        var scanner = await Scanner.Create(path);

        var scanned = scanner
            .GroupBy(e => e.Length)
            .Where(e => e.Count() == 2)
            .ToArray();

        if (scanned.Length == 0) throw new ApplicationException("Not found");
        if (scanned.Length != 1) throw new ApplicationException("Too many results");

        var groups = scanned.SelectMany(e => e).ToArray();
        return Utility.Address.All(groups);
    }
}
