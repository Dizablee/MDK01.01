using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
     public class Product
    {
        [DisplayName("Марка")]
        public string Brand { get; set; } //Марка телефона
        [DisplayName("Модель")]
        public string Model { get; set; } //Модель телефона
        [DisplayName("Цена")]
        public decimal Price { get; set; } //Цена
        [DisplayName("Категория")]
        public string Category { get; set; } //Товарная группа
        [DisplayName("Кол. на складе")]
        public int Quantity { get; set; }

    }
}
