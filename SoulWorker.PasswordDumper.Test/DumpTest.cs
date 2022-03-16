using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SoulWorker.PasswordDumper.Test;

[TestClass]
public class DumpTest
{
    [TestMethod]
    public async Task TestFrom_Global_Ver_1_8_32_1()
    {
        var results = await Dump.From(@"Data\SoulWorker_dump_global_03_13_2022.exe");

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
    public async Task TestFrom_Global_Ver_1_8_20_1()
    {
        var results = await Dump.From(@"Data\SoulWorker_dump_global_12_08_2021.exe");
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
}
