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
            this.btnShowStock = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСписокТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСписокПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(8, 96);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(342, 206);
            this.dgvProducts.TabIndex = 0;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToOrderColumns = true;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(375, 96);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(354, 206);
            this.dgvSales.TabIndex = 1;
            this.dgvSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellContentClick);
            // 
            // btnShowStock
            // 
            this.btnShowStock.Location = new System.Drawing.Point(553, 367);
            this.btnShowStock.Name = "btnShowStock";
            this.btnShowStock.Size = new System.Drawing.Size(137, 38);
            this.btnShowStock.TabIndex = 4;
            this.btnShowStock.Text = "Показать остатки на складе";
            this.btnShowStock.UseVisualStyleBackColor = true;
            this.btnShowStock.Click += new System.EventHandler(this.btnShowStock_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(30, 367);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(200, 40);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Сформировать отчет о продажах";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(113, 341);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(417, 341);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 7;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(5, 341);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(88, 13);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Начальная дата";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(319, 341);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(81, 13);
            this.lblEndDate.TabIndex = 9;
            this.lblEndDate.Text = "Конечная дата";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(82, 59);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(157, 24);
            this.lblProducts.TabIndex = 10;
            this.lblProducts.Text = "Список товаров";
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblSales.Location = new System.Drawing.Point(480, 59);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(153, 24);
            this.lblSales.TabIndex = 11;
            this.lblSales.Text = "Список продаж";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьСписокТоваровToolStripMenuItem,
            this.загрузитьСписокПродажToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьСписокТоваровToolStripMenuItem
            // 
            this.загрузитьСписокТоваровToolStripMenuItem.Name = "загрузитьСписокТоваровToolStripMenuItem";
            this.загрузитьСписокТоваровToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.загрузитьСписокТоваровToolStripMenuItem.Text = "Загрузить список товаров";
            this.загрузитьСписокТоваровToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСписокТоваровToolStripMenuItem_Click);
            // 
            // загрузитьСписокПродажToolStripMenuItem
            // 
            this.загрузитьСписокПродажToolStripMenuItem.Name = "загрузитьСписокПродажToolStripMenuItem";
            this.загрузитьСписокПродажToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.загрузитьСписокПродажToolStripMenuItem.Text = "Загрузить список продаж";
            this.загрузитьСписокПродажToolStripMenuItem.Click += new System.EventHandler(this.загрузитьСписокПродажToolStripMenuItem_Click);
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
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Button btnShowStock;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСписокТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСписокПродажToolStripMenuItem;
    }
}

