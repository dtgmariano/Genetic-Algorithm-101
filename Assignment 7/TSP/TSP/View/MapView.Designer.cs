namespace GA
{
    partial class MapView
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
            this.zgcMap = new ZedGraph.ZedGraphControl();
            this.btGo = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // zgcMap
            // 
            this.zgcMap.Location = new System.Drawing.Point(12, 12);
            this.zgcMap.Name = "zgcMap";
            this.zgcMap.ScrollGrace = 0D;
            this.zgcMap.ScrollMaxX = 0D;
            this.zgcMap.ScrollMaxY = 0D;
            this.zgcMap.ScrollMaxY2 = 0D;
            this.zgcMap.ScrollMinX = 0D;
            this.zgcMap.ScrollMinY = 0D;
            this.zgcMap.ScrollMinY2 = 0D;
            this.zgcMap.Size = new System.Drawing.Size(712, 575);
            this.zgcMap.TabIndex = 0;
            // 
            // btGo
            // 
            this.btGo.Location = new System.Drawing.Point(125, 593);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(75, 23);
            this.btGo.TabIndex = 1;
            this.btGo.Text = "button1";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 593);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(730, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(171, 258);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(907, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(171, 258);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(730, 276);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(171, 258);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(907, 276);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(171, 258);
            this.richTextBox4.TabIndex = 5;
            this.richTextBox4.Text = "";
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 632);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.zgcMap);
            this.Name = "MapView";
            this.Text = "MapView";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcMap;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
    }
}