using EmpWageCompuationNew;

namespace EmpWageCompuationNew
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmpWageBuilder empWageBuilder = new EmpWageBuilder();
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
            Console.WriteLine("Enter g to get Company Details : ");
            var name = Console.ReadLine();
            while (name == "g")
            {
                var detail = empWageBuilder.companyDetailsByName(Console.ReadLine());
                Console.WriteLine("Comapny Name : " + detail.company);
                Console.WriteLine("Employee Rate Per Hour : " + detail.empRatePerHour);
                Console.WriteLine("Number Of Working Days : " + detail.numOfWorkingDays);
                Console.WriteLine("Maximum Hours Per Month : " + detail.maxHoursPerMonth);

                Console.WriteLine("Enter g to get Company Details : ");
                name = Console.ReadLine();
            }
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

            return new CompanyEmpwage(company, empRatePerHour, numOfWorkingDays, maxWorkingHoursPerMonth);
            {
                company = company;
                empRatePerHour = empRatePerHour;
                numOfWorkingDays = numOfWorkingDays;
                maxWorkingHoursPerMonth = maxWorkingHoursPerMonth;
            };
        }
    }
}