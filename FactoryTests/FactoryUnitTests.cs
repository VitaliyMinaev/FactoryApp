using FactoryDomain;

namespace FactoryTest;

public class FactoryTests
{
    [Test]
    public void DefaultConstructorTest_EmptyFactory_EmptyData()
    {
        var factory = new Factory();

        string expected = string.Empty;
        
        Assert.AreEqual(expected, factory.Title);
    }

    [Test]
    public void ParamatrizedConstructorTest_Hire9EmployeeAnd1Master_Success()
    {
        var factory = new Factory("Luch", 23, 9, 1, 100000, 200000, 10000, 30000);
        
        Assert.Pass();
    }
    [Test]
    public void ParameterizedConstructorTest_Hire9EmployeeAnd3Master_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var factory = new Factory("Luch", 23, 9, 3, 100000, 200000, 10000, 30000);
        });
    }
    [Test]
    public void ParameterizedConstructorTest_Hire60EmployeeAnd6Master_Success()
    {
        var factory = new Factory("Luch", 23, 56, 6, 100000, 200000, 10000, 30000);
        
        Assert.Pass();
    }
    [Test]
    public void ParameterizedConstructorTest_Hire60EmployeeAnd7Master_Success()
    {
        var factory = new Factory("Luch", 23, 56, 6, 100000, 200000, 10000, 30000);
        
        Assert.Pass();
    }
    [Test]
    public void ParameterizedConstructorTest_Hire61EmployeeAnd6Master_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var factory = new Factory("Luch", 23, 61, 6, 100000, 200000, 10000, 30000);
        });
    }

    [Test]
    public void HireEmployee_Hire1MasterAnd5Employees_Success()
    {
        var factory = new Factory("Luch", 23, 0, 0, 100000, 200000, 10000, 30000);

        factory.HireMaster();
        for (int i = 1; i <= 5; ++i)
        {
            factory.HireEmployee();
        }
        
        Assert.Pass();
    }
    
    [Test]
    public void HireEmployee_Hire1MasterAnd11Employees_ArgumentException()
    {
        var factory = new Factory("Luch", 23, 0, 0, 100000, 200000, 10000, 30000);
        var statusOperationHistory = new List<bool>(11);
        
        factory.HireMaster();
        for (int i = 1; i <= 11; ++i)
        {
            var status = factory.HireEmployee();
            statusOperationHistory.Add(status);
        }
        
        var expected = new bool[11];
        expected = expected.Select(x => !x).ToArray();
        expected[expected.Length - 1] = false;
        
        CollectionAssert.AreEqual(expected.ToList(), statusOperationHistory);
    }
    [Test]
    public void HireEmployee_Hire1MasterAnd21Employees_ArgumentException()
    {
        var factory = new Factory("Luch", 23, 0, 0, 100000, 200000, 10000, 30000);
        var statusOperationHistory = new List<bool>(11);
        
        factory.HireMaster();
        for (int i = 1; i <= 21; ++i)
        {
            var status = factory.HireEmployee();
            statusOperationHistory.Add(status);
        }
        
        var expected = new bool[21];
        int counter = 0;
        expected = expected.Select(x =>
        {
            counter += 1;
            if (counter-1 >= 10)
                return false;
            return true;
        }).ToArray();
        
        CollectionAssert.AreEqual(expected.ToList(), statusOperationHistory);
    }
}