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
            this.numNG = new System.Windows.Forms.NumericUpDown();
            this.lb2 = new System.Windows.Forms.Label();
            this.numPS = new System.Windows.Forms.NumericUpDown();
            this.lb1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCrossover = new System.Windows.Forms.ComboBox();
            this.cbMutation = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbElitism = new System.Windows.Forms.Label();
            this.tbElitism = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbRanking = new System.Windows.Forms.CheckBox();
            this.cbOptimization = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btGo = new System.Windows.Forms.Button();
            this.btGoSt = new System.Windows.Forms.Button();
            this.tbPm = new System.Windows.Forms.TrackBar();
            this.tbPc = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPc = new System.Windows.Forms.Label();
            this.lbPm = new System.Windows.Forms.Label();
            this.gbParameters1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbElitism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPc)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParameters1
            // 
            this.gbParameters1.Controls.Add(this.numNG);
            this.gbParameters1.Controls.Add(this.lb2);
            this.gbParameters1.Controls.Add(this.numPS);
            this.gbParameters1.Controls.Add(this.lb1);
            this.gbParameters1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbParameters1.Location = new System.Drawing.Point(12, 12);
            this.gbParameters1.Name = "gbParameters1";
            this.gbParameters1.Size = new System.Drawing.Size(291, 117);
            this.gbParameters1.TabIndex = 0;
            this.gbParameters1.TabStop = false;
            this.gbParameters1.Text = "Population";
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
            this.numNG.Size = new System.Drawing.Size(78, 32);
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
            this.numPS.Size = new System.Drawing.Size(78, 32);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mutation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Crossover";
            // 
            // cbSelection
            // 
            this.cbSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "Wheel Roulette",
            "Tournament"});
            this.cbSelection.Location = new System.Drawing.Point(155, 71);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(167, 33);
            this.cbSelection.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mutation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Crossover";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "Selection";
            // 
            // cbCrossover
            // 
            this.cbCrossover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCrossover.FormattingEnabled = true;
            this.cbCrossover.Items.AddRange(new object[] {
            "1 Point"});
            this.cbCrossover.Location = new System.Drawing.Point(155, 109);
            this.cbCrossover.Name = "cbCrossover";
            this.cbCrossover.Size = new System.Drawing.Size(167, 33);
            this.cbCrossover.TabIndex = 8;
            // 
            // cbMutation
            // 
            this.cbMutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMutation.FormattingEnabled = true;
            this.cbMutation.Items.AddRange(new object[] {
            "Single bit"});
            this.cbMutation.Location = new System.Drawing.Point(155, 147);
            this.cbMutation.Name = "cbMutation";
            this.cbMutation.Size = new System.Drawing.Size(167, 33);
            this.cbMutation.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbElitism);
            this.groupBox2.Controls.Add(this.tbElitism);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbRanking);
            this.groupBox2.Controls.Add(this.cbOptimization);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbMutation);
            this.groupBox2.Controls.Add(this.cbSelection);
            this.groupBox2.Controls.Add(this.cbCrossover);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 277);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processes parameters";
            // 
            // lbElitism
            // 
            this.lbElitism.AutoSize = true;
            this.lbElitism.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbElitism.Location = new System.Drawing.Point(155, 229);
            this.lbElitism.Name = "lbElitism";
            this.lbElitism.Size = new System.Drawing.Size(50, 26);
            this.lbElitism.TabIndex = 12;
            this.lbElitism.Text = "0 %";
            this.lbElitism.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbElitism
            // 
            this.tbElitism.Location = new System.Drawing.Point(211, 225);
            this.tbElitism.Maximum = 100;
            this.tbElitism.Name = "tbElitism";
            this.tbElitism.Size = new System.Drawing.Size(111, 45);
            this.tbElitism.TabIndex = 18;
            this.tbElitism.ValueChanged += new System.EventHandler(this.tbElitism_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(69, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 26);
            this.label9.TabIndex = 17;
            this.label9.Text = "Elitism";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 26);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ranking";
            // 
            // cbRanking
            // 
            this.cbRanking.AutoSize = true;
            this.cbRanking.Location = new System.Drawing.Point(160, 45);
            this.cbRanking.Name = "cbRanking";
            this.cbRanking.Size = new System.Drawing.Size(15, 14);
            this.cbRanking.TabIndex = 14;
            this.cbRanking.UseVisualStyleBackColor = true;
            // 
            // cbOptimization
            // 
            this.cbOptimization.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOptimization.FormattingEnabled = true;
            this.cbOptimization.Items.AddRange(new object[] {
            "Maximum",
            "Minimum"});
            this.cbOptimization.Location = new System.Drawing.Point(155, 186);
            this.cbOptimization.Name = "cbOptimization";
            this.cbOptimization.Size = new System.Drawing.Size(167, 33);
            this.cbOptimization.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 26);
            this.label10.TabIndex = 10;
            this.label10.Text = "Optimization";
            // 
            // btGo
            // 
            this.btGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGo.Location = new System.Drawing.Point(12, 553);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(158, 68);
            this.btGo.TabIndex = 11;
            this.btGo.Text = "Start GA on Graph module";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // btGoSt
            // 
            this.btGoSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGoSt.Location = new System.Drawing.Point(176, 553);
            this.btGoSt.Name = "btGoSt";
            this.btGoSt.Size = new System.Drawing.Size(158, 68);
            this.btGoSt.TabIndex = 12;
            this.btGoSt.Text = "Start GA on Stats module";
            this.btGoSt.UseVisualStyleBackColor = true;
            this.btGoSt.Click += new System.EventHandler(this.btGoSt_Click);
            // 
            // tbPm
            // 
            this.tbPm.Location = new System.Drawing.Point(180, 79);
            this.tbPm.Maximum = 100;
            this.tbPm.Name = "tbPm";
            this.tbPm.Size = new System.Drawing.Size(95, 45);
            this.tbPm.TabIndex = 20;
            this.tbPm.ValueChanged += new System.EventHandler(this.tbPm_ValueChanged);
            // 
            // tbPc
            // 
            this.tbPc.Location = new System.Drawing.Point(180, 31);
            this.tbPc.Maximum = 100;
            this.tbPc.Name = "tbPc";
            this.tbPc.Size = new System.Drawing.Size(95, 45);
            this.tbPc.TabIndex = 22;
            this.tbPc.ValueChanged += new System.EventHandler(this.tbPc_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbPc);
            this.groupBox3.Controls.Add(this.tbPm);
            this.groupBox3.Controls.Add(this.tbPc);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbPm);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox3.Location = new System.Drawing.Point(12, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 129);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Probabilities";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lbPc
            // 
            this.lbPc.AutoSize = true;
            this.lbPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPc.Location = new System.Drawing.Point(124, 31);
            this.lbPc.Name = "lbPc";
            this.lbPc.Size = new System.Drawing.Size(50, 26);
            this.lbPc.TabIndex = 21;
            this.lbPc.Text = "0 %";
            this.lbPc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbPm
            // 
            this.lbPm.AutoSize = true;
            this.lbPm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPm.Location = new System.Drawing.Point(124, 79);
            this.lbPm.Name = "lbPm";
            this.lbPm.Size = new System.Drawing.Size(50, 26);
            this.lbPm.TabIndex = 19;
            this.lbPm.Text = "0 %";
            this.lbPm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // User_Inputs_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 632);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btGoSt);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbParameters1);
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "User_Inputs_View";
            this.Text = "SETTINGS";
            this.gbParameters1.ResumeLayout(false);
            this.gbParameters1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbElitism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParameters1;
        private System.Windows.Forms.NumericUpDown numPS;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numNG;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.ComboBox cbSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCrossover;
        private System.Windows.Forms.ComboBox cbMutation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Label lbElitism;
        private System.Windows.Forms.ComboBox cbOptimization;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btGoSt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbRanking;
        private System.Windows.Forms.TrackBar tbElitism;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tbPc;
        private System.Windows.Forms.TrackBar tbPm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbPc;
        private System.Windows.Forms.Label lbPm;
    }
}