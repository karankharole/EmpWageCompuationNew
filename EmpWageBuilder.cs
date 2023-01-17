using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpWageCompuationNew
{
    public class EmpWageBuilder : IComputeEmpWage
    {
        public const int IS_FULL_TIME = 1, IS_PART_TIME = 2;

        public List<CompanyEmpwage> companyEmpWageList;
        private Dictionary<string, CompanyEmpwage> empWageDictionary;

        public EmpWageBuilder()
        {
            this.companyEmpWageList = new List<CompanyEmpwage>();
            this.empWageDictionary = new Dictionary<string, CompanyEmpwage>();
        }

        public void addcompanyEmpWage(string company, int empRatePerHour, int numOfWorkingDays, int maxHoursPerMonth)
        {
            CompanyEmpwage companyEmpwage = new CompanyEmpwage(company, empRatePerHour, numOfWorkingDays, maxHoursPerMonth);
            this.companyEmpWageList.Add(companyEmpwage);
            this.empWageDictionary.Add(company, companyEmpwage);
        }
        public void computeEmpWage()
        {
            foreach (CompanyEmpwage companyEmpWage in this.companyEmpWageList)
            {
                companyEmpWage.setTotalEmpWage(this.computeEmpWage(companyEmpWage));
                Console.WriteLine(companyEmpWage.toString());
            }
        }
        public CompanyEmpwage companyDetailsByName(string companyName)
        {
            return this.companyEmpWageList.Find(X => X.company == companyName);
        }
        private int computeEmpWage(CompanyEmpwage companyEmpWage)
        {
            // Variables
            int empHrs = 0, totalEmpHrs = 0, totalWorkingDays = 0;
            // Comutation
            while (totalEmpHrs <= companyEmpWage.maxHoursPerMonth && totalWorkingDays < companyEmpWage.numOfWorkingDays)
            {
                totalWorkingDays++;
                Random random = new Random();
                int empCheck = random.Next(0, 3);
                switch (empCheck)
                {
                    case IS_FULL_TIME:
                        empHrs = 8;
                        break;
                    case IS_PART_TIME:
                        empHrs = 4;
                        break;
                    default:
                        empHrs = 0;
                        break;
                }
                totalEmpHrs += empHrs;
                Console.WriteLine("Days : " + totalWorkingDays + "Emp Hrs : " + empHrs);
                int dailyWage = empHrs * companyEmpWage.empRatePerHour;
                Console.WriteLine("Daily Wage of Employee Is: " + dailyWage);
            }
            return totalEmpHrs * companyEmpWage.empRatePerHour;
        }

        public int getTotalWage(string company)
        {
            return this.empWageDictionary[company].totalEmpWage;
        }

        void IComputeEmpWage.addcompyEmpWage(string Company, int empRatePerHour, int numOfWorkingDays, int maxHourPerMonth)
        {
            throw new NotImplementedException();
        }

        void IComputeEmpWage.computeEmpWage()
        {
            throw new NotImplementedException();
        }

        void IComputeEmpWage.getTotalWage(string company)
        {
            throw new NotImplementedException();
        }
    }
}
