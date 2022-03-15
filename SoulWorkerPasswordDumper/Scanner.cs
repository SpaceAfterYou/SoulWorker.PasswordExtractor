using System.Collections;

namespace SoulWorkerPasswordDumper;

internal sealed class Scanner : IEnumerable<byte[]>
{
    IEnumerator<byte[]> IEnumerable<byte[]>.GetEnumerator()
    {
        for (int i = 0; i < _bytes.Length; ++i)
        {
            var search = new Search(_bytes[i..]);

            var header = search.One(Pattern.Header);
            if (header.Length == 0) continue;

            var body = search.AllAnyOf(Pattern.BodyVariant);
            if (body.Length == 0) continue;

            var footer = search.One(Pattern.Footer);
            if (footer.Length == 0) continue;

            yield return body.ToArray();
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();

    internal static async ValueTask<Scanner> Create(string path, CancellationToken cancellationToken = default)
    {
        var bytes = await File.ReadAllBytesAsync(path, cancellationToken);
        return new(bytes);
    }

    private Scanner(in ReadOnlyMemory<byte> bytes) => _bytes = bytes;

    private readonly ReadOnlyMemory<byte> _bytes;
}
