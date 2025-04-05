﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2: Form
    {
        private Store store;
        public Form2(Store store)
        {
            InitializeComponent();
            this.store = store;
            LoadStockData();
        }
        private void LoadStockData()
        {
            dgvStock.DataSource = store.CalculateStock();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Сохранить остатки"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var product  in store.Products)
                    {
                        writer.WriteLine($"{product.Brand};{product.Model};{ProductStock.RemainingQuantity}");
                    }
                }
                MessageBox.Show("Остатки сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
