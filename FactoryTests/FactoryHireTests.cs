using FactoryDomain;

namespace FactoryTest;

public class FactoryHireTests
{
    private Factory _factory;
    [SetUp]
    public void SetUp()
    {
        _factory = new Factory("Luch", 23, 0, 0, 100000, 200000, 10000, 30000);
    }
    
    [Test]
    public void HireEmployee_Hire1MasterAnd5Employees_AllOperationStatusAreTrue()
    {
        var actualStatuses = new List<bool>();
        _factory.HireMaster();
        for (int i = 1; i <= 5; ++i)
        {
            actualStatuses.Add(_factory.HireEmployee());
        }

        var expectedStatuses = new List<bool>
        {
            true, true, true, true, true
        };
        
        CollectionAssert.AreEqual(expectedStatuses, actualStatuses);
    }
    [Test]
    public void HireEmployee_Hire1MasterAnd11Employee_LastOperationStatusAreFalse()
    {
        var actualStatuses = new List<bool>();
        
        _factory.HireMaster();
        for (int i = 1; i <= 11; ++i)
        {
            var status = _factory.HireEmployee();
            actualStatuses.Add(status);
        }

        List<bool> expected = Enumerable.Range(0, 11).Select(x => true).ToList();
        expected[expected.Count - 1] = false;
        
        CollectionAssert.AreEqual(expected.ToList(), actualStatuses);
    }
    [Test]
    public void HireEmployee_Hire3MasterAnd30Employee_AllHiresAreSuccess()
    {
        for (int i = 0; i < 30; ++i)
        {
            if (i % 10 == 0)
            {
                if (_factory.HireMaster() == false)
                {
                    Assert.Fail($"Fail to hire master after - {_factory.CountOfMasters}");
                }
            }
            else
            {
                if (_factory.HireEmployee() == false)
                {
                    Assert.Fail($"Fail to hire employee after - {_factory.CountOfEmployee}");
                }
            }
        }
        
        Assert.Pass();
    }
    [Test]
    public void HireEmployee_Hire3MasterAnd31Employee_LastEmployeeHireAreIncorrect()
    {
        int addmissibleValueForMasters = 3, masterCounter = 0;
        for (int i = 0; i < 31; ++i)
        {
            if (i % 10 == 0 && masterCounter < addmissibleValueForMasters)
            {

                if (_factory.HireEmployee() == false)
                {
                    Assert.Fail($"Can not hire master after - {_factory.CountOfMasters}");
                }
                masterCounter += 1;
            }
            else
            {
                // 31 employee iteration
                if (_factory.CountOfEmployee == 30 && _factory.HireEmployee() == false)
                {
                    Assert.Pass("Expected behaviour");
                }
                else if(_factory.CountOfEmployee == 30 && _factory.HireEmployee() == true)
                {
                    Assert.Fail("31 employee can not be hired cause you have only 3 master");
                }
                else if (_factory.HireEmployee() == false)
                {
                    Assert.Fail($"Can not hire employee after - {_factory.CountOfEmployee}");
                }
            }
        }
    }
}