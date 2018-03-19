using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFNgAppMV.Models
{
    public class EmployeeDataAccessLayer
    {
        Ang5TestContext db = new Ang5TestContext();

        public IEnumerable<TblEmployee> GetAllEmployees()
        {
            try
            {
                return db.TblEmployee.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddEmployee (TblEmployee emp)
        {
            try
            {
                db.TblEmployee.Add(emp);
                db.SaveChanges();
                return emp.EmployeeId;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateEmployee(TblEmployee emp)
        {
            try
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return emp.EmployeeId;
            }
            catch
            {
                throw;
            }
        }

        public TblEmployee GetEmployee (int id)
        {
            try
            {
                return db.TblEmployee.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteEmployee (int id)
        {
            try
            {
                var emp = db.TblEmployee.Find(id);
                db.TblEmployee.Remove(emp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public IList<TblCities> GetCities()
        {
            var cities = new List<TblCities>();
            cities = db.TblCities.ToList();

            return cities;
        }
    }
}
