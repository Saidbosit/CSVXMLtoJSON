namespace Test2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddCSV = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.CountTitle = new System.Windows.Forms.Label();
            this.AddXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddCSV
            // 
            this.AddCSV.Location = new System.Drawing.Point(100, 120);
            this.AddCSV.Name = "AddCSV";
            this.AddCSV.Size = new System.Drawing.Size(400, 30);
            this.AddCSV.TabIndex = 0;
            this.AddCSV.Text = "Добавить CSV файл";
            this.AddCSV.UseVisualStyleBackColor = true;
            this.AddCSV.Click += new System.EventHandler(this.AddCSV_Click);
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count.Location = new System.Drawing.Point(483, 235);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(18, 20);
            this.Count.TabIndex = 1;
            this.Count.Text = "0";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(100, 350);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(400, 30);
            this.Generate.TabIndex = 3;
            this.Generate.Text = "Сгенерировать";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // CountTitle
            // 
            this.CountTitle.AutoSize = true;
            this.CountTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountTitle.Location = new System.Drawing.Point(96, 235);
            this.CountTitle.Name = "CountTitle";
            this.CountTitle.Size = new System.Drawing.Size(267, 20);
            this.CountTitle.TabIndex = 5;
            this.CountTitle.Text = "Записей будет сформирована";
            // 
            // AddXML
            // 
            this.AddXML.Location = new System.Drawing.Point(100, 80);
            this.AddXML.Name = "AddXML";
            this.AddXML.Size = new System.Drawing.Size(400, 30);
            this.AddXML.TabIndex = 6;
            this.AddXML.Text = "Добавить XML файл";
            this.AddXML.UseVisualStyleBackColor = true;
            this.AddXML.Click += new System.EventHandler(this.AddXML_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.AddXML);
            this.Controls.Add(this.CountTitle);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.AddCSV);
            this.Name = "MainForm";
            this.Text = "CSVXMLtoJSON";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCSV;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label CountTitle;
        private System.Windows.Forms.Button AddXML;
    }
}

