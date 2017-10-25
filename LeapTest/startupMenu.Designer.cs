namespace LeapTest
{
    partial class startupMenu
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDSetting = new System.Windows.Forms.NumericUpDown();
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.subjLabel = new System.Windows.Forms.Label();
            this.subjNumber = new System.Windows.Forms.NumericUpDown();
            this.endbutton = new System.Windows.Forms.Button();
            this.recalibButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IDSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click Method:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tracking Method:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(117, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(204, 89);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(99, 24);
            this.continueButton.TabIndex = 4;
            this.continueButton.Text = "Take the test";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Visible = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Orientation: ";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(117, 92);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(172, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.Orientation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Range of motion: ";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(117, 136);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(172, 21);
            this.comboBox4.TabIndex = 14;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Index of difficulty: ";
            this.label3.Visible = false;
            // 
            // IDSetting
            // 
            this.IDSetting.Location = new System.Drawing.Point(132, 17);
            this.IDSetting.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.IDSetting.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IDSetting.Name = "IDSetting";
            this.IDSetting.Size = new System.Drawing.Size(157, 20);
            this.IDSetting.TabIndex = 16;
            this.IDSetting.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IDSetting.Visible = false;
            this.IDSetting.ValueChanged += new System.EventHandler(this.IDSetting_ValueChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 92);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(88, 24);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(204, 172);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(99, 23);
            this.nextButton.TabIndex = 18;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // subjLabel
            // 
            this.subjLabel.AutoSize = true;
            this.subjLabel.Location = new System.Drawing.Point(18, 55);
            this.subjLabel.Name = "subjLabel";
            this.subjLabel.Size = new System.Drawing.Size(87, 13);
            this.subjLabel.TabIndex = 19;
            this.subjLabel.Text = "Subject number: ";
            this.subjLabel.Visible = false;
            // 
            // subjNumber
            // 
            this.subjNumber.Location = new System.Drawing.Point(132, 53);
            this.subjNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.subjNumber.Name = "subjNumber";
            this.subjNumber.Size = new System.Drawing.Size(157, 20);
            this.subjNumber.TabIndex = 20;
            this.subjNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.subjNumber.Visible = false;
            this.subjNumber.ValueChanged += new System.EventHandler(this.subjNumber_ValueChanged);
            // 
            // endbutton
            // 
            this.endbutton.Location = new System.Drawing.Point(12, 172);
            this.endbutton.Name = "endbutton";
            this.endbutton.Size = new System.Drawing.Size(88, 23);
            this.endbutton.TabIndex = 21;
            this.endbutton.Text = "End Tests";
            this.endbutton.UseVisualStyleBackColor = true;
            this.endbutton.Click += new System.EventHandler(this.endbutton_Click);
            // 
            // recalibButton
            // 
            this.recalibButton.Location = new System.Drawing.Point(117, 172);
            this.recalibButton.Name = "recalibButton";
            this.recalibButton.Size = new System.Drawing.Size(75, 23);
            this.recalibButton.TabIndex = 22;
            this.recalibButton.Text = "Recalibrate";
            this.recalibButton.UseVisualStyleBackColor = true;
            this.recalibButton.Click += new System.EventHandler(this.recalibButton_Click);
            // 
            // startupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 206);
            this.Controls.Add(this.recalibButton);
            this.Controls.Add(this.endbutton);
            this.Controls.Add(this.subjNumber);
            this.Controls.Add(this.subjLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.IDSetting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "startupMenu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.IDSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IDSetting;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label subjLabel;
        private System.Windows.Forms.NumericUpDown subjNumber;
        private System.Windows.Forms.Button endbutton;
        private System.Windows.Forms.Button recalibButton;
    }
}