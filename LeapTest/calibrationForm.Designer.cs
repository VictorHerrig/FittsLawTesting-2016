namespace LeapTest
{
    partial class calibrationForm
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
            this.calibButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calibButton
            // 
            this.calibButton.Location = new System.Drawing.Point(206, 110);
            this.calibButton.Name = "calibButton";
            this.calibButton.Size = new System.Drawing.Size(180, 120);
            this.calibButton.TabIndex = 0;
            this.calibButton.Text = "Press enter when your hand or finger is centered to your satisfaction";
            this.calibButton.UseVisualStyleBackColor = true;
            this.calibButton.Click += new System.EventHandler(this.calibButton_Click);
            // 
            // calibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 359);
            this.Controls.Add(this.calibButton);
            this.Name = "calibrationForm";
            this.Text = "calibrationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calibButton;
    }
}