using EmpWageCompuationNew;

namespace EmpWageCompuationNew
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilderArray empWageBuilder = new EmpWageBuilderArray();
            Console.WriteLine("Enter i to Enter Company Details or otherwise enter any key :");
            var input = Console.ReadLine();
            while (input == "i")
            {
                var obj = UserInput();
                empWageBuilder.addcompanyEmpWage(obj.company, obj.empRatePerHour, obj.numOfWorkingDays, obj.maxHoursPerMonth);
                Console.WriteLine("Enter i to Enter Company Details or otherwise enter any key: ");
                input = Console.ReadLine();
            }
            empWageBuilder.computeEmpWage();
        }
        public static CompanyEmpwage UserInput()
        {
            Console.WriteLine("Enter Company Name: ");
            string company = Console.ReadLine();

            Console.WriteLine("Enter Employee Rate Per Hour: ");
            int empRatePerHour = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter No of Working Days: ");
            int numOfWorkingDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Maximum Hours Per Month: ");
            int maxWorkingHoursPerMonth = Convert.ToInt32(Console.ReadLine());

            return new
                CompanyEmpwage(company, empRatePerHour, numOfWorkingDays, maxWorkingHoursPerMonth);
            {
                company = company;
                empRatePerHour = empRatePerHour;
                numOfWorkingDays = numOfWorkingDays;
                maxWorkingHoursPerMonth = maxWorkingHoursPerMonth;
            };
        }
    }
}