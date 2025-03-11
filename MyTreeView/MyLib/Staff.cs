using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Staff
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public DateTime DateBirth { get; set; }

        public static Dictionary<string, string> Aliases = new Dictionary<string, string>()
        {
            { nameof(Name), "Имя"},
            { nameof(Surname), "Фамилия"},
            { nameof(Age), "Возраст"},
            {nameof(DateBirth), "Дата рождения" }

        };
    }
}
