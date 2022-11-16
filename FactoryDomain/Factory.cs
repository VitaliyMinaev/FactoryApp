namespace FactoryDomain;

public class Factory : IComparable<Factory>
{
    /* Properties */
    public string Title { get; private set; }
    
    public int CountOfWorkshop { get; private set; }
    public int CountOfEmployee { get; private set; }
    public int CountOfMasters { get; private set; }
    
    /* Money contains in cents (type integer) */
    public int EmployeeSalary { get; private set; }
    public int MasterSalary { get; private set; }
    
    /* Profit for 1 month */
    public int ProfitFromEmployee { get; private set; }
    public int ProfitFromMaster { get; private set; }
    
    public Factory()
    {
        Title = String.Empty;

        CountOfWorkshop = CountOfEmployee = CountOfMasters = 0;
        EmployeeSalary = MasterSalary = 0;
        ProfitFromEmployee = ProfitFromMaster = 0;
    }

    public Factory(string titleOfFactory, int countOfWorkshop, int countOfEmployee, int countOfMasters,
        int employeeSalary, int masterSalary, int profitFromEmployee, int profitFromMaster)
    {
        if (CheckNumberOfEmployeeAndMaster(countOfEmployee, countOfMasters) == false)
        {
            throw new ArgumentException("Inappropriate balance between employee and masters");
        }
        
        Title = titleOfFactory;
        CountOfWorkshop = countOfWorkshop;
        CountOfEmployee = countOfEmployee;
        CountOfMasters = countOfMasters;
        EmployeeSalary = employeeSalary;
        MasterSalary = masterSalary;
        ProfitFromEmployee = profitFromEmployee;
        ProfitFromMaster = profitFromMaster;
    }
    
    /* Copy Constructor */
    public Factory(Factory other)
    {
        if (other == null)
        {
            throw new ArgumentNullException();
        }

        Title = other.Title;
        CountOfWorkshop = other.CountOfWorkshop;
        CountOfEmployee = other.CountOfEmployee;
        CountOfMasters = other.CountOfMasters;
        EmployeeSalary = other.EmployeeSalary;
        MasterSalary = other.MasterSalary;
        ProfitFromEmployee = other.ProfitFromEmployee;
        ProfitFromMaster = other.ProfitFromMaster;
    }
    
    /* Business logic */
    public bool HireEmployee()
    {
        if (CheckNumberOfEmployeeAndMaster(CountOfEmployee, CountOfMasters))
        {
            CountOfEmployee += 1;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool HireMaster()
    {
        if (CheckNumberOfEmployeeAndMaster(CountOfEmployee, CountOfMasters))
        {
            CountOfMasters += 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckNumberOfEmployeeAndMaster(int countOfEmployee, int countOfMasters)
    {
        if (countOfMasters == 0 && countOfEmployee == 0)
            return true;
        
        if (countOfEmployee + 1 <= countOfMasters * 10 && (countOfMasters * 10 - (countOfEmployee + 1) < 10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int FireEmployee()
    {
        CountOfEmployee -= 1;
        return CountOfEmployee;
    }
    public int FireMaster()
    {
        CountOfMasters -= 1;
        return CountOfMasters;
    }


    public int CompareTo(Factory? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException($"Comparable factory can not be null");
        }

        if (this.CountOfWorkshop < other.CountOfWorkshop)
        {
            return 1;
        }
        else if(this.CountOfWorkshop > other.CountOfWorkshop)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public static Factory operator +(Factory first, Factory second)
    {
        if (first == null || second == null)
        {
            throw new ArgumentNullException($"Factory in argument can not be null");
        }

        var newFactory = new Factory();

        newFactory.Title = first.Title + " - " + second.Title;
        newFactory.CountOfWorkshop = first.CountOfWorkshop + second.CountOfWorkshop;
        newFactory.CountOfEmployee = first.CountOfEmployee + second.CountOfEmployee;
        newFactory.CountOfMasters = first.CountOfMasters + second.CountOfMasters;
        newFactory.EmployeeSalary = first.EmployeeSalary > second.EmployeeSalary ? first.EmployeeSalary : second.EmployeeSalary;
        newFactory.MasterSalary = first.MasterSalary > second.MasterSalary ? first.MasterSalary : second.MasterSalary;
        newFactory.ProfitFromEmployee = first.ProfitFromEmployee > second.ProfitFromEmployee 
            ? first.ProfitFromEmployee : second.ProfitFromEmployee;
        newFactory.ProfitFromMaster = first.ProfitFromMaster > second.ProfitFromMaster 
            ? first.ProfitFromMaster : second.ProfitFromMaster;

        return newFactory;
    }
}