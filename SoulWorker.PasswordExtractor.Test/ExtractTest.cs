using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoulWorker.PasswordExtractor.Test;

[TestClass]
public class ExtractTest
{
    [TestMethod]
    public async Task TestFromUnpacked_Global_Ver_1_8_32_2()
    {
        var config = Configuration.Create(@"Data\SoulWorker_dump_global_03_17_2022.exe");
        var extractor = await Extractor.Create(config);
        var results = extractor.FromUnpacked();

        Assert.IsTrue(results.ContainsKey("data15"));
        Assert.IsTrue(results.ContainsKey("data49"));
        Assert.IsTrue(results.ContainsKey("data45"));
        Assert.IsTrue(results.ContainsKey("data40"));
        Assert.IsTrue(results.ContainsKey("data43"));
        Assert.IsTrue(results.ContainsKey("data62"));
        Assert.IsTrue(results.ContainsKey("data60"));
        Assert.IsTrue(results.ContainsKey("data47"));
        Assert.IsTrue(results.ContainsKey("data28"));
        Assert.IsTrue(results.ContainsKey("data27"));
        Assert.IsTrue(results.ContainsKey("data26"));
        Assert.IsTrue(results.ContainsKey("data25"));
        Assert.IsTrue(results.ContainsKey("data24"));
        Assert.IsTrue(results.ContainsKey("data13"));
        Assert.IsTrue(results.ContainsKey("data11"));
        Assert.IsTrue(results.ContainsKey("data09"));
    }

    [TestMethod]
    public async Task TestFromUnpacked_Global_Ver_1_8_32_1()
    {
        var config = Configuration.Create(@"Data\SoulWorker_dump_global_03_13_2022.exe");
        var extractor = await Extractor.Create(config);
        var results = extractor.FromUnpacked();

        Assert.IsTrue(results.ContainsKey("data15"));
        Assert.IsTrue(results.ContainsKey("data49"));
        Assert.IsTrue(results.ContainsKey("data45"));
        Assert.IsTrue(results.ContainsKey("data40"));
        Assert.IsTrue(results.ContainsKey("data43"));
        Assert.IsTrue(results.ContainsKey("data62"));
        Assert.IsTrue(results.ContainsKey("data60"));
        Assert.IsTrue(results.ContainsKey("data47"));
        Assert.IsTrue(results.ContainsKey("data28"));
        Assert.IsTrue(results.ContainsKey("data27"));
        Assert.IsTrue(results.ContainsKey("data26"));
        Assert.IsTrue(results.ContainsKey("data25"));
        Assert.IsTrue(results.ContainsKey("data24"));
        Assert.IsTrue(results.ContainsKey("data13"));
        Assert.IsTrue(results.ContainsKey("data11"));
        Assert.IsTrue(results.ContainsKey("data09"));
    }

    [TestMethod]
    public async Task TestFromUnpacked_Global_Ver_1_8_20_1()
    {
        var config = Configuration.Create(@"Data\SoulWorker_dump_global_12_08_2021.exe");
        var extractor = await Extractor.Create(config);
        var results = extractor.FromUnpacked();

        Assert.IsTrue(results.ContainsKey("data62"));
        Assert.IsTrue(results.ContainsKey("data60"));
        Assert.IsTrue(results.ContainsKey("data47"));
        Assert.IsTrue(results.ContainsKey("data28"));
        Assert.IsTrue(results.ContainsKey("data27"));
        Assert.IsTrue(results.ContainsKey("data26"));
        Assert.IsTrue(results.ContainsKey("data25"));
        Assert.IsTrue(results.ContainsKey("data24"));
        Assert.IsTrue(results.ContainsKey("data13"));
        Assert.IsTrue(results.ContainsKey("data11"));
        Assert.IsTrue(results.ContainsKey("data09"));
        Assert.IsTrue(results.ContainsKey("data04"));
    }
    [TestMethod]
    public async Task TestFromUnpacked_Jp_Ver_1_12_17_0()
    {
        var config = Configuration.Create(@"Data\SoulWorker100_jp_1_12_17_0.exe");
        var extractor = await Extractor.Create(config);
        var results = extractor.FromUnpacked();

        Assert.IsTrue(results.ContainsKey("data02"));
        Assert.IsTrue(results.ContainsKey("data73"));
        Assert.IsTrue(results.ContainsKey("data13"));
        Assert.IsTrue(results.ContainsKey("data12"));
    }
}
