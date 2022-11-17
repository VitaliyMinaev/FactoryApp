using FactoryDomain;

namespace FactoryTest;

public class FactoryFireTests
{
    private Factory _setUpFactory;
    [SetUp]
    public void SetUp()
    {
        _setUpFactory = new Factory("Luch", 23, 10, 1, 50000, 100000, 100000, 300000);
    }
    
    [Test]
    public void FireEmployee_Hire1Master10EmployeeAndFire1Employee_Success()
    {
        var actual = _setUpFactory.FireEmployee();

        bool expected = true;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}