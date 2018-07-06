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
            Conversion.Data.v1.communityContext _ctxV1 = new Conversion.Data.v1.communityContext();
            Conversion.Data.v2.CommunityV2Context _ctxV2 = new Conversion.Data.v2.CommunityV2Context();

            Console.Clear();
            Console.WriteLine("AFL Global Community Hub Data Conversion Tool v0.1");
            Console.WriteLine("==================================================");
            Console.WriteLine("Press y/Y to begin (this will DROP and CREATE v2 database): ");
            string _prompt = Console.ReadLine();

            if (_prompt.ToUpper() != "Y")
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.Clear();
                Console.Write("DROPPING Database...");
                _ctxV2.Database.EnsureDeleted();
                Console.WriteLine("success!");

                Console.Write("CREATING Database...");
                _ctxV2.Database.EnsureCreated();
                Console.WriteLine("success!");


                #region LOCATION
                Console.Clear();

                Console.WriteLine("Converting Locations");
                Console.WriteLine("====================");

                int _locConversionCount = 0;

                foreach (Conversion.Data.v1.Locations v1Location in _ctxV1.Locations)
                {
                    Console.Write(String.Format("Converting Location: {0}...", v1Location.LocName));

                    Conversion.Data.v2.Location v2Location = new Conversion.Data.v2.Location
                    {
                        LocationCountry = v1Location.LocCountry,
                        LocationName = v1Location.LocName
                    };

                    _ctxV2.Location.Add(v2Location);

                    try
                    {
                        _ctxV2.SaveChanges();
                        Console.WriteLine("success!");
                        _locConversionCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                    }
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Locations", _locConversionCount.ToString(), _ctxV1.Locations.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion

                //var employees = _ctx.Employees;
                //int idx = 1;

                //List<Conversion.Data.v1.EmployeeWork> employee_work = _ctx.EmployeeWork.ToList();

                //foreach(var employee in employees)
                //{
                //    Console.WriteLine(idx + ": " + employee.EmpLast);
                //    idx++;

                //    try
                //    {
                //        List<Conversion.Data.v1.EmployeeWork> employeework = _ctx.EmployeeWork.Where(x => x.EmployeeId == employee.EmployeeId).ToList();

                //        if (employeework.Count > 0)
                //        {
                //            Console.WriteLine("Found Some work!");
                //        }
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
            }

            Console.ReadLine();
        }
    }
}
