using SoulWorker.PasswordExtractor;

var config = Configuration.CreateFromArgs();
var extractor = await Extractor.Create(config);

var results = extractor.FromUnpacked();

foreach (var (key, value) in results)
    Console.WriteLine("Key = {0}, Value = {1}", key, value);
