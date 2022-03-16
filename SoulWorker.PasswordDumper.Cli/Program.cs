using SoulWorker.PasswordDumper;

var path = args[0];
var results = await Dump.From(path);

foreach (var (key, value) in results) Console.WriteLine("Key = {0}, Value = {1}", key, value);
