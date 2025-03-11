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
            Staff = new List<Staff>();
            Staff.Add(new Staff { Name = "Иван", Surname = "Иванов", Age = "34", DateBirth = new System.DateTime(1996, 11, 1) });
            
        }  

    }
}
