using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

namespace VitsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void SaveReport(CompositeReport report)
        {
                using (var context = new DATABASEVITSEntities())
                {
                    Report rep = new Report();
                    rep.REPID = report.REPID;
                    rep.EID = report.EID;
                    rep.MID = report.MID;
                    rep.Expenses = report.Expenses;
                    rep.Car = report.Car;
                    rep.Miles = report.Miles;

                    context.Report.AddObject(rep);
                    context.SaveChanges();
                }
             
            

        }

        public void SaveOffice(CompositeOffice office)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Office off = new Office();
                off.Name = office.Name;
                off.OrgNumber = office.OrgNumber;
                off.Adress = office.Adress;
                off.ZipCode = office.ZipCode;
                off.CID = office.CID;
               

                context.Office.AddObject(off);
                context.SaveChanges();
            }
        }

        public void SaveMission(CompositeMission mission)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Mission miss = new Mission();
                miss.OID = mission.OID;
                miss.Manager = mission.Manager;
                miss.Description = mission.Description;
                miss.StartDate = mission.StartDate;
                
                
                context.Mission.AddObject(miss);
                context.SaveChanges();
            }
        }

        public void SaveTrip(CompositeTrip trip)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Trip tri = new Trip();
                tri.EID = trip.EID;
                tri.MID = trip.MID;
                tri.CID = trip.CID;
                tri.StartDate = trip.StartDate;
                tri.StopDate = trip.StopDate;
                    
                
                context.Trip.AddObject(tri);
                context.SaveChanges();
            }
        }

        public void SaveTravelAdvances(CompositeTravelAdvances travelAdvances)
        {
            using (var context = new DATABASEVITSEntities())
            {
                TravelAdvances ta = new TravelAdvances();
                ta.Total = travelAdvances.Total;
                ta.Approved = travelAdvances.Approved;
                ta.Answered = travelAdvances.Answered;
                ta.Date = travelAdvances.Date;
                ta.EID = travelAdvances.EID;
                ta.MID = travelAdvances.MID;
                
                context.TravelAdvances.AddObject(ta);
                context.SaveChanges();
            }
        }

        public void SaveEmployee(CompositeEmployee employee)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Employee emp = new Employee();
                emp.Adress = employee.Adress;
                emp.City = employee.City;
                emp.Email = employee.Email;
                emp.FirstName = employee.FirstName;
                emp.IdNumber = employee.IdNumber;
                emp.LastName = employee.LastName;
                emp.Manager = employee.Manager;
                emp.ZipCode = employee.ZipCode;

                context.Employee.AddObject(emp);
                context.SaveChanges();
            }
        }

        public void SaveExpense(CompositeExpense expense)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Expense exp = new Expense();
                exp.REPID = expense.REPID;
                exp.CCID = expense.CCID;
                exp.Sum = expense.Sum;
                exp.VAT = expense.VAT;
                exp.Date = expense.Date;
                exp.Description = expense.Description;

                context.Expense.AddObject(exp);
                context.SaveChanges();
            }
        }

        public void SaveSubsistence(CompositeSubsistence subsistence)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Subsistence sub = new Subsistence();
                sub.REPID = subsistence.REPID;
                sub.CID = subsistence.CID;
                sub.SUM = subsistence.SUM;
                sub.DATE = subsistence.DATE;

                context.Subsistence.AddObject(sub);
                context.SaveChanges();
            }
        }

        public void SaveDeviation(CompositeDeviation deviation)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Deviation dev = new Deviation();
                dev.REPID = deviation.REPID;
                dev.StartDate = deviation.StartDate;
                dev.StopDate = dev.StopDate;
                
                context.Deviation.AddObject(dev);
                context.SaveChanges();
            }
        }
        public void SaveCountry(CompositeCountry country)
        {
            using (var context = new DATABASEVITSEntities())
            {
                Country co = new Country();
                co.Name = country.Name;
                
                context.Country.AddObject(co);
                context.SaveChanges();
            }
        }

        public void SaveCostCenter(CompositeCostCenter costcenter)
        {
            using (var context = new DATABASEVITSEntities())
            {
                CostCenter cc = new CostCenter();
                cc.CCID = costcenter.CCID;
                cc.Name = costcenter.Name;
                
                context.CostCenter.AddObject(cc);
                context.SaveChanges();
            }
        }


        public List<CompositeEmployee> GetEmployees()
        {
            using (var context = new DATABASEVITSEntities())
            {
                List<CompositeEmployee> employees = new List<CompositeEmployee>();
                employees = context.Employee.Select(x => new CompositeEmployee
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Adress = x.Adress,
                    ZipCode = x.ZipCode,
                    City = x.City,
                    IdNumber = x.IdNumber,
                    Manager = x.Manager
                }).ToList();
                return employees;
            }
        }

        public List<CompositeOffice> GetOffices()
        {
            using (var context = new DATABASEVITSEntities())
            {
                List<CompositeOffice> offices = new List<CompositeOffice>();
                offices = context.Office.Select(x => new CompositeOffice
                {
                    
                    
                }).ToList();
                return offices;
            }
        }


        public List<CompositeExpense> GetExpenses()
        {
            using (var context = new DATABASEVITSEntities())
            {
                List<CompositeExpense> expenses = new List<CompositeExpense>();
                expenses = context.Expense.Select(x => new CompositeExpense
                {
                    EXPID = x.EXPID,
                    REPID = x.REPID,
                    CCID = x.CCID,
                    Sum = x.Sum,
                    VAT = x.VAT,
                    Date = x.Date,
                    Description = x.Description
                }).ToList();
                return expenses;
            }
        }

        public List<CompositeCostCenter> GetCostCenter()
        {
            using (var context = new DATABASEVITSEntities())
            {
                List<CompositeCostCenter> costcenter = new List<CompositeCostCenter>();
                costcenter = context.CostCenter.Select(x => new CompositeCostCenter
                {
                    CCID = x.CCID,
                    Name = x.Name
                }).ToList();
                return costcenter;
            }
        }
    }
}