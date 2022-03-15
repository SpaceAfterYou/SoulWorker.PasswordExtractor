using SoulWorkerPasswordDumper;

//var paths = new string[]
//{
//    @"Y:\soulworker-dev\dumps\SoulWorker_dump_global_03_13_2022.exe",
//    @"Y:\soulworker-dev\dumps\SoulWorker_dump_global_12_08_2021.exe"
//};

//var results = await Task.WhenAll(paths.Select(async path =>
//{
//    var scanner = await Scanner.Create(path);
//    var groupedAddresses = await Application.GetGroupedAddresses(path);

//    await using var fs = File.OpenRead(path);
//    var groupedOffsets = Application.GetGroupedOffsets(groupedAddresses, fs);

//    var raws = groupedOffsets.Select(offsets => offsets.Select(offset => Application.GetValueByOffset(offset, fs)));
//    return Application.Parse(raws);
//}));

//// var path = @"Y:\soulworker-dev\dumps\SoulWorker_dump_global_03_13_2022.exe";
//// var path = @"Y:\soulworker-dev\dumps\SoulWorker_dump_global_12_08_2021.exe";

var path = args[0];

var scanner = await Scanner.Create(path);
var groupedAddresses = await Application.GetGroupedAddresses(path);

await using var fs = File.OpenRead(path);
var groupedOffsets = Application.GetGroupedOffsets(groupedAddresses, fs);

var raws = groupedOffsets.Select(offsets => offsets.Select(offset => Application.GetValueByOffset(offset, fs)));
var result = Application.Parse(raws);

foreach (var (key, value) in result) Console.WriteLine("Key = {0}, Value = {1}", key, value);
