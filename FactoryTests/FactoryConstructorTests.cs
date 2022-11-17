using FactoryDomain;

namespace FactoryTest;

public class FactoryConstructorTests
{
    [Test]
    public void DefaultConstructorTest_EmptyFactory_EmptyData()
    {
        var factory = new Factory();

        string expected = string.Empty;
        
        Assert.AreEqual(expected, factory.Title);
    }
    
    [Test]
    public void ParameterizedConstructorTest_Hire6MastersAnd56Employee_Success()
    {
        var factory = new Factory("Luch", 23, 56, 6, 100000, 200000, 10000, 30000);
        
        Assert.Pass();
    }
    [Test]
    public void ParameterizedConstructorTest_Hire3MasterAnd9Employee_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var factory = new Factory("Luch", 23, 9, 3, 100000, 200000, 10000, 30000);
        });
    }
    [Test]
    public void ParameterizedConstructorTest_Hire6MastersAnd61Employee_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var factory = new Factory("Luch", 23, 61, 6, 100000, 200000, 10000, 30000);
        });
    }
}