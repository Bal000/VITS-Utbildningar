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

       

        public void SaveReport(Report report)
        {

            using (var context = new VitsDBEntities())
            {
                //Report rep = new Report
                //{
                //    EID = report.EID,
                //    MID = report.MID,
                //    Expenses = report.Expenses,
                //    Car = report.Car,
                //    Miles = report.Miles

                //};

                context.Report.AddObject(report);
                context.SaveChanges();
            }

        }

        public void SaveOffice(Office office)
        {
            using (var context = new VitsDBEntities())
            {
                context.Office.AddObject(office);
                context.SaveChanges();
            }
        }

        public void SaveMission(Mission mission)
        {
            using (var context = new VitsDBEntities())
            {
                context.Mission.AddObject(mission);
                context.SaveChanges();
            }
        }

        public void SaveTrip(Trip trip)
        {
            using (var context = new VitsDBEntities())
            {
                context.Trip.AddObject(trip);
                context.SaveChanges();
            }
        }

        public void SaveTravelAdvances(TravelAdvances travelAdvances)
        {
            using (var context = new VitsDBEntities())
            {
                context.TravelAdvances.AddObject(travelAdvances);
                context.SaveChanges();
            }
        }

        public void SaveEmployee(CompositeEmployee employee)
        {
            using (var context = new VitsDBEntities())
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

        public void SaveExpense(Expense expense)
        {
            using (var context = new VitsDBEntities())
            {
                context.Expense.AddObject(expense);
                context.SaveChanges();
            }
        }

        public void SaveDeviation(Deviation deviation)
        {
            using (var context = new VitsDBEntities())
            {
                context.Deviation.AddObject(deviation);
                context.SaveChanges();
            }
        }
        public void SaveCountry(Country country)
        {
            using (var context = new VitsDBEntities())
            {
                context.Country.AddObject(country);
                context.SaveChanges();
            }
        }

        public void SaveCostCenter(CostCenter costcenter)
        {

            using (var context = new VitsDBEntities())
            {
                context.CostCenter.AddObject(costcenter);
                context.SaveChanges();

            }
        }


        public List<CompositeEmployee> GetEmployees()
        {
            using (var context = new VitsDBEntities())
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
    }
}