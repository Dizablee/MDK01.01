using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    public class StaffModel
    {
        public List<Staff> Staff { get; }

        public StaffModel()
        {
            Staff = new List<Staff>
        {
           new Staff { Name = "Иван", Surname = "Иванов", Age = "34", DateBirth = new DateTime(1990, 11, 1), Profession = "Бухгалтеры", Site = "Специалисты.org" },
           new Staff { Name = "Артем", Surname = "Гога", Age = "17", DateBirth = new DateTime(2006, 01, 5), Profession = "Бухгалтеры", Site = "Специалисты.org" },
            new Staff { Name = "Петр", Surname = "Петров", Age = "29", DateBirth = new DateTime(1995, 5, 15), Profession = "Программисты", Site = "Профессия.com" },
            new Staff { Name = "Анна", Surname = "Сидорова", Age = "26", DateBirth = new DateTime(1998, 2, 20), Profession = "Товароведы", Site = "Фриланс.ru" },
            new Staff { Name = "Ольга", Surname = "Козлова", Age = "31", DateBirth = new DateTime(1993, 8, 10), Profession = "Бухгалтеры", Site = "Специалисты.org" },
        };
        }

        public List<Staff> GetStaffByProfessionAndSite(string profession, string site)
        {
            return Staff.Where(s => s.Profession.Trim().ToLower() == profession.Trim().ToLower() &&
                            s.Site.Trim().ToLower() == site.Trim().ToLower())
                .ToList();
        }
    }
}
