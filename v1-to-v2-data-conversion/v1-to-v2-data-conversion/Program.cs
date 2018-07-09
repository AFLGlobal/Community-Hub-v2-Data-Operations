using System;
using System.Collections.Generic;
using Conversion.Data;
using System.Globalization;


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

                #region SERVICE_TYPE
                Console.Clear();

                Console.WriteLine("Converting Service Types");
                Console.WriteLine("========================");

                int _servTypeConversionCount = 0;

                foreach (Conversion.Data.v1.ServiceTypes v1ServiceType in _ctxV1.ServiceTypes)
                {
                    Console.Write(String.Format("Converting Service Type: {0}...", v1ServiceType.ServiceType));

                    Conversion.Data.v2.ServiceType v2ServiceType = new Conversion.Data.v2.ServiceType
                    {
                        ServiceTypeValue = v1ServiceType.ServiceType
                    };

                    _ctxV2.ServiceType.Add(v2ServiceType);

                    try
                    {
                        _ctxV2.SaveChanges();
                        Console.WriteLine("success!");
                        _servTypeConversionCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                    }
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Service Types", _servTypeConversionCount.ToString(), _ctxV2.ServiceType.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion

                #region WAIVER
                Console.Clear();

                Console.WriteLine("Converting Waivers");
                Console.WriteLine("==================");

                int _waiverConversionCount = 0;

                foreach (Conversion.Data.v1.Waivers v1Waiver in _ctxV1.Waivers)
                {
                    Console.Write(String.Format("Converting Waiver: {0}...", v1Waiver.WaiverText));

                    Conversion.Data.v2.Waiver v2Waiver = new Conversion.Data.v2.Waiver
                    {
                        WaiverText = v1Waiver.WaiverText,
                        WaiverUrl = v1Waiver.WaiverUrl
                    };

                    _ctxV2.Waiver.Add(v2Waiver);

                    try
                    {
                        _ctxV2.SaveChanges();
                        Console.WriteLine("success!");
                        _waiverConversionCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                    }
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Waivers", _waiverConversionCount.ToString(), _ctxV1.Waivers.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion

                #region PROJECT
                Console.Clear();

                Console.WriteLine("Converting Projects");
                Console.WriteLine("===================");

                int _projectConversionCount = 0;

                foreach (Conversion.Data.v1.Projects v1Project in _ctxV1.Projects)
                {
                    int? _locId = null;
                    int? _waiverId = null;
                    int? _servTypeId = null;
                    bool _tshirtrequired = false;

                    Console.Write("Converting Project: {0}...", v1Project.ProjectName);

                    // Get Location, Service Type and Waiver IDs
                    if (v1Project.LocationId != null)
                    {
                        Conversion.Data.v1.Locations _tempV1Loc = _ctxV1.Locations.Where(l => l.LocationId == v1Project.LocationId).First();
                        Conversion.Data.v2.Location _tempV2Loc = _ctxV2.Location.Where(l => l.LocationName == _tempV1Loc.LocName && l.LocationCountry == _tempV1Loc.LocCountry).First();

                        _locId = _tempV2Loc.LocationId;
                    }

                    if (v1Project.ServiceTypeId != null)
                    {
                        Conversion.Data.v1.ServiceTypes _tempV1ST = _ctxV1.ServiceTypes.Where(st => st.ServiceTypeId == v1Project.ServiceTypeId).First();
                        Conversion.Data.v2.ServiceType _tempV2ST = _ctxV2.ServiceType.Where(st => st.ServiceTypeValue == _tempV1ST.ServiceType).First();

                        _servTypeId = _tempV2ST.ServiceTypeId;
                    }

                    if (v1Project.WaiverLink != "" && v1Project.WaiverLink != null)
                    {
                        Conversion.Data.v1.Waivers _tempV1Waiver = _ctxV1.Waivers.Where(waive => waive.WaiverUrl == v1Project.WaiverLink).First();
                        Conversion.Data.v2.Waiver _tempV2Waiver = _ctxV2.Waiver.Where(waive => waive.WaiverText == _tempV1Waiver.WaiverText && waive.WaiverUrl == _tempV1Waiver.WaiverUrl).First();

                        _waiverId = _tempV2Waiver.WaiverId;
                    }

                    if (v1Project.TshirtRequired != null)
                    {
                        _tshirtrequired = Convert.ToBoolean(v1Project.TshirtRequired);
                    }

                    Conversion.Data.v2.Project v2Project = new Conversion.Data.v2.Project()
                    {
                        WaiverId = _waiverId,
                        ServiceTypeId = _servTypeId,
                        LocationId = _locId,
                        Completed = v1Project.Completed,
                        DateEmailSent = v1Project.DateEmailSent,
                        Deleted = v1Project.Deleted,
                        ProjectDescription = v1Project.ProjectDescription,
                        ProjectName = v1Project.ProjectName,
                        TshirtRequired = _tshirtrequired
                    };

                    _ctxV2.Project.Add(v2Project);

                    try
                    {
                        _ctxV2.SaveChanges();
                        Console.WriteLine("success!");
                        _projectConversionCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                    }
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Projects", _projectConversionCount.ToString(), _ctxV1.Projects.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion

                #region WORK_OPPORTUNITY

                Console.Clear();

                Console.WriteLine("Converting Work Opportunities");
                Console.WriteLine("===================");

                int _woConversionCount = 0;

                foreach (Conversion.Data.v1.WorkOpportunities v1WO in _ctxV1.WorkOpportunities)
                {
                    Console.Write("Converting Work Opportunity: {0}...", v1WO.Description);

                    // Get Project from V1 Work Opp THEN get V2 equivalent
                    Conversion.Data.v2.Project _v2Project = new Conversion.Data.v2.Project();
                    Conversion.Data.v1.Projects _v1Project = new Conversion.Data.v1.Projects();

                    try
                    {
                        _v1Project = _ctxV1.Projects.Where(proj => proj.ProjectId == v1WO.ProjectId).First();
                        _v2Project = _ctxV2.Project.Where(proj => proj.ProjectDescription.Contains(_v1Project.ProjectDescription) && proj.ProjectName.Contains(_v1Project.ProjectName)).First();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                        continue;                        
                    }

                    double _woHours = 0;
                    DateTime _woStart = DateTime.MinValue, _woEnd = DateTime.MinValue;

                    if (v1WO.Wohours != null)
                    {
                        _woHours = (double)v1WO.Wohours;
                    }

                    if (v1WO.WostartDateTime != null)
                    {
                        _woStart = (DateTime)v1WO.WostartDateTime;
                    }

                    if(v1WO.WoendDateTime!=null)
                    {
                        _woEnd = (DateTime)v1WO.WoendDateTime;
                    }

                    Conversion.Data.v2.WorkOpportunity _v2WO = new Conversion.Data.v2.WorkOpportunity()
                    {
                        AllowGuests = v1WO.AllowGuests,
                        Description = v1WO.Description,
                        LunchAvailable = v1WO.LunchAvailable,
                        MaxVolunteers = v1WO.MaxVolunteers,
                        ProjectId = _v2Project.ProjectId,
                        WorkOpportunityHours = _woHours,
                        WorkOpportunityStartDateTime = _woStart,
                        WorkOpportunityStopDateTime = _woEnd
                    };

                    _ctxV2.WorkOpportunity.Add(_v2WO);

                    try
                    {
                        _ctxV2.SaveChanges();
                        Console.WriteLine("success!");
                        _woConversionCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("failed!");
                    }
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Work Opportunities", _woConversionCount.ToString(), _ctxV1.WorkOpportunities.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion

                #region EMPLOYEE

                Console.Clear();

                Console.WriteLine("Converting Employees");
                Console.WriteLine("==================");

                int _employeeConversionCount = 0;
                int _idxEmployeeNumber = 1;

                TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

                foreach (Conversion.Data.v1.Employees v1Employee in _ctxV1.Employees)
                {
                    Console.Write(String.Format("{1}: Converting Employee: {0}...", v1Employee.EmpFirst + " " + v1Employee.EmpLast, _idxEmployeeNumber));

                    if (v1Employee.EmpFirst.Length > 0 && v1Employee.EmpLast.Length > 0 && v1Employee.EmpEmail.Length > 0)
                    {
                        // Get Location
                        int _locId = 1;

                        if (v1Employee.LocationId != null)
                        {
                            if (v1Employee.LocationId == 0)
                            {
                                _locId = 1;
                            }
                            else
                            {
                                Conversion.Data.v1.Locations _tempV1Loc = _ctxV1.Locations.Where(l => l.LocationId == v1Employee.LocationId).First();
                                Conversion.Data.v2.Location _tempV2Loc = _ctxV2.Location.Where(l => l.LocationName == _tempV1Loc.LocName && l.LocationCountry == _tempV1Loc.LocCountry).First();
                                _locId = _tempV2Loc.LocationId;
                            }
                        }

                        bool _isAdmin = false;
                        bool _canCreate = false;
                        bool _isLocked = false;
                        DateTime _lastAccess = Convert.ToDateTime("1/1/1900");

                        try
                        {
                            Conversion.Data.v1.Accounts _tempV1Account = _ctxV1.Accounts.Where(acct => acct.EmployeeId == v1Employee.EmployeeId).First();
                            _isAdmin = _tempV1Account.IsAdmin;
                            _canCreate = _tempV1Account.CanCreate;
                            _isLocked = _tempV1Account.IsLocked;
                        }
                        catch (Exception ex)
                        {

                        }

                        if (v1Employee.EmpMiddle == null)
                        {
                            v1Employee.EmpMiddle = "";
                        }

                        Conversion.Data.v2.Employee v2Employee = new Conversion.Data.v2.Employee()
                        {
                            EmployeeFirstName = _textInfo.ToTitleCase(v1Employee.EmpFirst.ToLower()),
                            EmployeeLastName = _textInfo.ToTitleCase(v1Employee.EmpLast.ToLower()),
                            LocationId = _locId,
                            EmployeeEmail = v1Employee.EmpEmail,
                            EmployeePhone = v1Employee.EmpPhone,
                            EmployeeCellPhone = v1Employee.EmpCell,
                            Title = v1Employee.Title,
                            EmployeeMiddleName = _textInfo.ToTitleCase(v1Employee.EmpMiddle.ToLower()),
                            EmployeeAlternateEmail = v1Employee.EmpAltEmail,
                            EmployeeStreet = v1Employee.EmpStreet,
                            EmployeeCity = v1Employee.EmpCity,
                            EmployeeState = v1Employee.EmpState,
                            EmployeeZip = v1Employee.EmpPostal,
                            EmployeePayGroup = v1Employee.EmpPayGroup,
                            MId = v1Employee.Mid,
                            IsAdmin = _isAdmin,
                            IsLocked = _isLocked,
                            LastAccessDateTime = _lastAccess,
                            CanCreate = _canCreate,
                            AdminCommunityService = _isAdmin,
                            AdminAssociateManagement = _isAdmin,
                            AdminReporting = _isAdmin,
                            AdminUnitedWay = _isAdmin,
                            UseActiveDirectory = false,
                            EmployeePassword = "",
                            Deleted = v1Employee.Deleted,
                        };

                        // See if email already exists and kick out new addition
                        try
                        {
                            Conversion.Data.v2.Employee _testEmployee = _ctxV2.Employee.Where(emp => emp.EmployeeEmail.ToLower() == v2Employee.EmployeeEmail.ToLower()).First();
                            Console.WriteLine("skipped!");
                        }
                        catch(Exception ex)
                        {
                            _ctxV2.Employee.Add(v2Employee);

                            try
                            {
                                _ctxV2.SaveChanges();
                                Console.WriteLine("success!");
                                _employeeConversionCount++;
                            }
                            catch (Exception ex1)
                            {
                                Console.WriteLine("failed!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("skipped!");
                    }

                    _idxEmployeeNumber++;
                }

                Console.WriteLine(String.Format("Converted {0} of {1} Employees", _employeeConversionCount.ToString(), _ctxV1.Employees.Count().ToString()));
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();

                #endregion


                //#region EMPLOYEE
                //Console.Clear();

                //Console.WriteLine("Converting Employees");
                //Console.WriteLine("====================");

                //int _employeeConversionCount = 0;

                //foreach (Conversion.Data.v1.Employees v1Employee in _ctxV1.Employees)
                //{

                //}

                //#endregion

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
