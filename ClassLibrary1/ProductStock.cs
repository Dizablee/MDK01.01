using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ProductStock
    {
        [DisplayName("Модель")]
        public string Model { get; set; }
        [DisplayName("Марка")]
        public string Brand { get; set; }
        [DisplayName("Остатки на складе")]
        public int RemainingQuantity { get; set; }
    }
}
