namespace GA
{
    partial class User_Inputs_View
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
            this.gbParameters1 = new System.Windows.Forms.GroupBox();
            this.numPM = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPC = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numNG = new System.Windows.Forms.NumericUpDown();
            this.lb2 = new System.Windows.Forms.Label();
            this.numPS = new System.Windows.Forms.NumericUpDown();
            this.lb1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numGran = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numRMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numRMin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCrossover = new System.Windows.Forms.ComboBox();
            this.cbMutation = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbElitism = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbRanking = new System.Windows.Forms.CheckBox();
            this.numEC = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cbOptimization = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btGo = new System.Windows.Forms.Button();
            this.btGoSt = new System.Windows.Forms.Button();
            this.gbParameters1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEC)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParameters1
            // 
            this.gbParameters1.Controls.Add(this.numPM);
            this.gbParameters1.Controls.Add(this.label2);
            this.gbParameters1.Controls.Add(this.numPC);
            this.gbParameters1.Controls.Add(this.label1);
            this.gbParameters1.Controls.Add(this.numNG);
            this.gbParameters1.Controls.Add(this.lb2);
            this.gbParameters1.Controls.Add(this.numPS);
            this.gbParameters1.Controls.Add(this.lb1);
            this.gbParameters1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbParameters1.Location = new System.Drawing.Point(12, 12);
            this.gbParameters1.Name = "gbParameters1";
            this.gbParameters1.Size = new System.Drawing.Size(312, 185);
            this.gbParameters1.TabIndex = 0;
            this.gbParameters1.TabStop = false;
            this.gbParameters1.Text = "Initial parameters";
            // 
            // numPM
            // 
            this.numPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPM.Location = new System.Drawing.Point(197, 140);
            this.numPM.Name = "numPM";
            this.numPM.Size = new System.Drawing.Size(109, 32);
            this.numPM.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "P(Mutation):";
            // 
            // numPC
            // 
            this.numPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPC.Location = new System.Drawing.Point(197, 102);
            this.numPC.Name = "numPC";
            this.numPC.Size = new System.Drawing.Size(109, 32);
            this.numPC.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "P(Crossover):";
            // 
            // numNG
            // 
            this.numNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNG.Location = new System.Drawing.Point(197, 64);
            this.numNG.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNG.Name = "numNG";
            this.numNG.Size = new System.Drawing.Size(109, 32);
            this.numNG.TabIndex = 3;
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.Location = new System.Drawing.Point(6, 66);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(185, 26);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "Nº of generations:";
            // 
            // numPS
            // 
            this.numPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPS.Location = new System.Drawing.Point(197, 26);
            this.numPS.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPS.Name = "numPS";
            this.numPS.Size = new System.Drawing.Size(109, 32);
            this.numPS.TabIndex = 1;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.Location = new System.Drawing.Point(25, 28);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(166, 26);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Population size:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numGran);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numRMax);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numRMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(330, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chromossome parameters";
            // 
            // numGran
            // 
            this.numGran.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGran.Location = new System.Drawing.Point(132, 140);
            this.numGran.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGran.Name = "numGran";
            this.numGran.Size = new System.Drawing.Size(91, 32);
            this.numGran.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Granularity";
            // 
            // numRMax
            // 
            this.numRMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRMax.Location = new System.Drawing.Point(132, 102);
            this.numRMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRMax.Name = "numRMax";
            this.numRMax.Size = new System.Drawing.Size(91, 32);
            this.numRMax.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Maximum";
            // 
            // numRMin
            // 
            this.numRMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRMin.Location = new System.Drawing.Point(132, 64);
            this.numRMin.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRMin.Name = "numRMin";
            this.numRMin.Size = new System.Drawing.Size(91, 32);
            this.numRMin.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Minimum";
            // 
            // cbSelection
            // 
            this.cbSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "Wheel Roulette",
            "Tournament"});
            this.cbSelection.Location = new System.Drawing.Point(192, 68);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(211, 33);
            this.cbSelection.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mutation Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Crossover Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "Selection Type:";
            // 
            // cbCrossover
            // 
            this.cbCrossover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCrossover.FormattingEnabled = true;
            this.cbCrossover.Items.AddRange(new object[] {
            "Uniform",
            "1 Point",
            "2 Points"});
            this.cbCrossover.Location = new System.Drawing.Point(192, 106);
            this.cbCrossover.Name = "cbCrossover";
            this.cbCrossover.Size = new System.Drawing.Size(211, 33);
            this.cbCrossover.TabIndex = 8;
            // 
            // cbMutation
            // 
            this.cbMutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMutation.FormattingEnabled = true;
            this.cbMutation.Items.AddRange(new object[] {
            "Single gene"});
            this.cbMutation.Location = new System.Drawing.Point(192, 144);
            this.cbMutation.Name = "cbMutation";
            this.cbMutation.Size = new System.Drawing.Size(211, 33);
            this.cbMutation.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbElitism);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbRanking);
            this.groupBox2.Controls.Add(this.numEC);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbOptimization);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbMutation);
            this.groupBox2.Controls.Add(this.cbSelection);
            this.groupBox2.Controls.Add(this.cbCrossover);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 228);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processes parameters";
            // 
            // cbElitism
            // 
            this.cbElitism.AutoSize = true;
            this.cbElitism.Location = new System.Drawing.Point(106, 35);
            this.cbElitism.Name = "cbElitism";
            this.cbElitism.Size = new System.Drawing.Size(15, 14);
            this.cbElitism.TabIndex = 16;
            this.cbElitism.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(238, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 26);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ranking:";
            // 
            // cbRanking
            // 
            this.cbRanking.AutoSize = true;
            this.cbRanking.Location = new System.Drawing.Point(342, 35);
            this.cbRanking.Name = "cbRanking";
            this.cbRanking.Size = new System.Drawing.Size(15, 14);
            this.cbRanking.TabIndex = 14;
            this.cbRanking.UseVisualStyleBackColor = true;
            // 
            // numEC
            // 
            this.numEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEC.Location = new System.Drawing.Point(136, 27);
            this.numEC.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numEC.Name = "numEC";
            this.numEC.Size = new System.Drawing.Size(58, 32);
            this.numEC.TabIndex = 13;
            this.numEC.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 26);
            this.label9.TabIndex = 12;
            this.label9.Text = "Elitism:";
            // 
            // cbOptimization
            // 
            this.cbOptimization.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOptimization.FormattingEnabled = true;
            this.cbOptimization.Items.AddRange(new object[] {
            "Minimum",
            "Maximum"});
            this.cbOptimization.Location = new System.Drawing.Point(192, 183);
            this.cbOptimization.Name = "cbOptimization";
            this.cbOptimization.Size = new System.Drawing.Size(211, 33);
            this.cbOptimization.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 26);
            this.label10.TabIndex = 10;
            this.label10.Text = "Optimization:";
            // 
            // btGo
            // 
            this.btGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGo.Location = new System.Drawing.Point(433, 212);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(132, 104);
            this.btGo.TabIndex = 11;
            this.btGo.Text = "Processes GA only once";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // btGoSt
            // 
            this.btGoSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGoSt.Location = new System.Drawing.Point(433, 327);
            this.btGoSt.Name = "btGoSt";
            this.btGoSt.Size = new System.Drawing.Size(132, 104);
            this.btGoSt.TabIndex = 12;
            this.btGoSt.Text = "Processes GA with Repetition";
            this.btGoSt.UseVisualStyleBackColor = true;
            this.btGoSt.Click += new System.EventHandler(this.btGoSt_Click);
            // 
            // User_Inputs_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 439);
            this.Controls.Add(this.btGoSt);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbParameters1);
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "User_Inputs_View";
            this.Text = "User_Inputs_View";
            this.gbParameters1.ResumeLayout(false);
            this.gbParameters1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRMin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParameters1;
        private System.Windows.Forms.NumericUpDown numPS;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.NumericUpDown numPM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numNG;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numGran;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numRMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCrossover;
        private System.Windows.Forms.ComboBox cbMutation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.NumericUpDown numEC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbOptimization;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btGoSt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbRanking;
        private System.Windows.Forms.CheckBox cbElitism;
    }
}