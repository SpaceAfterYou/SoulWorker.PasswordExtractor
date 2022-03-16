namespace SoulWorker.PasswordExtractor;

public static class Extract
{
    public static async ValueTask<IDictionary<string, string>> From(string path)
    {
        var scanner = await Scanner.Create(path);
        var addresses = await Parser.AddressesFrom(path);

        await using var fs = File.OpenRead(path);
        var offsets = Parser.GetOffsets(addresses, fs);

        var raws = offsets.Select(offsets => offsets.Select(offset => Parser.GetValueByOffset(offset, fs)));
        return Parser.Parse(raws);
    }
}
