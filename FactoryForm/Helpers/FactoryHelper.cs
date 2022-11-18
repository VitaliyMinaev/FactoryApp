using FactoryForm.Domain;

namespace FactoryForm.Helpers
{
    public static class FactoryHelper
    {
        public static int CalculateProfit(this Factory factory, int investedMoney)
        {
            while (investedMoney >= factory.EmployeeSalary)
            {
                bool operationSuccess = factory.HireEmployee();

                if (operationSuccess == true)
                {
                    investedMoney -= factory.EmployeeSalary;
                }
                else if (investedMoney >= factory.MasterSalary)
                {
                    factory.HireMaster();
                    investedMoney -= factory.MasterSalary;
                }
                else
                {
                    break;
                }
            }

            return factory.CountOfEmployee * factory.ProfitFromEmployee + factory.CountOfMasters * factory.ProfitFromMaster;
        }
    }
}