using Enumerações.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enumerações.Entities
{
    class Worker
    {
        public string WorkerName { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public List<HourContract> List { get; set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            WorkerName = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            List.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            List.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(HourContract obj in List)
            {
                if(obj.Date.Year == year && obj.Date.Month == month)
                {
                    sum = sum + obj.TotalValue();
                }
            }

            return sum;
        }
    }
}
