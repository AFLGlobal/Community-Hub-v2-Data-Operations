using System;
using System.Collections.Generic;
using Conversion.Data;

using System.Linq;

namespace v1_to_v2_data_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Conversion.Data.v1.communityContext _ctx = new Conversion.Data.v1.communityContext();

            var employees = _ctx.Employees;
            int idx = 1;

            List<Conversion.Data.v1.EmployeeWork> employee_work = _ctx.EmployeeWork.ToList();

            foreach(var employee in employees)
            {
                Console.WriteLine(idx + ": " + employee.EmpLast);
                idx++;

                try
                {
                    List<Conversion.Data.v1.EmployeeWork> employeework = _ctx.EmployeeWork.Where(x => x.EmployeeId == employee.EmployeeId).ToList();

                    if (employeework.Count > 0)
                    {
                        Console.WriteLine("Found Some work!");
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }

            Console.ReadLine();
        }
    }
}
