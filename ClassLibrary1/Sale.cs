using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Sale
    {
        public string Brand { get; set; } //Марка телефона
        public string Model { get; set; } //Модель телефона
        public int Quantity { get; set; } // Кол. проданных едениц
        public DateTime SaleDate { get; set; }
    }
}
