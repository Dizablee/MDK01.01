using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Sale
    {

        [DisplayName("Марка")]
        public string Brand { get; set; }
        [DisplayName("Модель")]
        public string Model { get; set; } //Модель телефона
        [DisplayName("Кол. проданных единиц")]
        public int Quantity { get; set; }// Кол. проданных едениц
        [DisplayName("Дата продажи")]
        public DateTime SaleDate { get; set; }
    }
}
