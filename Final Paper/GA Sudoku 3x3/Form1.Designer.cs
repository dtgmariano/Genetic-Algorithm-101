namespace GA
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb22 = new System.Windows.Forms.TextBox();
            this.tb21 = new System.Windows.Forms.TextBox();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb02 = new System.Windows.Forms.TextBox();
            this.tb01 = new System.Windows.Forms.TextBox();
            this.tb00 = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.zgcPerformance = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb22);
            this.groupBox1.Controls.Add(this.tb21);
            this.groupBox1.Controls.Add(this.tb20);
            this.groupBox1.Controls.Add(this.tb12);
            this.groupBox1.Controls.Add(this.tb11);
            this.groupBox1.Controls.Add(this.tb10);
            this.groupBox1.Controls.Add(this.tb02);
            this.groupBox1.Controls.Add(this.tb01);
            this.groupBox1.Controls.Add(this.tb00);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sudoku";
            // 
            // tb22
            // 
            this.tb22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb22.Location = new System.Drawing.Point(94, 115);
            this.tb22.Name = "tb22";
            this.tb22.Size = new System.Drawing.Size(38, 38);
            this.tb22.TabIndex = 109;
            this.tb22.Text = "0";
            // 
            // tb21
            // 
            this.tb21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb21.Location = new System.Drawing.Point(50, 115);
            this.tb21.Name = "tb21";
            this.tb21.Size = new System.Drawing.Size(38, 38);
            this.tb21.TabIndex = 108;
            this.tb21.Text = "0";
            // 
            // tb20
            // 
            this.tb20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb20.Location = new System.Drawing.Point(6, 115);
            this.tb20.Name = "tb20";
            this.tb20.Size = new System.Drawing.Size(38, 38);
            this.tb20.TabIndex = 107;
            this.tb20.Text = "0";
            // 
            // tb12
            // 
            this.tb12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb12.Location = new System.Drawing.Point(94, 71);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(38, 38);
            this.tb12.TabIndex = 106;
            this.tb12.Text = "0";
            // 
            // tb11
            // 
            this.tb11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb11.Location = new System.Drawing.Point(50, 71);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(38, 38);
            this.tb11.TabIndex = 105;
            this.tb11.Text = "0";
            // 
            // tb10
            // 
            this.tb10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb10.Location = new System.Drawing.Point(6, 71);
            this.tb10.Name = "tb10";
            this.tb10.Size = new System.Drawing.Size(38, 38);
            this.tb10.TabIndex = 104;
            this.tb10.Text = "0";
            // 
            // tb02
            // 
            this.tb02.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb02.Location = new System.Drawing.Point(94, 27);
            this.tb02.Name = "tb02";
            this.tb02.Size = new System.Drawing.Size(38, 38);
            this.tb02.TabIndex = 103;
            this.tb02.Text = "0";
            // 
            // tb01
            // 
            this.tb01.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb01.Location = new System.Drawing.Point(50, 27);
            this.tb01.Name = "tb01";
            this.tb01.Size = new System.Drawing.Size(38, 38);
            this.tb01.TabIndex = 102;
            this.tb01.Text = "0";
            // 
            // tb00
            // 
            this.tb00.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tb00.Location = new System.Drawing.Point(6, 28);
            this.tb00.Name = "tb00";
            this.tb00.Size = new System.Drawing.Size(38, 38);
            this.tb00.TabIndex = 101;
            this.tb00.Text = "0";
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btStart.Location = new System.Drawing.Point(182, 78);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(57, 43);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Gen";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btGo
            // 
            this.btGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btGo.Location = new System.Drawing.Point(182, 129);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(57, 43);
            this.btGo.TabIndex = 2;
            this.btGo.Text = "Go";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // zgcPerformance
            // 
            this.zgcPerformance.Location = new System.Drawing.Point(18, 199);
            this.zgcPerformance.Name = "zgcPerformance";
            this.zgcPerformance.ScrollGrace = 0D;
            this.zgcPerformance.ScrollMaxX = 0D;
            this.zgcPerformance.ScrollMaxY = 0D;
            this.zgcPerformance.ScrollMaxY2 = 0D;
            this.zgcPerformance.ScrollMinX = 0D;
            this.zgcPerformance.ScrollMinY = 0D;
            this.zgcPerformance.ScrollMinY2 = 0D;
            this.zgcPerformance.Size = new System.Drawing.Size(472, 241);
            this.zgcPerformance.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 452);
            this.Controls.Add(this.zgcPerformance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb22;
        private System.Windows.Forms.TextBox tb21;
        private System.Windows.Forms.TextBox tb20;
        private System.Windows.Forms.TextBox tb12;
        private System.Windows.Forms.TextBox tb11;
        private System.Windows.Forms.TextBox tb10;
        private System.Windows.Forms.TextBox tb02;
        private System.Windows.Forms.TextBox tb01;
        private System.Windows.Forms.TextBox tb00;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private ZedGraph.ZedGraphControl zgcPerformance;
    }
}

