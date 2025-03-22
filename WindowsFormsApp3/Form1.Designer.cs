namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.btnLoadProducts = new System.Windows.Forms.Button();
            this.btnLoadSales = new System.Windows.Forms.Button();
            this.btnShowStock = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(13, 30);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(342, 206);
            this.dgvProducts.TabIndex = 0;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToOrderColumns = true;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(372, 30);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(354, 206);
            this.dgvSales.TabIndex = 1;
            this.dgvSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellContentClick);
            // 
            // btnLoadProducts
            // 
            this.btnLoadProducts.Location = new System.Drawing.Point(537, 256);
            this.btnLoadProducts.Name = "btnLoadProducts";
            this.btnLoadProducts.Size = new System.Drawing.Size(159, 39);
            this.btnLoadProducts.TabIndex = 2;
            this.btnLoadProducts.Text = "Загрузить список товаров";
            this.btnLoadProducts.UseVisualStyleBackColor = true;
            this.btnLoadProducts.Click += new System.EventHandler(this.btnLoadProducts_Click);
            // 
            // btnLoadSales
            // 
            this.btnLoadSales.Location = new System.Drawing.Point(251, 254);
            this.btnLoadSales.Name = "btnLoadSales";
            this.btnLoadSales.Size = new System.Drawing.Size(137, 40);
            this.btnLoadSales.TabIndex = 3;
            this.btnLoadSales.Text = "Загрузить список продаж";
            this.btnLoadSales.UseVisualStyleBackColor = true;
            // 
            // btnShowStock
            // 
            this.btnShowStock.Location = new System.Drawing.Point(394, 256);
            this.btnShowStock.Name = "btnShowStock";
            this.btnShowStock.Size = new System.Drawing.Size(137, 38);
            this.btnShowStock.TabIndex = 4;
            this.btnShowStock.Text = "Показать остатки на складе";
            this.btnShowStock.UseVisualStyleBackColor = true;
            this.btnShowStock.Click += new System.EventHandler(this.btnShowStock_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(45, 254);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(200, 40);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Сформировать отчет о продажах";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(99, 322);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(414, 322);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(5, 329);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(88, 13);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Начальная дата";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(319, 328);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(81, 13);
            this.lblEndDate.TabIndex = 9;
            this.lblEndDate.Text = "Конечная дата";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(95, 3);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(157, 24);
            this.lblProducts.TabIndex = 10;
            this.lblProducts.Text = "Список товаров";
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblSales.Location = new System.Drawing.Point(480, 3);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(153, 24);
            this.lblSales.TabIndex = 11;
            this.lblSales.Text = "Список продаж";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 450);
            this.Controls.Add(this.lblSales);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnShowStock);
            this.Controls.Add(this.btnLoadSales);
            this.Controls.Add(this.btnLoadProducts);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Button btnLoadProducts;
        private System.Windows.Forms.Button btnLoadSales;
        private System.Windows.Forms.Button btnShowStock;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblSales;
    }
}

