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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbGeneration = new System.Windows.Forms.Label();
            this.lbPenalty = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.numPS = new System.Windows.Forms.NumericUpDown();
            this.numNG = new System.Windows.Forms.NumericUpDown();
            this.numPc = new System.Windows.Forms.NumericUpDown();
            this.numPm = new System.Windows.Forms.NumericUpDown();
            this.numTs = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numEp = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEp)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbGeneration
            // 
            this.lbGeneration.AutoSize = true;
            this.lbGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbGeneration.Location = new System.Drawing.Point(16, 292);
            this.lbGeneration.Name = "lbGeneration";
            this.lbGeneration.Size = new System.Drawing.Size(97, 20);
            this.lbGeneration.TabIndex = 82;
            this.lbGeneration.Text = "Generation: ";
            // 
            // lbPenalty
            // 
            this.lbPenalty.AutoSize = true;
            this.lbPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbPenalty.Location = new System.Drawing.Point(16, 324);
            this.lbPenalty.Name = "lbPenalty";
            this.lbPenalty.Size = new System.Drawing.Size(65, 20);
            this.lbPenalty.TabIndex = 83;
            this.lbPenalty.Text = "Penalty:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.richTextBox1.Location = new System.Drawing.Point(156, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(258, 287);
            this.richTextBox1.TabIndex = 84;
            this.richTextBox1.Text = "";
            // 
            // numPS
            // 
            this.numPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numPS.Location = new System.Drawing.Point(70, 13);
            this.numPS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPS.Name = "numPS";
            this.numPS.Size = new System.Drawing.Size(80, 38);
            this.numPS.TabIndex = 87;
            // 
            // numNG
            // 
            this.numNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numNG.Location = new System.Drawing.Point(70, 57);
            this.numNG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNG.Name = "numNG";
            this.numNG.Size = new System.Drawing.Size(80, 38);
            this.numNG.TabIndex = 88;
            // 
            // numPc
            // 
            this.numPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numPc.Location = new System.Drawing.Point(70, 101);
            this.numPc.Name = "numPc";
            this.numPc.Size = new System.Drawing.Size(80, 38);
            this.numPc.TabIndex = 89;
            // 
            // numPm
            // 
            this.numPm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numPm.Location = new System.Drawing.Point(70, 145);
            this.numPm.Name = "numPm";
            this.numPm.Size = new System.Drawing.Size(80, 38);
            this.numPm.TabIndex = 90;
            // 
            // numTs
            // 
            this.numTs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numTs.Location = new System.Drawing.Point(70, 233);
            this.numTs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTs.Name = "numTs";
            this.numTs.Size = new System.Drawing.Size(80, 38);
            this.numTs.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 31);
            this.label1.TabIndex = 92;
            this.label1.Text = "PS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 31);
            this.label2.TabIndex = 93;
            this.label2.Text = "NG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(14, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 31);
            this.label3.TabIndex = 94;
            this.label3.Text = "Pc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(14, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 31);
            this.label4.TabIndex = 95;
            this.label4.Text = "Pm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(1, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 31);
            this.label5.TabIndex = 96;
            this.label5.Text = "T(s)";
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btStart.Location = new System.Drawing.Point(217, 305);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(91, 74);
            this.btStart.TabIndex = 97;
            this.btStart.Text = "Start GA";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btGo
            // 
            this.btGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btGo.Location = new System.Drawing.Point(323, 305);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(91, 74);
            this.btGo.TabIndex = 98;
            this.btGo.Text = "Go";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(-3, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 31);
            this.label6.TabIndex = 100;
            this.label6.Text = "Elite";
            // 
            // numEp
            // 
            this.numEp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.numEp.Location = new System.Drawing.Point(70, 189);
            this.numEp.Name = "numEp";
            this.numEp.Size = new System.Drawing.Size(80, 38);
            this.numEp.TabIndex = 99;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 399);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numEp);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTs);
            this.Controls.Add(this.numPm);
            this.Controls.Add(this.numPc);
            this.Controls.Add(this.numNG);
            this.Controls.Add(this.numPS);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbPenalty);
            this.Controls.Add(this.lbGeneration);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbGeneration;
        private System.Windows.Forms.Label lbPenalty;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown numPS;
        private System.Windows.Forms.NumericUpDown numNG;
        private System.Windows.Forms.NumericUpDown numPc;
        private System.Windows.Forms.NumericUpDown numPm;
        private System.Windows.Forms.NumericUpDown numTs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numEp;



    }
}

