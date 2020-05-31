namespace Scheduling
{
    partial class Home_duty
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.day = new System.Windows.Forms.RadioButton();
            this.night = new System.Windows.Forms.RadioButton();
            this.evening = new System.Windows.Forms.RadioButton();
            this.Add_duty = new System.Windows.Forms.Button();
            this.Delete_duty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add duty";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Route,
            this.Duty,
            this.Description});
            this.dataGridView1.Location = new System.Drawing.Point(315, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(420, 259);
            this.dataGridView1.TabIndex = 1;
            // 
            // Route
            // 
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            // 
            // Duty
            // 
            this.Duty.HeaderText = "Duty";
            this.Duty.Name = "Duty";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Route: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Location = new System.Drawing.Point(12, 177);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(67, 17);
            this.day.TabIndex = 4;
            this.day.TabStop = true;
            this.day.Text = "Day duty";
            this.day.UseVisualStyleBackColor = true;
            this.day.CheckedChanged += new System.EventHandler(this.Day_CheckedChanged);
            // 
            // night
            // 
            this.night.AutoSize = true;
            this.night.Location = new System.Drawing.Point(103, 177);
            this.night.Name = "night";
            this.night.Size = new System.Drawing.Size(73, 17);
            this.night.TabIndex = 5;
            this.night.TabStop = true;
            this.night.Text = "Night duty";
            this.night.UseVisualStyleBackColor = true;
            this.night.CheckedChanged += new System.EventHandler(this.Night_CheckedChanged);
            // 
            // evening
            // 
            this.evening.AutoSize = true;
            this.evening.Location = new System.Drawing.Point(208, 177);
            this.evening.Name = "evening";
            this.evening.Size = new System.Drawing.Size(86, 17);
            this.evening.TabIndex = 6;
            this.evening.TabStop = true;
            this.evening.Text = "evening duty";
            this.evening.UseVisualStyleBackColor = true;
            this.evening.CheckedChanged += new System.EventHandler(this.Evening_CheckedChanged);
            // 
            // Add_duty
            // 
            this.Add_duty.Location = new System.Drawing.Point(101, 231);
            this.Add_duty.Name = "Add_duty";
            this.Add_duty.Size = new System.Drawing.Size(75, 23);
            this.Add_duty.TabIndex = 7;
            this.Add_duty.Text = "Add";
            this.Add_duty.UseVisualStyleBackColor = true;
            this.Add_duty.Click += new System.EventHandler(this.Add_duty_Click);
            // 
            // Delete_duty
            // 
            this.Delete_duty.Location = new System.Drawing.Point(101, 283);
            this.Delete_duty.Name = "Delete_duty";
            this.Delete_duty.Size = new System.Drawing.Size(75, 23);
            this.Delete_duty.TabIndex = 8;
            this.Delete_duty.Text = "Delete";
            this.Delete_duty.UseVisualStyleBackColor = true;
            this.Delete_duty.Click += new System.EventHandler(this.Delete_duty_Click);
            // 
            // Home_duty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Delete_duty);
            this.Controls.Add(this.Add_duty);
            this.Controls.Add(this.evening);
            this.Controls.Add(this.night);
            this.Controls.Add(this.day);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Home_duty";
            this.Text = "Home_duty";
            this.Load += new System.EventHandler(this.Home_duty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton day;
        private System.Windows.Forms.RadioButton night;
        private System.Windows.Forms.RadioButton evening;
        private System.Windows.Forms.Button Add_duty;
        private System.Windows.Forms.Button Delete_duty;
    }
}