using FactoryForm.Domain;

namespace FactoryForm.Helpers
{
    public static class FactoryHelper
    {
        public static int CalculateProfit(this Factory factory, int investedMoney)
        {
            int countOfNewEmployee = 0, countOfNewMasters = 0;
            while (investedMoney >= factory.EmployeeSalary)
            {
                bool operationSuccess = factory.HireEmployee();

                if (operationSuccess == true)
                {
                    investedMoney -= factory.EmployeeSalary;
                    countOfNewEmployee += 1;
                }
                else if (investedMoney >= factory.MasterSalary)
                {
                    factory.HireMaster();
                    investedMoney -= factory.MasterSalary;
                    countOfNewMasters += 1;
                }
                else
                {
                    break;
                }
            }

            return countOfNewEmployee * factory.ProfitFromEmployee + countOfNewMasters * factory.ProfitFromMaster;
        }
    }
}