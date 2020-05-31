namespace Scheduling
{
    partial class generate
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.view_emp = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Route_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generate_rota_c = new System.Windows.Forms.Button();
            this.finalis = new System.Windows.Forms.Button();
            this.view_rot = new System.Windows.Forms.Button();
            this.delet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Route});
            this.dataGridView1.Location = new System.Drawing.Point(294, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(159, 239);
            this.dataGridView1.TabIndex = 0;
            // 
            // Route
            // 
            this.Route.HeaderText = "Route";
            this.Route.Name = "Route";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Routes for week 1";
            // 
            // view_emp
            // 
            this.view_emp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_emp.Location = new System.Drawing.Point(530, 157);
            this.view_emp.Name = "view_emp";
            this.view_emp.Size = new System.Drawing.Size(197, 25);
            this.view_emp.TabIndex = 2;
            this.view_emp.Text = "view employees for that route";
            this.view_emp.UseVisualStyleBackColor = true;
            this.view_emp.Click += new System.EventHandler(this.view_emp_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Route_,
            this.Duty,
            this.Date});
            this.dataGridView3.Location = new System.Drawing.Point(216, 453);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(345, 247);
            this.dataGridView3.TabIndex = 4;
            // 
            // Route_
            // 
            this.Route_.HeaderText = "Route_";
            this.Route_.Name = "Route_";
            // 
            // Duty
            // 
            this.Duty.HeaderText = "Duty";
            this.Duty.Name = "Duty";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // generate_rota_c
            // 
            this.generate_rota_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_rota_c.Location = new System.Drawing.Point(571, 73);
            this.generate_rota_c.Name = "generate_rota_c";
            this.generate_rota_c.Size = new System.Drawing.Size(109, 25);
            this.generate_rota_c.TabIndex = 5;
            this.generate_rota_c.Text = "Generate rota";
            this.generate_rota_c.UseVisualStyleBackColor = true;
            this.generate_rota_c.Click += new System.EventHandler(this.generate_rota_c_Click);
            // 
            // finalis
            // 
            this.finalis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalis.Location = new System.Drawing.Point(571, 116);
            this.finalis.Name = "finalis";
            this.finalis.Size = new System.Drawing.Size(109, 25);
            this.finalis.TabIndex = 6;
            this.finalis.Text = "finalise";
            this.finalis.UseVisualStyleBackColor = true;
            this.finalis.Click += new System.EventHandler(this.finalis_Click);
            // 
            // view_rot
            // 
            this.view_rot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_rot.Location = new System.Drawing.Point(560, 200);
            this.view_rot.Name = "view_rot";
            this.view_rot.Size = new System.Drawing.Size(134, 25);
            this.view_rot.TabIndex = 7;
            this.view_rot.Text = "View rota";
            this.view_rot.UseVisualStyleBackColor = true;
            this.view_rot.Click += new System.EventHandler(this.view_rot_Click);
            // 
            // delet
            // 
            this.delet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delet.Location = new System.Drawing.Point(560, 253);
            this.delet.Name = "delet";
            this.delet.Size = new System.Drawing.Size(134, 25);
            this.delet.TabIndex = 8;
            this.delet.Text = "delete rota";
            this.delet.UseVisualStyleBackColor = true;
            this.delet.Click += new System.EventHandler(this.delet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(307, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Duties that are not allocated";
            // 
            // generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 733);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delet);
            this.Controls.Add(this.view_rot);
            this.Controls.Add(this.finalis);
            this.Controls.Add(this.generate_rota_c);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.view_emp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Name = "generate";
            this.Text = "generate";
            this.Load += new System.EventHandler(this.Generate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button view_emp;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Button generate_rota_c;
        private System.Windows.Forms.Button finalis;
        private System.Windows.Forms.Button view_rot;
        private System.Windows.Forms.Button delet;
        private System.Windows.Forms.Label label2;
    }
}