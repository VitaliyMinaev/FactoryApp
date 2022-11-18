using System;

namespace FactoryForm.Domain
{
    public class Factory : IComparable<Factory>
    {
        /* Properties */
        public string Title { get; set; }

        public int CountOfWorkshop { get; set; }
        public int CountOfEmployee { get; set; }
        public int CountOfMasters { get; set; }

        /* Money contains in cents (type integer) */
        public int EmployeeSalary { get; set; }
        public int MasterSalary { get; set; }

        /* Profit for 1 month */
        public int ProfitFromEmployee { get; set; }
        public int ProfitFromMaster { get; set; }

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
            if (EstimateNumberOfEmployeeAndMaster(countOfEmployee, countOfMasters) == false)
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
            if (EstimateNumberOfEmployeeAndMaster(CountOfEmployee + 1, CountOfMasters))
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
            if (EstimateNumberOfEmployeeAndMaster(CountOfEmployee, CountOfMasters + 1))
            {
                CountOfMasters += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FireEmployee()
        {
            if (EstimateNumberOfEmployeeAndMaster(CountOfEmployee - 1, CountOfMasters))
            {
                CountOfEmployee -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FireMaster()
        {
            if (EstimateNumberOfEmployeeAndMaster(CountOfEmployee, CountOfMasters - 1))
            {
                CountOfMasters -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }


        public int CompareTo(Factory other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"Comparable factory can not be null");
            }

            if (this.CountOfWorkshop > other.CountOfWorkshop)
            {
                return 1;
            }
            else if (this.CountOfWorkshop < other.CountOfWorkshop)
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

        private bool EstimateNumberOfEmployeeAndMaster(int countOfEmployee, int countOfMasters)
        {
            if (countOfEmployee <= countOfMasters * 10 && (countOfEmployee == 0 || countOfMasters * 10 - countOfEmployee <= 10))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}