using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp3
{
    public partial class Form1: Form
    {
        
        private Store store = new Store();
        private SalesFileValidator salesFileValidator = new SalesFileValidator();


        public Form1()
        {
            InitializeComponent();
           
            btnGenerateReport.Click += btnGenerateReport_Click;

        }
        private void DgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Rows[e.RowIndex].DataBoundItem is ParsedLine line && !line.IsValid)
            {
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void DgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Rows[e.RowIndex].DataBoundItem is ParsedLine line && !line.IsValid)
            {
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void btnShowStock_Click(object sender, EventArgs e)
        
        {
            Form2 form2 = new Form2(store);
            form2.Show();
        
        
        
        }  
             
        

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;
            var report = store.GetSalesReport(start, end);
            dgvSales.DataSource = report;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Text Files|*.txt" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReportGenerator.GenerateReport(store.GetSalesReport(dtpStart.Value, dtpEnd.Value), saveFileDialog.FileName);
                MessageBox.Show("Отчет сохранен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void загрузитьСписокТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var parsedLines = salesFileValidator.LoadProductFileWithValidation(openFileDialog.FileName);

                store.Products.Clear();
                store.Products.AddRange(salesFileValidator.Products);

                dgvProducts.CellFormatting -= DgvProducts_CellFormatting; // на всякий случай отписываем
                dgvProducts.DataSource = null;

                bool hasErrors = parsedLines.Any(p => !p.IsValid);
                if (hasErrors)
                {
                    dgvProducts.DataSource = parsedLines;
                    dgvProducts.CellFormatting += DgvProducts_CellFormatting;
                }
                else
                {
                    dgvProducts.DataSource = store.Products.ToList();
                }
            }
        }
        private void загрузитьСписокПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Выберите файл продаж"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var parsedLines = salesFileValidator.LoadSalesFileWithValidation(openFileDialog.FileName);

                store.Sales.Clear();
                store.Sales.AddRange(salesFileValidator.Sales);

                dgvSales.CellFormatting -= DgvSales_CellFormatting;
                dgvSales.DataSource = null;

                bool hasErrors = parsedLines.Any(p => !p.IsValid);
                if (hasErrors)
                {
                    dgvSales.DataSource = parsedLines;
                    dgvSales.CellFormatting += DgvSales_CellFormatting;
                }
                else
                {
                    dgvSales.DataSource = store.Sales.ToList();
                }
            }
        }


        private void показатьОстаткиНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(store);
            form2.Show();
        }
    }
}