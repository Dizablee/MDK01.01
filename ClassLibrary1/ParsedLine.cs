using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ParsedLine
    {
        public string RawLine { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
