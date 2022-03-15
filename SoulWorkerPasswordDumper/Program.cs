using SoulWorkerPasswordDumper;

var path = args[0];

var scanner = await Scanner.Create(path);
var groupedAddresses = await Application.GetGroupedAddresses(path);

await using var fs = File.OpenRead(path);
var groupedOffsets = Application.GetGroupedOffsets(groupedAddresses, fs);

var raws = groupedOffsets.Select(offsets => offsets.Select(offset => Application.GetValueByOffset(offset, fs)));
var result = Application.Parse(raws);

foreach (var (key, value) in result) Console.WriteLine("Key = {0}, Value = {1}", key, value);
