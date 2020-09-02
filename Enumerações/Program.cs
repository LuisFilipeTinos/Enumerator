using Enumerações.Entities;
using Enumerações.Entities.Enums;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Transactions;


namespace Enumerações.Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department´s name: ");
            string nameDepartment = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Worker level(Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dep = new Department(nameDepartment);
            Worker worker = new Worker(workerName, level, baseSalary, dep);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter # " + (i + 1) + " contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter the month and the year to calculate the income (MM/YYYY): ");
            string yearAndMonth = Console.ReadLine();
            int year = int.Parse(yearAndMonth.Substring(3));
            int month = int.Parse(yearAndMonth.Substring(0, 2));

            Console.WriteLine("Name: " + worker.WorkerName);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + month + "/" + year + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        
        
        }
    }
}
